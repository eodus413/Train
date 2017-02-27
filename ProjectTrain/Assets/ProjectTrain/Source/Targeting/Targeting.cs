using UnityEngine;

namespace ProjectTrain
{
    public class Targeting
    {
        GameObject _target = null;
        private Transform owner;

        float sight;
        
        LayerMask mask;             //Targeting 할 layer
        GameObject hitobj;
        RaycastHit2D hit;

        public void Execute(Vector2 direction)
        {
            hit = Physics2D.Raycast(owner.position, direction,sight,mask);
            if (!hit) return;

            hitobj = hit.transform.gameObject;

            if (hitobj == null) return;

            _target = hitobj;

            return;
        }
        
        public GameObject target
        {
            get
            {
                if (_target == null) return null;

                if (DistanceToTarget() < sight)
                {
                    _target = null;
                }
                return _target;
            }
            private set
            {
                _target = value;
            }
        }
        public bool TargetIsLeft()
        {
            return _target.transform.position.x < owner.position.x;
        }
        public float DistanceToTarget()
        {
            return Vector2.Distance(_target.transform.position, owner.position);
        }
        public Targeting(Transform owner, LayerMask mask,float sight)
        {
            this.owner = owner;
            this.mask = mask;
            this.sight = sight;
        }
    }
}