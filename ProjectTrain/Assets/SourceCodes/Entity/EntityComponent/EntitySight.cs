using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Raycast2DManager;

namespace Entity
{
    public class EntitySight : EntityComponent
    {
        [SerializeField]
        private float _distance;
        public float distance
        {
            get { return _distance; }
            set
            {
                if (value < 0) return;
                _distance = value;
            }
        }
        
        [SerializeField]
        LayerMask _detect;
        public int detect
        {
            get { return _detect; }
        }
        [SerializeField]
        LayerMask _deny;
        public int deny
        {
            get { return _deny; }
        }

        public GameObject target { get; private set; }

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

        public void Seeing()
        {
            target = Ray2DManager.CastObject( transform.position, transform.right,distance,LayerManager.Layers.PlayerMask,deny);
        }
    }
}