using UnityEngine;

namespace ProjectTrain
{
    public class Targeting
    {
        protected GameObject _target { get; set; }
        protected Transform owner { get; private set;}


        public float sight { get; private set; }
        
        LayerMask mask;             //Targeting 할 layer
        LayerMask denyMask;         
        GameObject hitobj;
        RaycastHit2D hit;

        public void Execute(Vector2 direction)  
        {
            hit = Physics2D.Raycast(owner.position, direction,sight, mask);
            Debug.DrawRay(owner.position, direction, Color.red);

            if (!hit) return;

            hitobj = hit.transform.gameObject;

            if (hitobj == null) return;
            if (hitobj.layer == Layers.ToValue(denyMask)) return;

            _target = hitobj;
        }
        
        public GameObject target
        {
            get
            {
                if (_target == null) return null;

                if (TargetIsInSight() == false) _target = null;
                
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
        public Direction ReactivePosition()
        {
            return target.RelativeDirection(owner.gameObject);
        }
        public float DistanceToTarget()
        {
            return Vector2.Distance(_target.transform.position, owner.position);
        }
        public virtual bool TargetIsInSight()
        {
            return DistanceToTarget() < sight;
        }
        public Targeting(Transform owner, LayerMask mask, LayerMask denyMask,float sight)
        {
            this.owner = owner;
            this.mask = mask + denyMask;

            this.denyMask = denyMask;
            this.sight = sight;
        }
    }
}