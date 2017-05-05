using UnityEngine;
using System.Collections;

namespace Weapon.Projectile
{
    using Entity;
    using LayerManager;
    public class Bullet : MonoBehaviour
    {
        EntityBase owner;
        int damage;
        Vector2 direction;
        float speed;

        public void Fire(EntityBase owner, int damage, Vector2 direction,float speed)
        {
            this.owner = owner;
            this.damage = damage;
            this.direction = direction;
            this.speed = speed;
            StartCoroutine(Move());
        }
        IEnumerator Move()
        {
            while(true)
            {
                transform.Translate(direction * speed);
                yield return new WaitForFixedUpdate();
            }
        }
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.IsTouchingLayers(owner.entityType.GetEnemyLayerMask()))
            {
                other.GetComponent<EntityBase>().Attacked(new AttackData(owner,damage,direction));
            }
        }
    }
}