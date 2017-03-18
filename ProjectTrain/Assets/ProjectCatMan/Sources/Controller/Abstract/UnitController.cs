using UnityEngine;

namespace ProjectCatMan
{
    public abstract class UnitController :  IController
    {
        public UnitController(UnitBase unit)
        {
            this.unit = unit;
            this.transform = unit.transform;
            this.gameObject = unit.gameObject;

            this.damageable = unit.damageable;
            this.killable = unit.killable;
            this.seeable = unit.seeable;
            this.movable = unit.movable;
        }
        public UnitBase unit { get; private set; }
        public Transform transform { get; private set; }
        public GameObject gameObject { get; private set; }

        public IDamageable damageable { get; private set; }
        public IKillable killable { get; private set; }
        public ISeeable seeable { get; private set; }
        public IMovable movable { get; private set; }
        
        public abstract void Initialize();
        public abstract void Execute();
        public abstract void PhysicsExecute();
    }
}