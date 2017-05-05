using UnityEngine;

namespace LayerManager
{
    public static class Layers
    {
        public static LayerMask Nothing = 0;

        public static int Ground = LayerMask.NameToLayer("Ground");
        public static int Player = LayerMask.NameToLayer("Player");
        public static int Monster = LayerMask.NameToLayer("Monster");
        public static int Object = LayerMask.NameToLayer("Object");
        public static int Dead = LayerMask.NameToLayer("Dead");
        public static int TargetingArea = LayerMask.NameToLayer("TargetingArea");
        public static int Bullet = LayerMask.NameToLayer("Bullet");

        
        public static LayerMask GroundMask = 1 << Ground;
        public static LayerMask PlayerMask = 1 << Player;
        public static LayerMask MonsterMask = 1 << Monster;
        public static LayerMask ObjectMask = 1 << Object;
        public static LayerMask DeadMask = 1 << Dead;
        public static LayerMask TargetingAreaMask = 1 << TargetingArea;
        public static LayerMask BulletMask = 1 << Bullet;

        public static int ToMask(LayerMask layerMask)
        {
            return 1 << layerMask;
        }
    } 
}