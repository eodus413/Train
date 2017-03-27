using UnityEngine;

//ISee의 인터페이스는 보는 방법을 제시한다.
//1. Raycast
namespace ProjectCatMan
{
    public interface ISee
    {
        Vector3 direction { get; }
        float sight { get; }

        GameObject current { get; }
        UnitBase currentSeeingUnit { get; }

        Transform transform { get; }

        bool Nothing();

        void Seeing();
    }

    #region SeeableToRaycast
    public class SeeFoward : ISee
    {
        public SeeFoward(Transform transform,float sight,int detectMask,int denyMask)
        {
            this.sight = sight;
            this.transform = transform;

            this.detectMask = detectMask;
            this.denyMask = denyMask;
        }
                
        public Vector3 direction { get { return transform.right; } }
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
        public void Seeing()
        {
            RayData data = new RayData(transform.position, direction, sight, detectMask, denyMask);
            current = RayManager.hitObj(data);
            
        }

        public readonly int detectMask;
        public readonly int denyMask;
        public override string ToString()
        {
            return "SeeToRaycast";
        }
    }

    #endregion

    public class SeeMouse : ISee
    {
        public SeeMouse(Transform transform)
        {
            this.transform = transform;
        }
        
        public Vector3 direction { get; private set; }
        public float sight
        {
            get { return 0; }
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
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Direction location = transform.LocationOf(mousePos);

            direction = location.DirToVec3();
        }
    }
    
    //볼 수 없는
    public class CantSee : ISee
    {
        public CantSee(Transform transform)
        {
            this.transform = transform;
        }

        public Vector3 direction
        {
            get { return Vector3.zero; }
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