using UnityEngine;
using Entity;
using Raycast2DManager;

namespace Weapon
{
    public enum WeaponType
    {
        Gun,
        Sword
    }
    public interface IWeapon
    {
        WeaponType weaponType { get; }

        bool isReadyForAttack { get; }

        int damage { get; }
        float startDelay { get; }
        float cooltime { get; }

        EntityBase owner { get; }

        void Attack();
    }
}