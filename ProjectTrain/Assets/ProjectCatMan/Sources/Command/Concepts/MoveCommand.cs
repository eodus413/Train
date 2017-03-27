using UnityEngine;

namespace ProjectCatMan
{
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
            movable.Move(direction.DirToVec3());
        }
        public void Undo()
        {
            movable.Stop();
        }
    }
    public class MoveToTargetCommand : ICommand
    {
        public MoveToTargetCommand(IMovable movable, ISee see)
        {
            this.movable = movable;
            this.see = see;

            this.transform = movable.transform;
        }

        public void Execute()
        {
            GameObject target = see.current;

            if (target == null) return;

            Direction location = transform.LocationOf(target);
            movable.Move(location.DirToVec3());
        }
        public void Undo()
        {
            movable.Stop();
        }

        IMovable movable;
        ISee see;

        Transform transform;
    }
}