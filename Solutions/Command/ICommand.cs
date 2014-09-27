namespace Command
{
    /** The interface defining the Command role */
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}