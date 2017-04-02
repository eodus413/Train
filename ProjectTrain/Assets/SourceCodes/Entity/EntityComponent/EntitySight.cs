using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Raycast2DManager;

namespace Entity
{
    public abstract class EntitySight
    {
        public EntitySight(Transform transform,float distance)
        {
            this.transform = transform;
            this.distance = distance;
            this.target = null;
        }

        public float distance { get; private set; }
        public Transform transform { get; private set; }

        public void SetTarget(GameObject target)
        {
            if (target == null) return;
            this.target = target;
        }
        public GameObject target { get; private set; }
        public void ReleaseTarget()
        {
            target = null;
        }
        public bool targetIsInSight
        {
            get
            {
                if (target == null) return false;

                return DistanceToTarget <= distance;
            }
        }
        public float DistanceToTarget
        {
            get
            {
                return Vector3.Distance(target.transform.position, transform.position);
            }
        }
        public abstract void Seeing();
        
        public Direction lookDirection { get; private set; }
        public void LookAt(Direction direction)
        {
            lookDirection = direction;
            transform.Turn2D(direction);
        }

    }
    public class MonsterSight : EntitySight
    {
        public MonsterSight(Transform transform, float distance, LayerMask detect, LayerMask deny) : base(transform,distance)
        {
            this.detect = detect;
            this.deny = deny;
        }

        public LayerMask detect { get; private set; }
        public LayerMask deny { get; private set; }
        public override void Seeing()
        {
            GameObject hitObj = Ray2DManager.CastObject(transform.position, transform.right, distance, LayerManager.Layers.PlayerMask, deny);
            SetTarget(hitObj);
        }
    }
    public class PlayerSight : EntitySight
    {
        public PlayerSight(Transform transform,float distance) : base(transform,distance)
        {

        }
        public override void Seeing()
        {
        }
    }
}