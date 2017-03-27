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
            target.Attacked(data);
        }
    }    
}