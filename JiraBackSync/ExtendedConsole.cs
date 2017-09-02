using System;
using System.Collections.Generic;
using System.Linq;

namespace JiraBackSync
{

    /// <summary>
    /// Adds some nice help to the console. Static extension methods don't exist (probably for a good reason) so the next best thing is congruent naming.
    /// </summary>
    internal static class ExtendedConsole
    {
        /// <summary>
        /// Like System.Console.ReadLine(), only with a mask.
        /// </summary>
        /// <param name="mask">a <c>char</c> representing your choice of console mask</param>
        /// <returns>the string the user typed in </returns>
        public static string ReadPassword(char mask)
        {
            const int enter = 13, backsp = 8, ctrlbacksp = 127;
            int[] filtered = { 0, 27, 9, 10 /*, 32 space, if you care */ }; // const

            var pass = new Stack<char>();
            char chr;

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

            return new string(pass.Reverse().ToArray());
        }

        /// <summary>
        /// Like System.Console.ReadLine(), only with a mask.
        /// </summary>
        /// <returns>the string the user typed in </returns>
        public static string ReadPassword()
        {
            return ReadPassword('*');
        }
    }
}