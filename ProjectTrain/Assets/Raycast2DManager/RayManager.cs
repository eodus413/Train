using UnityEngine;
using SingletonManager;

namespace Raycast2DManager
{
    public static class Ray2DManager
    {
        #region Interface

        public static GameObject RayCasting(Ray2DData data)
        {
            RaycastHit2D hit = RayCastHit(data);
            Debug.DrawRay(data.origin, data.direction, color);

            if (!hit) return null;
            GameObject hitObj = hit.transform.gameObject;

            if (hitObj.layer == data.denyMask) return null;
            
            return hitObj;
        }

        #endregion




        static Color color = Color.red;

        static RaycastHit2D RayCastHit(Ray2DData data)
        {
            return Physics2D.Raycast(data.origin, data.direction, data.distance, data.detectMask);
        }

    }
}