using UnityEngine;
using System.Collections;

namespace Weapon.Projectile
{
    using Entity;
    using LayerManager;
    public partial class Bullet : ProjectileBase
    {
        public AmmoType type { get; private set; }
        EntityBase owner;


        bool isAttacking = false;
        const float speed = 5f;
        public const float lifeTIme = 2f;
        public virtual void Initialize(EntityBase owner, Gun gun)
        {
            type = gun.ammoType;

            this.owner = owner;
            this.gun = gun;

            gameObject.layer = Layers.Bullet;
            Collider2D col = GetComponent<Collider2D>();
            if (col == null) col = gameObject.AddComponent<BoxCollider2D>();
            col.isTrigger = true;
        }

        Gun gun;
        Vector2 direction;
        public virtual void Fire(Vector2 direction)
        {
            isAttacking = false;

            StartCoroutine(LifeTime());
            
            gameObject.Turn2D(direction);
            this.direction = direction;

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
                yield return null;
            }
            gameObject.SetActive(false);
        }
        IEnumerator LifeTime()
        {
            yield return new WaitForSeconds(lifeTIme);
            isMoving = false;
        }


        void OnTriggerEnter2D(Collider2D other)
        {
            if (isAttacking) return;
            if (other.gameObject == owner.gameObject) return;

            if (other.gameObject.layer == Layers.Entities)
            {
                EntityBase target = other.GetComponent<EntityBase>();
                if (target.team != owner.team)
                {
                    isAttacking = true;
                    Attack.To(target, new AttackData(owner, target, gun.damage, direction));
                    gameObject.SetActive(false);
                }
            }
            else if (other.gameObject.layer == Layers.Ground)
            {
                isMoving = false;
            }
        }
    }
}