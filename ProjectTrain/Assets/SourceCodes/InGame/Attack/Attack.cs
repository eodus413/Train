using UnityEngine;
using Entity;

//삭제요망
public static class Attack
{
    public static void To(EntityBase target, AttackData data)
    {
        if (data.isAttackTeam) return;

        Debug.Log(target + "Attacked By" + data.attacker);  

        target.Attacked(data);
    }
}
