namespace Weapon.Projectile
{
    using UnityEngine;
    using System.Collections.Generic;

    public static class ProjectileManager
    {
        public static List<ProjectileBase> projectileList = new List<ProjectileBase>();

        public static Transform parent = new GameObject("Projectiles").transform;

        public static void Add(ProjectileBase projectile)
        {
            if (projectile == null) return;

            projectile.transform.SetParent(parent);
            projectileList.Add(projectile);
        }

    }
}