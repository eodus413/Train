using UnityEngine;
using Entity;
using LayerManager;

public static class EntityBaseExtension
{
    public static LayerMask EnemyLayerMask(this EntityBase lv)
    {
        LayerMask value = Layers.Nothing;
        if(lv.type == EntityType.Player)
        {
            value += Layers.MonsterMask;
            return value;
        }
        else
        {
            value += Layers.PlayerMask;
            return value;
        }


    }
}