using UnityEngine;
using Entity;
public static class Attack
{
    public static void To(EntityBase target, AttackData data)
    {
        Debug.Log(data.attaker.gameObject + " 가 " + target.gameObject + " 를 공격함");
        if (target.teamNumber == data.attaker.teamNumber) Debug.Log("팀원공격함");
        target.Attacked(data);
    }
}
