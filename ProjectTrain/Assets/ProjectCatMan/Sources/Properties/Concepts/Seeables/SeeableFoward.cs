using UnityEngine;

namespace ProjectCatMan
{
    public class SeeableFoward : ISeeable
    {
        public SeeableFoward(UnitBase unit,float sight)
        {
            this.unit = unit;
            this.transform = unit.transform;
            this.sight = sight;
        }

        public UnitBase unit { get; private set; }
        public Transform transform { get; private set; }
        public float sight { get; private set; }

        private GameObject currentObj;
        public GameObject current
        {
            get { return currentObj; }
        }
        public UnitBase currentSeeingUnit
        {
            get { return currentObj.GetComponent<UnitBase>(); }
        }

        public bool seeingNothing
        {
            get
            {
                return current == null;
            }
        }

        public void Seeing()
        {
            currentObj = RayManager.hitObj(transform.position,transform.right,sight);
            return;
        }

        public override string ToString()
        {
            return "SeeableFoward";
        }
    }
}