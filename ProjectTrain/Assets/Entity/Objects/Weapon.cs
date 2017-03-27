using Entity.Behavior;

namespace Entity.Object
{
    public abstract class Weapon
    {
        public Weapon(AttackBehavior attackBehavior)
        {
            this.attackBehavior = attackBehavior;
        }
        public AttackBehavior attackBehavior { get; private set; }
    }

    public class Axe : Weapon
    {
    }

}