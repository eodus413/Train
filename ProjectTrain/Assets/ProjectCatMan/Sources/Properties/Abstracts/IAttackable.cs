namespace ProjectCatMan
{
    public interface IAttackable
    {
        IDamageData damageData { get; }
        void Attack(IDamageable attackDamage);
    }
}