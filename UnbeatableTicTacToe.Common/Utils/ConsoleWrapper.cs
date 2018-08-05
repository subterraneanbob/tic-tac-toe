using System;

namespace UnbeatableTicTacToe.Common.Utils
{
    public class ConsoleWrapper : IConsole
    {
        public void Clear()
        {
            Console.Clear();
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
