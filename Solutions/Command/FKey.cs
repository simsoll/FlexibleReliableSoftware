namespace Command
{
    public class FKey
    {
        private ICommand _command;
        /** assign a command to the key */
        public void Assign(ICommand command)
        {
            _command = command;
        }
        /** "press the key" */
        public void Press()
        {
            _command.Execute();
        }
    }
}