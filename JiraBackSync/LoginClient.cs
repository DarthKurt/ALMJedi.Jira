using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using AngleSharp.Parser.Html;
using JiraBackSync.Data;
using JiraBackSync.Properties;

namespace JiraBackSync
{
    public class LoginClient: BaseTmetricApiClient
    {

        public string Password { get; set; }

        protected override HttpClient PrepareHttpClient()
        {
            var baseAddress = new Uri(BaseUrl);
            var cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler
            {
                CookieContainer = cookieContainer,
                AllowAutoRedirect = false
            };

            var client = new HttpClient(handler)
            {
                BaseAddress = baseAddress
            };

            return client;
        }

        /// <summary>Gets the detailed report.</summary>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async Task<CookieCollection> GetApiKeyAsync(CancellationToken cancellationToken)
        {
            var loginData = await GetLoginPrerequisitesAsync(cancellationToken).ConfigureAwait(false);
            var loginCallbackRedirectData = await GetLoginCallbackAsync(Settings.Default.Email, Password, loginData,
                cancellationToken).ConfigureAwait(false);

            var html = await GetLoignPageAsync(loginCallbackRedirectData, cancellationToken).ConfigureAwait(false);

            var loginCallbackRes = ParseLoginCallbackForm(html);

            var res = await GetLoginResultAsync(loginCallbackRes, loginCallbackRedirectData.Cookies, cancellationToken).ConfigureAwait(false);
            return res.Cookies;
        }


        private async Task<LoginPrerequisites> GetLoginPrerequisitesAsync(CancellationToken cancellationToken)
        {
            var res1 = await StartLoignStepAsync(cancellationToken).ConfigureAwait(false);
            var res2 = await SecondLoignStepAsync(res1.Location, cancellationToken).ConfigureAwait(false);

            var html = await GetLoignPageAsync(res2, cancellationToken).ConfigureAwait(false);
            var tuple = ParseLoginForm(html);

            res1.Cookies.Add(res2.Cookies);
            var cookies = res1.Cookies;

            var result = new LoginPrerequisites
            {
                Cookies = cookies,
                SignIn = tuple.Item2,
                SrvKey = tuple.Item1
            };

            return result;
        }


        private async Task<LoginRedirectResult> StartLoignStepAsync(CancellationToken cancellationToken)
        {
            var cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler
            {
                CookieContainer = cookieContainer,
                AllowAutoRedirect = false
            };

            using (var client = new HttpClient(handler)
            {
                BaseAddress = new Uri(BaseUrl)
            })
            {
                using (var response = await client.GetAsync("login", cancellationToken)
                        .ConfigureAwait(false))
                {
                    var headers = response.Headers.ToDictionary(h => h.Key, h => h.Value);
                    foreach (var item in response.Content.Headers)
                        headers[item.Key] = item.Value;

                    if (response.StatusCode != HttpStatusCode.Found || response.Headers.Location == null)
                        throw new SwaggerException(
                            "The HTTP status code of the response was not expected (" + (int)response.StatusCode +
                            ").", response.StatusCode.ToString(),
                            await response.Content.ReadAsStringAsync().ConfigureAwait(false)
                            , headers, null);

                    var result = new LoginRedirectResult
                    {
                        Location = response.Headers.Location,
                        Cookies = CookieHelper.GetAllCookiesFromHeader(string.Join(",", headers["Set-Cookie"]), client.BaseAddress.Host)
                    };

                    return result;
                }
            }
        }

        private static async Task<LoginRedirectResult> SecondLoignStepAsync(Uri uri, CancellationToken cancellationToken)
        {
            var cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler
            {
                CookieContainer = cookieContainer,
                AllowAutoRedirect = false
            };

            using (var client = new HttpClient(handler)
            {
                BaseAddress = uri
            })
            {
                using (var response = await client.GetAsync("", cancellationToken)
                    .ConfigureAwait(false))
                {
                    var headers = response.Headers.ToDictionary(h => h.Key, h => h.Value);
                    foreach (var item in response.Content.Headers)
                        headers[item.Key] = item.Value;

                    if (response.StatusCode != HttpStatusCode.Found || response.Headers.Location == null)
                        throw new SwaggerException(
                            "The HTTP status code of the response was not expected (" + (int)response.StatusCode +
                            ").", response.StatusCode.ToString(),
                            await response.Content.ReadAsStringAsync().ConfigureAwait(false)
                            , headers, null);

                    var result = new LoginRedirectResult
                    {
                        Location = response.Headers.Location,
                        Cookies = CookieHelper.GetAllCookiesFromHeader(string.Join(",", headers["Set-Cookie"]), uri.Host)
                    };

                    return result;
                }
            }
        }

        private static async Task<string> GetLoignPageAsync(LoginRedirectResult redirect, CancellationToken cancellationToken)
        {
            var cookieContainer = new CookieContainer();
            cookieContainer.Add(redirect.Cookies);
            var handler = new HttpClientHandler
            {
                CookieContainer = cookieContainer,
                AllowAutoRedirect = false
            };

            using (var client = new HttpClient(handler)
            {
                BaseAddress = redirect.Location
            })
            {
                using (var response = await client.GetAsync("", cancellationToken)
                    .ConfigureAwait(false))
                {
                    var headers = response.Headers.ToDictionary(h => h.Key, h => h.Value);
                    foreach (var item in response.Content.Headers)
                        headers[item.Key] = item.Value;

                    if (!response.IsSuccessStatusCode)
                        throw new SwaggerException(
                            "The HTTP status code of the response was not expected (" + (int)response.StatusCode +
                            ").", response.StatusCode.ToString(),
                            await response.Content.ReadAsStringAsync().ConfigureAwait(false)
                            , headers, null);

                    var cookies =
                        CookieHelper.GetAllCookiesFromHeader(string.Join(",", headers["Set-Cookie"]),
                            redirect.Location.Host);

                    redirect.Cookies.Add(cookies);

                    return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                }
            }
        }

