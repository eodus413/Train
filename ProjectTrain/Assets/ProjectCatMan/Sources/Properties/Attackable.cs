using UnityEngine;

namespace ProjectCatMan
{
    public interface IAttackable 
    {
        int value { get; }

        void Attacked(AttackData data);
    }
    

    public class Health : IAttackable
    {
        public Health(int hp)
        {
            this.value = hp;
        }
        
        public int value { get; private set; }

        public void Attacked(AttackData data)
        {
            value -= data.damage;
        }
    }
    public class Durabilty : IAttackable
    {
        public Durabilty(int durabilty)
        {
            this.value = durabilty;
        }
        public int value { get; private set; }

        public void Attacked(AttackData data)
        {
            value -= data.damage;
        }
    }
}