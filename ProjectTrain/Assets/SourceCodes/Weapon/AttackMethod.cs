//using UnityEngine;
//using Raycast2DManager;
//using Entity;
//namespace Weapon
//{
//    public interface IAttackMethod
//    {
//        int damage { get; }
//        void Attack();
//    }
//    public class AttackToRaycast : IAttackMethod
//    {
//        public AttackToRaycast(EntityBase entity,Transform shotPoint, float distance,LayerMask detect,LayerMask deny,int damage)
//        {
//            this.entity = entity;
//            this.shotPoint = shotPoint;
//            this.distance = distance;
//            this.detect = detect;
//            this.deny = deny;
//            this.damage = damage;
//        }

//        public int damage { get; private set; }
//        public void Attack()
//        {
//            GameObject hitObj = Ray2DManager.CastObject(shotPoint.position, entity.lookDirection, distance,detect,deny);

//            if (hitObj == null) return;
//            EntityBase targetEntity = hitObj.GetComponent<EntityBase>();

//            if (targetEntity == null) return;

//            targetEntity.Attacked(new AttackData(entity,1,Direction.zero));
//        }

//        EntityBase entity;
//        Transform shotPoint;
//        float distance;
//        LayerMask detect;
//        LayerMask deny;
//    }
//}