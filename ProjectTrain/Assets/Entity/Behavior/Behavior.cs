namespace Entity.Behavior
{
    public interface IBehavior
    {
        
    }

}
namespace Entity.Behavior
{
    public class AttackBehavior : IBehavior
    {
        public void Attack(IAttackable attackable)  //공격
        {
            attackable.Attacked(damage);
        }
        public DamageData damage { get; private set; }
    }
}