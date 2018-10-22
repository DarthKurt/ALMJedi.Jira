using System;
using System.Collections.Generic;
using System.Linq;
using Jira.BackSync.Core.Utils;

namespace Jira.BackSync.Configuration
{

    /// <summary>
    /// Adds some nice help to the console. Static extension methods don't exist (probably for a good reason) so the next best thing is congruent naming.
    /// </summary>
    internal class ExtendedConsole: IConsole
    {
        /// <summary>
        /// Like System.Console.ReadLine(), only with a mask.
        /// </summary>
        /// <param name="mask">a <c>char</c> representing your choice of console mask</param>
        /// <param name="introMsg">Message that will be shown before.</param>
        /// <param name="outroMsg">Message that will be shown after.</param>
        /// <returns>the string the user typed in </returns>
        public static string ReadPassword(char mask, string introMsg = null, string outroMsg = null)
        {
            const int enter = 13, backsp = 8, ctrlbacksp = 127;
            int[] filtered = { 0, 27, 9, 10 /*, 32 space, if you care */ }; // const

            var pass = new Stack<char>();
            char chr;

            if(!string.IsNullOrWhiteSpace(introMsg))
                Console.WriteLine(introMsg);

            while ((chr = Console.ReadKey(true).KeyChar) != enter)
            {
                switch (chr)
                {
                    case (char)backsp:
                        if (pass.Count <= 0)
                            continue;
                        Console.Write("\b \b");
                        pass.Pop();
                        break;
                    case (char)ctrlbacksp:
                        while (pass.Count > 0)
                        {
                            Console.Write("\b \b");
                            pass.Pop();
                        }
                        break;
                    default:
                        if (filtered.Count(x => chr == x) > 0) { }
                        else
                        {
                            pass.Push(chr);
                            Console.Write(mask);
                        }
                        break;
                }
            }
            Console.WriteLine();
            if (!string.IsNullOrWhiteSpace(outroMsg))
                Console.WriteLine(outroMsg);
            return new string(pass.Reverse().ToArray());
        }

        public string ReadPassword(string introMsg = null, string outroMsg = null)
        {
            return ReadPassword('*', introMsg, outroMsg);
        }

        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}