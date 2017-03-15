namespace ProjectCatMan
{
    public class DamageableHarder : IDamageable
    {
        public DamageableHarder(UnitBase unit,int hp,int armor)
        {
            this.unit = unit;
            this.hp = hp;
            this.armor = armor;
        }
        public UnitBase unit { get; private set; }
        public int armor { get; private set; }
        public int hp { get; private set; }
        public void Damage(IDamageData damageTaken)
        {
            int damaged = (int)((float)damageTaken.damage * 0.5f);
            armor -= damaged;
            if (armor < 0) return;

            hp -= damaged;
        }
    }
}