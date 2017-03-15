namespace ProjectCatMan
{
    public interface IDamageable : IUnitProperty
    {
        int hp { get; }
        int armor { get; }
        void Damage(IDamageData damageTaken);
    }
}