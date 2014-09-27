namespace Command
{
    public class WriteCommand : ICommand
    {
        private readonly Document _doc;
        private readonly string _line;

        public WriteCommand(Document doc, string line)
        {
            _doc = doc;
            _line = line;
        }

        public void Execute()
        {
            _doc.Write(_line);
        }

        public void Undo()
        {
            _doc.Erase(_line);
        }
    }
}