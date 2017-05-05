using UnityEngine;
using System.Collections;

namespace Weapon.Projectile
{
    using Entity;
    using LayerManager;
    public class Bullet : MonoBehaviour
    {
        public void Initialize()
        {
            gameObject.layer = Layers.Bullet;
            Collider2D col = GetComponent<Collider2D>();
            if (col == null) col = gameObject.AddComponent<CircleCollider2D>();
            col.isTrigger = true;
        }

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
        bool isMoving;
        IEnumerator Move()
        {
            isMoving = true;
            Vector2 moveVector = direction * speed;
            while (isMoving)
            {
                transform.Translate(moveVector * Time.deltaTime);
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