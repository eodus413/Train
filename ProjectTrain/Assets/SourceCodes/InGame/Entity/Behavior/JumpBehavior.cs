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
            this.jumpVelocity =  Vector2.up * jumpVelocity;
            this.transform = transform;
            this.rigidbody = rigidbody;
        }
    }
}

namespace Entity
{
    using Raycast2DManager;
    using LayerManager;
    public partial class JumpBehavior
    {
        //멤버 데이터
        Transform transform;        //타겟 Transform
        Rigidbody2D rigidbody;      //타겟 Rigidbody
        
        Vector2 jumpVelocity;

        Vector2 rayDirection = Vector2.down;
        const float raycastLenght = 0.03f;
        //인터페이스
        public void Jump()
        {
            if (isInAir) return;

            rigidbody.AddForce(jumpVelocity);
        }

        public bool isInAir
        {
            get { return Ray2DManager.StartCasting(transform.position,rayDirection,raycastLenght, Layers.GroundMask) == null; }
        }
    }
}
