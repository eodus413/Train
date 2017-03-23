using UnityEngine;

namespace ProjectCatMan
{
    //외부의 클래스에 포함되어 사용
    //외부에서 Target의 설정하는 방법을 가지고 있음
    //외부에서 Target을 설정한 뒤 IAttack.Attack 호출
    public interface IAttack
    {
        UnitBase attacker { get; }          //공격 시전자
        int damage { get; }                 //데미지

        void Attack(IAttackable target);    //Target을 공격하는 함수
    }

    //데미지가 바로 적용됨
    public class AttackDirect : IAttack
    {
        public AttackDirect(UnitBase attacker,int damage)
        {
            this.attacker = attacker;
            this.damage = damage;
        }

        public UnitBase attacker { get; private set; }
        public int damage { get; private set; }
        private AttackData data
        {
            get { return new AttackData(attacker, damage); }
        }

        public void Attack(IAttackable target)
        {
            target.BeAttacked(data);
        }
    }

    #region AttackInRange
    
    //공격 범위 안에 있으면 데미지가 적용됨
    public class AttackInRange : IAttack
    {
        public AttackInRange(UnitBase attacker,int damage,int range)
        {
            this.attacker = attacker;
            this.range = range;
        }

        public UnitBase attacker { get; private set; }
        public int damage { get; private set; }
        private AttackData data
        {
            get { return new AttackData(attacker, damage); }
        }

        public void Attack(IAttackable target)
        {
            Vector3 attackerPos = attacker.transform.position;      //공격하는 Unit의 Position
            Vector3 targetPos = target.transform.position;          //Target의 Position

            float distanceToTarget = Vector3.Distance(attackerPos, targetPos);

            if (distanceToTarget > range) return;    //사거리 밖에 있다면

            target.BeAttacked(data);
        }
        
        public float range { get; private set; }
    }
    #endregion
}