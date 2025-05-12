namespace Converter.Cli
{
    using Converter.Lib;
    internal class Output : IOutput
    {
        public void WriteLine(object message)
        {
            Console.WriteLine(message);
        }
    }
}
