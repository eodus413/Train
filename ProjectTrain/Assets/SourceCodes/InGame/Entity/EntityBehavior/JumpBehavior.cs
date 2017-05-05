using UnityEngine;

namespace Entity
{
    public partial class JumpBehavior
    {
        //생성자
        public JumpBehavior(Transform transform,float jumpVelocity)
        {
            Initialize(transform, transform.GetComponent<Rigidbody2D>(), jumpVelocity);
        }
        public JumpBehavior(Transform transform,Rigidbody2D rigidbody, float jumpVelocity)
        {
            Initialize(transform,rigidbody,jumpVelocity);
        }
        void Initialize(Transform transform, Rigidbody2D rigidbody, float jumpVelocity)
        {
            this.jumpVelocity = jumpVelocity;
            this.transform = transform;
            this.rigidbody = rigidbody;
            
            this.rayDirection = Vector2.down;
            this.rayLenght = 0.1f;
        }

        Transform transform;
        Rigidbody2D rigidbody;

        float jumpVelocity;
        public void Jump()
        {
            if (isInAir) return;

            rigidbody.AddForce(Vector2.up * jumpVelocity);
        }
    }
}

namespace Entity
{
    using Raycast2DManager;
    using LayerManager;
    public partial class JumpBehavior
    {
        Vector2 rayDirection;
        float rayLenght;

        public bool isInAir
        {
            get
            {
                return Ray2DManager.StartCasting(transform.position,rayDirection,rayLenght, Layers.GroundMask) == null;
            }
        }
    }
}
