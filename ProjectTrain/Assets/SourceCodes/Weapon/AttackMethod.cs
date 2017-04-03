using UnityEngine;
using Raycast2DManager;
using Entity;
namespace Weapon
{
    public interface IAttackMethod
    {
        int damage { get; }
        void Attack();
    }
    public class AttackToRaycast : IAttackMethod
    {
        public AttackToRaycast(EntityBase entity,Transform transform, float distance,LayerMask detect,LayerMask deny,int damage)
        {
            this.entity = entity;
            this.transform = transform;
            this.distance = distance;
            this.detect = detect;
            this.deny = deny;

            this.damage = damage;
        }

        public int damage { get; private set; }
        public void Attack()
        {
            GameObject hitObj = Ray2DManager.CastObject(transform.position, entity.lookDirection, distance,detect,deny);

            if (hitObj == null) return;
            EntityBase targetEntity = hitObj.GetComponent<EntityBase>();

            targetEntity.Attacked(damage);
        }

        EntityBase entity;
        Transform transform;
        float distance;
        LayerMask detect;
        LayerMask deny;
    }
}