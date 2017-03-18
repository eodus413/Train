using UnityEngine;

namespace ProjectCatMan
{
    public class UnSeeable : ISeeable
    {
        public UnSeeable(UnitBase unit,float sight = 0f)
        {
            this.unit = unit;
            this.sight = sight;
        }
       
        public float sight { get; private set; }
        public GameObject current
        {
            get { return null; }
        }
        public UnitBase currentSeeingUnit
        {
            get { return null; }
        }

        public UnitBase unit { get; private set; }
        public bool Nothing()
        {
            return false;   
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