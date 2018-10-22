using System;

namespace JiraBackSync.Core.Utils
{
    public interface IConsole
    {
        string ReadPassword(string introMsg = null, string outroMsg = null);

        ConsoleKeyInfo ReadKey();

        string ReadLine();
    }
}