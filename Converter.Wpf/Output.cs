using Converter.Lib;

namespace Converter.Wpf
{
    class Output : IOutput
    {

        public List<string?> OutputList = new();
        void IOutput.WriteLine(object message)
        {

            OutputList.Add(message.ToString());
        }
    }
}
