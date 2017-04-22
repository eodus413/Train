using UnityEngine;
using Raycast2DManager;

namespace LineRenderer2D
{
    public class LineObject
    {
        Transform center;
        float distance;
        LineRenderer renderer;

        public LineObject(GameObject gameObject,float distance)
        {
            renderer = gameObject.AddComponent<LineRenderer>();
            renderer.enabled = false;
            renderer.useWorldSpace = true;
            center = gameObject.transform;

            this.distance = distance;
        }
        public void Render()
        {
            GameObject hitObj = Ray2DManager.StartCasting(center,distance);
            
        }
    }
}