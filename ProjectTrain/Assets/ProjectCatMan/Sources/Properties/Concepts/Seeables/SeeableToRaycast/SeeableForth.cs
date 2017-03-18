using UnityEngine;

namespace ProjectCatMan
{
    public class SeeableForth : SeeableToRaycast
    {
        public SeeableForth(UnitBase unit,float sight,int detectLayerMask,int denyLayerMask = 0) :
            base(unit,sight,detectLayerMask,denyLayerMask)
        {
        }

        public override void Seeing()
        {
            DoRaycast(transform.right);
        }

        public override string ToString()
        {
            return "SeeableFoward";
        }
    }
}