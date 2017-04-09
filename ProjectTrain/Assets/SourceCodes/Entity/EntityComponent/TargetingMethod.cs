using UnityEngine;
using Raycast2DManager;
using LayerManager;

namespace Entity
{
    public interface ITargetingMethod
    {
        GameObject target { get; }

        Transform origin { get; }
        float sightRange { get; }   //시야 범위
        float distanceToTarget { get; }

        GameObject Targeting();
        void Release();
    }
    
    public class TargetingByRaycast : ITargetingMethod
    {
        //생성자
        public TargetingByRaycast(Transform origin, float sightRange, LayerMask detect, LayerMask deny)
        {
            this.origin = origin;
            this.sightRange = sightRange;
            this.detect = detect;
            this.deny = deny;
        }
        public TargetingByRaycast(Transform origin,float sightRange,EntityType type,LayerMask deny)
        {
            this.origin = origin;
            this.sightRange = sightRange;
            this.detect = type.GetEnemyLayerMask();
            this.deny = deny;
        }

        //인터페이스
        public GameObject target { get; private set; }

        public Transform origin { get; private set; }
        public float sightRange { get; private set; }
        public float distanceToTarget
        {
            get { return distance; }
        }

        public GameObject Targeting()
        {
            GameObject hitObj = Ray2DManager.CastObject(origin.position, direction, sightRange, detect, deny);

            return hitObj;
        }
        public void Release()
        {
            target = null;
        }

        //구현
        private LayerMask detect { get; set; }
        private LayerMask deny { get; set; }

        protected virtual Direction direction
        {
            get { return origin.right; }
        }
        protected virtual float distance
        {
            get { return Vector2.Distance(target.transform.position, origin.position); }
        }
    }

    //GroundMask 빼고 Raycast
    public class TargetingBlockedToGround : TargetingByRaycast
    {
        //생성자
        public TargetingBlockedToGround(Transform origin, float sightRange, LayerMask detect)
            : base(origin, sightRange, detect, Layers.GroundMask)
        {
        }
        public TargetingBlockedToGround(Transform origin,float sightRange,EntityType type)
            : base(origin,sightRange,type.GetEnemyLayerMask(),Layers.GroundMask)
        {

        }
    }

    public class TargetingDirection : TargetingByRaycast
    {
        //생성자
        public TargetingDirection(Transform origin, float sightRange, LayerMask detect, LayerMask deny,Direction lookDirection) : base(origin,sightRange,detect,deny)
        {
            _direction = lookDirection;
        }

        //구현
        Direction _direction;
        protected override Direction direction
        {
            get { return _direction; }
        }
    }
}