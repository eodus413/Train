namespace Entity
{
    //Layers
    using UnityEngine;
    using LayerManager;
    public static class EntityTypeExtension
    {
        public static LayerMask GetLayer(this EntityType type)
        {
            if (type == EntityType.Player)
            {
                return Layers.Player;
            }
            else if (type == EntityType.NormalMonster)
            {
                return Layers.Monster;
            }
            else if (type == EntityType.UpgradeMonster)
            {
                return Layers.Monster;
            }
            else
            {
                return Layers.Nothing;
            }
        }

        public static LayerMask GetEnemyLayerMask(this EntityType type)
        {
            if(type == EntityType.Player)
            {
                return Layers.MonsterMask;
            }
            else if(type == EntityType.NormalMonster)
            {
                return Layers.PlayerMask;
            }
            else if(type == EntityType.UpgradeMonster)
            {
                return Layers.PlayerMask;
            }
            else
            {
                return Layers.Nothing;
            }
        }

        public static LayerMask GetDenyLayerMask(this EntityType type)
        {
            return Layers.GroundMask;
        }

    }
}