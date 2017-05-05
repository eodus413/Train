namespace Entity
{
    using UnityEngine;
    public class MoveDirectionSetter : MonoBehaviour
    {
        [SerializeField]
        bool isLeft = false;
        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Monster"))
            {
                EntityBase entity = other.GetComponent<EntityBase>();
                if (isLeft) entity.Move(Direction.left);
                else entity.Move(Direction.right);
            }
        }
    }
}