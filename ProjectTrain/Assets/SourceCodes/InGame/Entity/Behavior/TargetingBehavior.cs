using UnityEngine;

namespace Entity
{
    public abstract class TargeitngBase
    {
        //생성자
        public TargeitngBase(Transform basePoint)
        {
            this.basePoint = basePoint;
        }
        //멤버
        public Transform basePoint { get; private set; }

        //인터페이스
        public abstract EntityBase target { get; }

        public bool noTarget { get { return target == null; } }          //타겟이 있는지 여부
        public float distanceToTarget //타겟과의 거리
        {
            get
            {
                if (noTarget) return float.Epsilon;
                return Vector2.Distance(target.transform.position, basePoint.position);
            }
        }


        public abstract GameObject Targeting();
    }
}

namespace Entity
{
    using Raycast2DManager;
    using LayerManager;
    using System;

    public partial class TargetingWithRaycast : TargeitngBase
    {
        public TargetingWithRaycast(Transform basePoint,float targetingRange,LayerMask detectMask,LayerMask denyMask) : base(basePoint)
        {
            this.targetingRange = targetingRange;
            this.detectMask = detectMask;
            this.denyMask = denyMask;
        }

        //멤버
        private float targetingRange;
        private LayerMask detectMask;
        private LayerMask denyMask;

        private EntityBase _target;
        //인터페이스
        public override EntityBase target
        {
            get { return _target; }
        }

        public override GameObject Targeting()
        {
            GameObject entityObj = Ray2DManager.StartCasting(basePoint, targetingRange, detectMask, denyMask);

            if (entityObj == null) return null;

            _target = entityObj.GetComponent<EntityBase>();
            return entityObj;
        }
    }
}

namespace Entity
{
    public partial class TargetingWithTrigger : TargeitngBase
    {
        public TargetingWithTrigger(Transform basePoint, float targetingRange, LayerMask detectMask, LayerMask denyMask,Collider2D trigger = null) : base(basePoint)
        {
            if(trigger == null)
            {
                trigger = basePoint.gameObject.AddComponent<CircleCollider2D>();
                trigger.isTrigger = true;
            }
        }

        //멤버        
        private LayerMask detectMask;
        private LayerMask denyMask;
        
        private Collider2D trigger;
        private EntityBase _target;

        //인터페이스
        public override EntityBase target
        {
            get { return _target; }
        }

        public override GameObject Targeting()
        {
            return _target.gameObject;
        }

    }
}