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
            hit = Physics2D.Raycast(owner.position, direction,sight,mask);
            
            if (!hit) return;
            
            hitobj = hit.transform.gameObject;

            if (hitobj == null) return;
            if (hitobj.layer == denyMask) return;
            _target = hitobj;

            return;
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
        public float DistanceToTarget()
        {
            return Vector2.Distance(_target.transform.position, owner.position);
        }
        public virtual bool TargetIsInSight()
        {
            return DistanceToTarget() < sight;
        }
        public Targeting(Transform owner, LayerMask mask,int denyMask,float sight)
        {
            this.owner = owner;
            this.mask = mask + Layers.ToMask(denyMask);
            this.denyMask = denyMask;
            this.sight = sight;
        }
    }
}