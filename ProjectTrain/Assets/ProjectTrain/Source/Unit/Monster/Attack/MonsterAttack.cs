using UnityEngine;
using System.Collections;

namespace ProjectTrain
{
    public class MonsterAttack
    {
        public bool isAttacking { get; private set; }

        CoolTime startDelay;
        CoolTime coolTime;
        public int damage { get; private set; }
        public float range { get; private set; }

        public bool Attackable()
        {
            return isAttacking != true;
        }

        void Attack(Unit target, Unit attacker)
        {
            AttackData attackData =  new AttackData(damage, attacker.lookingDirection.DirToVec2(), attacker);

            target.Attacked(attackData);
        }
        public IEnumerator DoAttack(Unit target, Unit attacker)
        {
            if (isAttacking) yield break;
            isAttacking = true;
            yield return new WaitForSeconds(startDelay.coolTime);
            if (Vector3.Distance(target.transform.position, attacker.transform.position) > range)
            {
                isAttacking = false;
                yield break;
            }
            Attack(target, attacker);
            yield return new WaitForSeconds(coolTime.coolTime - startDelay.coolTime);
            isAttacking = false;
        }

        public MonsterAttack(int damage, float range, CoolTime startDelay, CoolTime coolTime)
        {
            isAttacking = false;
            this.damage = damage;
            this.range = range;
            this.startDelay = startDelay;
            this.coolTime = coolTime;
        }
    }
}