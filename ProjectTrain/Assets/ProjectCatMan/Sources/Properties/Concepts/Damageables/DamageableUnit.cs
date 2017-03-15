namespace ProjectCatMan
{
    public class DamageableUnit: IDamageable
    {
        public DamageableUnit(UnitBase unit,int hp,int armor)
        {
            this.unit = unit;
            this.hp = hp;
            this.armor = armor;
        }

        public int hp { get; private set; }
        public int armor { get; private set; }
        public UnitBase unit { get; private set; }
        public void Damage(IDamageData damageTaken)
        {
            hp -= damageTaken.damage;
        }
        public override string ToString()
        {
            return "DamageableUnit";
        }
    }
}