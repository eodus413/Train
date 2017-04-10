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
            get { return Vector2.Distance(target.transform.position, origin.position); }
        }

        public GameObject Targeting()
        {
            target = Ray2DManager.CastObject(origin.position, direction, sightRange, detect, deny); ;
            return target;
        }
        public void Release()
        {
            target = null;
        }

        //구현
        private LayerMask detect { get; set; }
        private LayerMask deny { get; set; }

        protected virtual Vector3 direction
        {
            get { return origin.right; }
        }
    }
    public class TargetingToLookDirection : TargetingByRaycast
    {
        public TargetingToLookDirection(Transform origin, float sightRange, LayerMask detect, LayerMask deny, EntityBase owner)
        : base(origin, sightRange, detect, deny)
        {
            this.owner = owner;
        }
        public TargetingToLookDirection(Transform origin, float sightRange, EntityType type, LayerMask deny, EntityBase owner)
            :base(origin,sightRange,type,deny)
        {
            this.owner = owner;
        }

        private EntityBase owner;
        protected override Vector3 direction
        {
            get
            {
                return owner.lookDirection;
            }
        }
    }
}