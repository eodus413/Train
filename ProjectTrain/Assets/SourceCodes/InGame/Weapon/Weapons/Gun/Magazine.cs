namespace Weapon
{
    using Projectile;
    using UnityEngine;
    using ObjectPool;
    using System.Collections.Generic;
    public class Magazine
    {
        //생성자
        public Magazine(Gun gun)
        {
            this.gun = gun;

            bulletObjPool = new GameObjectPool(GetPrefab(gun.ammoType), (int)(Bullet.lifeTIme / gun.cooltime) + 1, null, true);

            int count = bulletObjPool.Lenght;
            for (int i = 0; i < count; ++i)
            {
                AddBullet(bulletObjPool.pool[i]);
            }
        }

        //인터페이스
        public Bullet GetBullet()
        {
            int i = -1;

            while (bulletList[++i].gameObject.activeInHierarchy) ;

            return bulletList[i];
        }
        public void Set(Gun gun)
        {
            this.gun = gun;
        }

        //구현
        private GameObjectPool bulletObjPool;
        private Gun gun;
        private List<Bullet> bulletList = new List<Bullet>();

        GameObject GetPrefab(AmmoType type)
        {
            return Resources.Load<GameObject>("Prefabs/Bullets/" + type.ToString());
        }

        Bullet AddBullet(GameObject bulletObj)
        {
            Bullet newBullet = bulletObj.GetComponent<Bullet>();
            bulletList.Add(newBullet);
            newBullet.Initialize(gun.owner, gun);
            return newBullet;
        }
    }
}