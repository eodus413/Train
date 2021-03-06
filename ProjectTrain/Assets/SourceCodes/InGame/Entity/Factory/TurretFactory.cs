﻿namespace Entity.Factory
{
    using Controller;
   
    public class MachineGunTowerFactory : IEntityFactory
    {
        public int GetHp { get { return 10; } }
        public float GetSpeed { get { return 0f; } }
        public IMoveBehavior GetMoveBehavior(EntityBase mover)
        {
            return new NoWayToMove(mover);
        }
        public EntityController GetController(EntityBase entity)
        {
            TurretBase turret = entity as TurretBase;
            if(turret != null)
            {
                return new TurretController(turret);
            }
            return null;
        }
    }

}