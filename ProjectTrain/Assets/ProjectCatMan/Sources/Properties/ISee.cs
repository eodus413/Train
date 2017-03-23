using UnityEngine;
namespace ProjectCatMan
{
    public interface ISee
    {
        Direction direction { get; }
        float sight { get; }

        GameObject current { get; }
        UnitBase currentSeeingUnit { get; }

        Transform transform { get; }

        bool Nothing();

        void Seeing();
    }

    #region SeeableToRaycast
    public abstract class SeeToRaycast : ISee
    {
        public SeeToRaycast(Transform transform)
        {
            this.transform = transform;

            this.sight = sight;
            this.detectLayerMask = detectLayerMask;
            this.denyLayerMask = denyLayerMask;
        }
                
        public Direction direction { get; private set; }
        public float sight { get; private set; }

        public GameObject current { get; private set; }
        public UnitBase currentSeeingUnit
        {
            get { return current.GetComponent<UnitBase>(); }
        }

        public Transform transform { get; private set; }

        public bool Nothing()
        {
            return current == null;
        }
        //ISee interface 서브 클래스에서 구현해야함
        public abstract void Seeing();
        
        
        public int detectLayerMask { get; private set; }
        public int denyLayerMask { get; private set; }

        public void DoRaycast(Vector3 direction)
        {
            current = RayManager.hitObj(RayManager.New);

            if (current == null) return;

            if (current.layer == Layers.ToValue(denyLayerMask))
            {
                current = null;
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
        public SeeForth(RayData data) : base(data)
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
    

    public class SeeTarget : ISee
    {
        public SeeTarget()
        {

        }

        public Direction direction
        {
            get
            {
                if (targeting.target == null) return Direction.None;
                
                Direction targetLocation = transform.LocationOf(targeting.target.transform);    //타겟을 바라봄
                return targetLocation;
            }
        }
        public float sight { get; private set; }

        public GameObject current { get; private set; }
        public UnitBase currentSeeingUnit { get; private set; }
        
        public Transform transform { get; private set; }

        public bool Nothing()
        {
            return current == null;
        }
        public void Seeing()
        {
            current = targeting.target;
        }

        ITargeting targeting;

    }

    //볼 수 없는
    public class CantSee : ISee
    {
        public CantSee(Transform transform)
        {
            this.transform = transform;
        }

        public Direction direction
        {
            get { return Direction.None; }
        }
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
        
        public Transform transform { get; private set; }

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