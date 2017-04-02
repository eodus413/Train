using UnityEngine;

namespace Entity
{
    public class EntityComponent : MonoBehaviour
    {
        public void Initialize(EntityBase baseEntity)
        {
            this.baseEntity = baseEntity;
        }
        public EntityBase baseEntity { get; private set; }
    }
}
