using UnityEngine;

namespace ProjectTrain
{
    public class AttackData
    {
        public int damage { get; private set; }
        public Vector2 direction { get; private set; }
        public Unit attacker { get; private set; }
        public void Set(int damge,Vector2 direction,Unit attacker)
        {
            this.damage = damage;
            this.direction = direction;
            this.attacker = attacker;
        }
        public AttackData(int damage,Vector2 direction,Unit attacker)
        {
            this.damage = damage;
            this.direction = direction;
            this.attacker = attacker;
        }
    }
}