namespace Entity
{
    public enum AttackType
    {
        General,
        Explosion,
        Vibration
    }
}
namespace Entity
{
    using UnityEngine;
    using System.Collections;

    public interface IAttackMethod
    {
        EntityBase attacker { get; }

        int damage { get; }
        float delay { get; }

        AttackData currentAttackData { get; }

        IEnumerator Attack(EntityBase target);
    }

    public class DefaultAttack : IAttackMethod
    {
        // 생성자
        public DefaultAttack(EntityBase attaker,int damage,float delay)
        {
            this.attacker = attaker;
            this.damage = damage;
            this.delay = delay;
        }

        //인터페이스
        public EntityBase attacker { get; private set; }
        public int      damage { get; private set; }
        public float    delay { get; private set; }
        
        public  AttackData currentAttackData
        {
            get { return new AttackData(attacker, damage, attacker.lookDirection); }
        }
        
        public IEnumerator Attack(EntityBase target)
        {
            yield return new WaitForSeconds(delay);
            target.Attacked(currentAttackData);
        }
    }
}