        private static Tuple<string, string> ParseLoginForm(string html)
        {
            var parser = new HtmlParser();

            var document = parser.Parse(html);
            var srvKey = document.All.FirstOrDefault(m => string.Equals("input", m.LocalName)
            && m.HasAttribute("type")
            && m.GetAttribute("type").Equals("hidden")
            && m.HasAttribute("name")
            && m.GetAttribute("name").Equals("idsrv.xsrf"))
            ?.GetAttribute("value");

            var formUrl = document.All.FirstOrDefault(
                m => string.Equals("form", m.LocalName))
                ?.GetAttribute("action");

            if (string.IsNullOrWhiteSpace(srvKey) || string.IsNullOrWhiteSpace(formUrl))
                return null;

            var formQuery = HttpUtility.ParseQueryString(formUrl.Substring(formUrl.IndexOf('?')));

            if (!formQuery.HasKeys())
                return null;

            var signeIn = formQuery["signin"];
            return new Tuple<string, string>(srvKey, signeIn);
        }

        private static LoginForm ParseLoginCallbackForm(string html)
        {
            var parser = new HtmlParser();

            var document = parser.Parse(html);
            var formFields = document.All.Where(m => string.Equals("input", m.LocalName)
                                                 && m.HasAttribute("type")
                                                 && m.GetAttribute("type").Equals("hidden")
                                                 && m.HasAttribute("name"))
                .ToDictionary(m => m.GetAttribute("name"), m => m.GetAttribute("value"));

            var formUrl = document.All.FirstOrDefault(
                    m => string.Equals("form", m.LocalName))
                ?.GetAttribute("action");

            if (formFields.Count <= 0 || string.IsNullOrWhiteSpace(formUrl))
                return null;

            return new LoginForm
            {
                Location = new Uri(formUrl),
                Fields = formFields
            };
        }

        private static async Task<LoginRedirectResult> GetLoginCallbackAsync(string login, string password,
            LoginPrerequisites loginData, CancellationToken cancellationToken)
        {
            const string srvKeyName = "idsrv.xsrf";

            var urlBuilder = new StringBuilder();
            urlBuilder.Append($"core/login?signin={loginData.SignIn}");

            var cookieContainer = new CookieContainer();

            cookieContainer.Add(loginData.Cookies);

            var handler = new HttpClientHandler
            {
                CookieContainer = cookieContainer,
                AllowAutoRedirect = false
            };

            using (var client = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://id.tmetric.com")
            })
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>(srvKeyName, loginData.SrvKey),
                    new KeyValuePair<string, string>("Username", login),
                    new KeyValuePair<string, string>("Password", password)
                });

                using (var response = await client
                    .PostAsync(urlBuilder.ToString(), content, cancellationToken)
                    .ConfigureAwait(false))
                {
                    var headers = response.Headers.ToDictionary(h => h.Key, h => h.Value);
                    foreach (var item in response.Content.Headers)
                        headers[item.Key] = item.Value;

                    if (response.StatusCode != HttpStatusCode.Found || response.Headers.Location == null)
                        throw new SwaggerException(
                            "The HTTP status code of the response was not expected (" + (int)response.StatusCode +
                            ").", response.StatusCode.ToString(),
                            await response.Content.ReadAsStringAsync().ConfigureAwait(false)
                            , headers, null);

                    var result = new LoginRedirectResult
                    {
                        Location = response.Headers.Location,
                        Cookies = CookieHelper.GetAllCookiesFromHeader(string.Join(",", headers["Set-Cookie"]), client.BaseAddress.Host)
                    };

                    result.Cookies.Add(loginData.Cookies);

                    return result;
                }
            }
        }

        private static async Task<LoginRedirectResult> GetLoginResultAsync(LoginForm form, CookieCollection cookies, CancellationToken cancellationToken)
        {
            var cookieContainer = new CookieContainer();

            cookieContainer.Add(cookies);

            var handler = new HttpClientHandler
            {
                CookieContainer = cookieContainer,
                AllowAutoRedirect = false
            };

            using (var client = new HttpClient(handler)
            {
                BaseAddress = form.Location
            })
            {
                var content = new FormUrlEncodedContent(form.Fields);

                using (var response = await client
                    .PostAsync("", content, cancellationToken)
                    .ConfigureAwait(false))
                {
                    var headers = response.Headers.ToDictionary(h => h.Key, h => h.Value);
                    foreach (var item in response.Content.Headers)
                        headers[item.Key] = item.Value;

                    if (response.StatusCode != HttpStatusCode.Found || response.Headers.Location == null)
                        throw new SwaggerException(
                            "The HTTP status code of the response was not expected (" + (int)response.StatusCode +
                            ").", response.StatusCode.ToString(),
                            await response.Content.ReadAsStringAsync().ConfigureAwait(false)
                            , headers, null);

                    var result = new LoginRedirectResult
                    {
                        Location = response.Headers.Location,
                        Cookies = CookieHelper.GetAllCookiesFromHeader(string.Join(",", headers["Set-Cookie"]), client.BaseAddress.Host)
                    };

                    return result;
                }
            }
        }
    }
}