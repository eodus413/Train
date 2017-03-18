namespace ProjectCatMan
{
    public class MoveLeftCommand : ICommand
    {
        public MoveLeftCommand(IMovable movable)
        {
            this.movable = movable;
        }

        IMovable movable;
        public void Execute()
        {
            movable.Move(Direction.Left);
        }
        public void Undo()
        {
            movable.Stop();
        }
    }
    public class MoveRightCommand : ICommand
    {
        public MoveRightCommand(IMovable movable)
        {
            this.movable = movable;
        }

        IMovable movable;
        public void Execute()
        {
            movable.Move(Direction.Right);
        }
        public void Undo()
        {
            movable.Stop();
        }
    }

    public class MoveUpCommand : ICommand
    {
        public MoveUpCommand(IMovable movable)
        {
            this.movable = movable;
        }

        IMovable movable;
        public void Execute()
        {

        }
        public void Undo()
        {
            movable.Stop();
        }
    }
    public class MoveDownCommand : ICommand
    {
        public MoveDownCommand(IMovable movable)
        {
            this.movable = movable;
        }

        IMovable movable;
        public void Execute()
        {

        }
        public void Undo()
        {
            movable.Stop();
        }
    }
}