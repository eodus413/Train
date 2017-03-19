using UnityEngine;

namespace ProjectCatMan
{
    public class AttackData
    {
        public AttackData(UnitBase attacker, int damage)
        {
            this.attacker = attacker;
            this.damage = damage;
        }
        public UnitBase attacker { get; private set; }
        public int damage { get; private set; }
        public Vector3 direction { get; private set; }
    }
}