using UnityEngine;

namespace ProjectCatMan
{
    public abstract class SeeableToRaycast : ISeeable
    {
        public SeeableToRaycast(UnitBase unit, float sight, int detectLayerMask, int denyLayerMask = 0)
        {
            this.unit = unit;
            this.transform = unit.transform;
            this.sight = sight;
            this.detectLayerMask = detectLayerMask;
            this.denyLayerMask = denyLayerMask;
        }
        public UnitBase unit { get; private set; }
        public Transform transform { get; private set; }
        public float sight { get; private set; }
        public int detectLayerMask { get; private set; }
        public int denyLayerMask { get; private set; }


        private GameObject currentObj;
        public GameObject current
        {
            get { return currentObj; }
        }
        public UnitBase currentSeeingUnit
        {
            get { return currentObj.GetComponent<UnitBase>(); }
        }
        public bool Nothing()
        {
            return current == null;
        }
        public abstract void Seeing();

        public void DoRaycast(Vector3 direction)
        {
            currentObj = RayManager.hitObj(transform.position, direction, sight, detectLayerMask);

            if (currentObj == null) return;

            if (currentObj.layer == Layers.ToValue(denyLayerMask))
            {
                currentObj = null;
            }
        }


        public override string ToString()
        {
            return "SeeableToRaycast";
        }
    }
}