﻿using UnityEngine;

namespace ProjectCatMan
{
    public class MoveToTargetCommand : ICommand
    {
        public MoveToTargetCommand(IMovable movable, ITargeting targeting)
        {
            this.movable = movable;
            this.targeting = targeting;
        }

        public void Execute()
        {
            if (targeting.target == null) return;
            
            movable.Move(targeting.targetLocation);
        }
        public void Undo()
        {

        }

        IMovable movable;
        ITargeting targeting;
    }
}