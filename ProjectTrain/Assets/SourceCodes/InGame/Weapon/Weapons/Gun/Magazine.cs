namespace Weapon
{
    using Projectile;
    using UnityEngine;
    using ObjectPool;
    using System.Collections.Generic;
    public class Magazine : GameObjectPool
    {
        public Magazine(Gun gun,GameObject prefab) : base(prefab, 5, null, true)
        {
            this.gun = gun;
            int count = pool.Count;
            for(int i=0;i<count;++i)
            {
                AddBullet(pool[i]);
            }
        } 

        private Gun gun;
        private List<Bullet> bulletList = new List<Bullet>();

        private Bullet AddBullet(GameObject bulletObj)
        {
            Bullet newBullet = bulletObj.GetComponent<Bullet>();
            bulletList.Add(newBullet);
            newBullet.Initialize(gun.owner,gun);
            return newBullet;
        }

        public Bullet GetBullet()
        {
            Bullet bullet = null;
            int count = pool.Count;

            for (int i = 0; i < count; ++i)
            {
                if (!bulletList[i].gameObject.activeInHierarchy)
                {
                    bullet = bulletList[i];
                }
            }
            if (isGrow) bullet = AddBullet(AddObject(poolingPrefab));
            if (bullet)
            {
                bullet.gameObject.SetActive(true);
                return bullet;
            }
            else
            {
                return null;
            }
        }
    }
}