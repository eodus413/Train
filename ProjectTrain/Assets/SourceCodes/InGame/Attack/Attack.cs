using UnityEngine;
using Entity;
public static class Attack
{
    public static void To(EntityBase target, AttackData data)
    {
        if (target.team == data.attaker.team) return;
        target.Attacked(data);
    }
}
