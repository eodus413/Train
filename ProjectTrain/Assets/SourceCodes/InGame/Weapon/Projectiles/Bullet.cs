using UnityEngine;
using System.Collections;

namespace Weapon.Projectile
{
    using Entity;
    using LayerManager;
    public class Bullet : MonoBehaviour
    {
        const float bulletDefaultSpeed = 5f;
        const float bulletLifeTime = 2f;
        public void Initialize(EntityBase owner, Gun gun)
        {
            this.owner = owner;
            this.gun = gun;

            gameObject.layer = Layers.Bullet;
            Collider2D col = GetComponent<Collider2D>();
            if (col == null) col = gameObject.AddComponent<CircleCollider2D>();
            col.isTrigger = true;

            speed = bulletDefaultSpeed;
        }

        EntityBase owner;
        Gun gun;
        Vector2 direction;
        float speed;
        
        public void Fire()
        {
            this.direction = owner.lookDirection;
            transform.position = gun.shotPoint.position;
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
            gameObject.SetActive(false);
        }
        IEnumerator LifeTime()
        {
            yield return new WaitForSeconds(bulletLifeTime);
            isMoving = false;
        }
        void OnTriggerEnter2D(Collider2D other)
        {
            isMoving = false;
            if (other.gameObject.layer == (Layers.Entities))
            {
                Attack.To(other.GetComponent<EntityBase>(), new AttackData(owner, gun.damage, direction));
            }
        }
    }
}