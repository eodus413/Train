using UnityEngine;
using LayerManager;

namespace Raycast2DManager
{
    public static class Ray2DManager
    {
        static Transform Raycast(Vector2 origin, Vector2 direction, float distance , LayerMask layerMask)
        {
            Debug.DrawRay(origin, direction, Color.red,0.1f);
            return Physics2D.Raycast(origin, direction, distance, layerMask).transform;
        }

        public static GameObject CastObject(Vector2 origin,Vector2 direction,float distance , LayerMask detectMask,LayerMask denyMask)
        {
            Transform hit = Raycast(origin, direction, distance, detectMask + denyMask);
         
            if (hit == null) return null;

            bool isDenyLayer = (Layers.ToMask(hit.gameObject.layer) & denyMask) > 0;
            if (isDenyLayer) return null;

            return hit.gameObject;
        }
    }
}