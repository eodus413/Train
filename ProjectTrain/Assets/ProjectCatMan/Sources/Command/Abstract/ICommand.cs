namespace ProjectCatMan
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}