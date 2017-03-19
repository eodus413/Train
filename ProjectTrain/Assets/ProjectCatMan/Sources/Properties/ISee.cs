using UnityEngine;
namespace ProjectCatMan
{
    public interface ISee
    {
        float sight { get; }
        GameObject current { get; }
        UnitBase currentSeeingUnit { get; }

        bool Nothing();

        void Seeing();
    }

    #region SeeableToRaycast
    public abstract class SeeToRaycast : ISee
    {
        public SeeToRaycast(UnitBase unit, float sight, int detectLayerMask, int denyLayerMask = 0)
        {
            this.unit = unit;
            this.transform = unit.transform.GetChild(0); ;
            this.sight = sight;
            this.detectLayerMask = detectLayerMask;
            this.denyLayerMask = denyLayerMask;
        }
        public Transform eye { get; private set; }
        
        public float sight { get; private set; }
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


        private GameObject currentObj;  //current property의 반환 객체

        public UnitBase unit { get; private set; }
        public Transform transform { get; private set; }
        public int detectLayerMask { get; private set; }
        public int denyLayerMask { get; private set; }

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
            return "SeeToRaycast";
        }
    }
    // 앞을 보는
    public class SeeForth : SeeToRaycast
    {
        public SeeForth(UnitBase unit, float sight, int detectLayerMask, int denyLayerMask = 0) :
            base(unit, sight, detectLayerMask, denyLayerMask)
        {
        }

        public override void Seeing()
        {
            DoRaycast(transform.right);
        }

        public override string ToString()
        {
            return "SeeForth";
        }
    }

    #endregion
    //볼 수 없는
    public class CantSee : ISee
    {
        public float sight
        {
            get { return 0f; }
        }
        public GameObject current
        {
            get { return null; }
        }
        public UnitBase currentSeeingUnit
        {
            get { return null; }
        }
        
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
            return "CantSee";
        }
    }
}