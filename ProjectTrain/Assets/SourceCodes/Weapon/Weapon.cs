using UnityEngine;
using Entity;
using Raycast2DManager;

namespace Weapon
{
    public interface IWeapon
    {
        IAttackMethod attackMethod { get; }

        bool isReadyForAttack { get; }

        int damage { get; }
        float attackRange { get; }
        float attackDelay { get; }

        EntityBase owner { get; }

        void Attack();
    }
}