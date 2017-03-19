using UnityEngine;

namespace ProjectCatMan
{
    public interface ITargeting
    {
        Transform center { get; }

        float range { get; }
        GameObject target { get; }
    }
    public class TargetingToRaycast : ITargeting
    {
        public TargetingToRaycast(Transform center, float range,int detectLayerMask,int denyLayerMask)
        {
            detectLayerMask += denyLayerMask;
            this.center = center;
            this.range = range;
        }
        
        public Transform center { get; private set; }

        public float range { get; private set; }
        public GameObject target
        {
            get
            {
                GameObject hitObj = RayManager.hitObj(center.position, center.right, range,detectLayerMask);

                if (hitObj.layer == denyLayerMask) return null;

                return hitObj;
            }
        }



        int detectLayerMask;
        int denyLayerMask;

    }
}