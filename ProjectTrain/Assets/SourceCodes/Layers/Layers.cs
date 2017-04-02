using UnityEngine;

namespace LayerManager
{
    public static class Layers
    {
        public static LayerMask Nothing = 0;

        public static int Ground = LayerMask.NameToLayer("Ground");
        public static int Player = LayerMask.NameToLayer("Player");
        public static int Monster = LayerMask.NameToLayer("Monster");

        public static LayerMask GroundMask = 1 << Ground;
        public static LayerMask PlayerMask = 1 << Player;
        public static LayerMask MonsterMask = 1 << Monster;


        public static int ToMask(LayerMask layerMask)
        {
            return 1 << layerMask;
        }
    }
}