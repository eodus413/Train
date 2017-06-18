namespace Weapon.Projectile
{
    using UnityEngine;
    public class ProjectileBase : MonoBehaviour
    {
        void Awake()
        {
            ProjectileManager.Add(this);
        }
    }
}