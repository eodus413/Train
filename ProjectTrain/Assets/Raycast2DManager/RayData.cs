using UnityEngine;

namespace Raycast2DManager
{
    public struct Ray2DData
    {
        public Ray2DData(Vector2 origin, Vector2 direction, float distance = 1f, int detectMask = -1, int denyMask = 0)
        {
            this.origin = origin;
            this.direction = direction;
            this.distance = distance;
            this.detectMask = detectMask;
            this.denyMask = denyMask;
        }

        public Vector2 origin;
        public Vector2 direction;
        public float distance;
        public int detectMask;
        public int denyMask;
    }
}