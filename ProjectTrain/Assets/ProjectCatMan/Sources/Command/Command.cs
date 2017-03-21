namespace ProjectCatMan
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
    public class MoveCommand : ICommand
    {
        public MoveCommand(IMovable movable, Direction direction)
        {
            this.movable = movable;
            this.direction = direction;
        }

        IMovable movable;
        Direction direction;
        public void Execute()
        {
            movable.Move(direction);
        }
        public void Undo()
        {
            movable.Stop();
        }
    }
}