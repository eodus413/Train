namespace Entity
{
    //Layers
    using UnityEngine;
    using LayerManager;
    public static class EntityTypeExtension
    {
        public static LayerMask GetLayer(this EntityType type)
        {
            if (type == EntityType.Player) return Layers.Player;
            else return Layers.Monster;
        }
        public static LayerMask GetEnemyLayerMask(this EntityType type)
        {
            if (type == EntityType.Player) return Layers.MonsterMask;
            else return Layers.PlayerMask;
        }
    }
}