using UnityEngine;
using LayerManager;

namespace Raycast2DManager
{
    public static class Ray2DManager
    {
        static RaycastHit2D hit;
        static Transform Raycast(Vector2 origin, Vector2 direction, float distance , LayerMask layerMask)
        {
            hit = Physics2D.Raycast(origin, direction, distance, layerMask);
            if (hit) Debug.DrawLine(origin, hit.point, Color.red, 1f);
            else Debug.DrawRay(origin, direction, Color.blue, 1f);

            return hit.transform;
        }
        static Transform Raycast(Vector2 origin, Vector2 direction, float distance)
        {
            hit = Physics2D.Raycast(origin, direction, distance);
            if(hit) Debug.DrawLine(origin, hit.point, Color.red, 1f);
            else Debug.DrawRay(origin,direction, Color.blue, 1f);

            return hit.transform;
        }

        public static GameObject CastObject(Vector2 origin,Vector2 direction,float distance , LayerMask detectMask,LayerMask denyMask)
        {
            Transform hit = Raycast(origin, direction, distance, detectMask + denyMask);
            Debug.Log(direction);
            if (hit == null) return null;

            bool isDenyLayer = (Layers.ToMask(hit.gameObject.layer) & denyMask) > 0;
            if (isDenyLayer) return null;

            return hit.gameObject;
        }
        public static GameObject CastObject(Transform transform, float distance, LayerMask detectMask, LayerMask denyMask)
        {
            Transform hit = Raycast(transform.position, transform.right, distance, detectMask + denyMask);

            if (hit == null) return null;

            bool isDenyLayer = (Layers.ToMask(hit.gameObject.layer) & denyMask) > 0;
            if (isDenyLayer) return null;

            return hit.gameObject;
        }
        public static GameObject CastObject(Transform transform, float distance)
        {
            Transform hit = Raycast(transform.position, transform.right, distance);
            
            return hit.gameObject;
        }
    }
}