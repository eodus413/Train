using UnityEngine;
using SingletonManager;

namespace ProjectCatMan
{
    public struct RayData
    {
        public RayData(Vector2 origin,Vector2 direction, float distance, int detectLayerMask = -1,int denyLayerMask = 0)
        {
            this.origin = origin;
            this.direction = direction;
            this.distance = distance;
            this.detectLayerMask = detectLayerMask;
            this.denyLayerMask = denyLayerMask;
        }

        public Vector2 origin;
        public Vector2 direction;
        public float distance;
        public int detectLayerMask;
        public int denyLayerMask;
    }

    public static class RayManager
    {
        static Color color = Color.red;
        static RaycastHit2D hit;

        public static GameObject hitObj(RayData data)
        {
            hit = Physics2D.Raycast(data.origin, data.direction, data.distance, data.detectLayerMask);
            Debug.DrawRay(data.origin, data.direction, color);

            if (!hit) return null;
            GameObject hitObj = hit.transform.gameObject;

            if (hitObj.layer == data.denyLayerMask) return null;


            return hitObj;
        }
        public static RayData New(Vector3 origin,Vector3 direction,float distance,int detect,int deny)
        {
            return new RayData(origin, direction, distance, detect, deny);
        }
    } 
}