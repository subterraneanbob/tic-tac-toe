namespace UnbeatableTicTacToe.Common.Utils
{
    public interface IConsole
    {
        void Clear();
        string ReadLine();
        void Write(string text);
        void WriteLine(string text);
    }
}
