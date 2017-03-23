using UnityEngine;

namespace ProjectCatMan
{
    public interface IAttackable : IUnitProperty
    {
        int hp { get; }
        int armor { get; }
        Transform transform { get; }

        void BeAttacked(AttackData damageTaken);
    }

    public class AttackableHarder : IAttackable
    {
        public AttackableHarder(int hp, int armor, UnitBase unit, bool isEnemy)
        {
            this.hp = hp;
            this.armor = armor;

            this.isEnemy = isEnemy;
            this.unit = unit;
        }
        
        public int hp { get; private set; }
        public int armor { get; private set; }
        public Transform transform
        {
            get { return unit.transform; }
        }

        public void BeAttacked(AttackData damageTaken)
        {
            int damaged = (int)((float)damageTaken.damage * 0.5f);
            armor -= damaged;
            if (armor < 0) return;

            hp -= damaged;
        }

        public bool isEnemy { get; private set; }
        public UnitBase unit { get; private set; }
        public override string ToString()
        {
            return "AttackableHarder";
        }
    }

    public class AttackableUnit : IAttackable
    {
        public AttackableUnit(int hp, int armor, UnitBase unit)
        {
            this.hp = hp;
            this.armor = armor;

            this.unit = unit;
        }

        public int hp { get; private set; }
        public int armor { get; private set; }
        public Transform transform
        {
            get { return unit.transform; }
        }

        public void BeAttacked(AttackData damageTaken)
        {
            hp -= damageTaken.damage;
        }

        public UnitBase unit { get; private set; }
        public override string ToString()
        {
            return "AttackableUnit";
        }
    }
}