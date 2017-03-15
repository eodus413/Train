using UnityEngine;

namespace ProjectCatMan
{
    public class UnSeeable : ISeeable
    {
        public UnSeeable(UnitBase unit)
        {
            this.unit = unit;
        }

        public GameObject current
        {
            get { return null; }
        }
        public UnitBase currentSeeingUnit
        {
            get { return null; }
        }

        public UnitBase unit { get; private set; }
        public bool seeingNothing
        {
            get
            {
                return true;
            }
        }

        public void Seeing()
        {
            return;
        }
        public override string ToString()
        {
            return "UnSeeable";
        }
    }
}