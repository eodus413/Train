﻿using UnityEngine;

namespace ProjectCatMan
{
    public static class Layers
    {
        public static int Noting = 0;
        public static int Everything = -1;
        public static int Ground = LayerMask.NameToLayer("Ground");
        public static int Dead = LayerMask.NameToLayer("Dead");
        public static int Object = LayerMask.NameToLayer("Object");
        public static int StaticObject = LayerMask.NameToLayer("StaticObject");
        public static int Lader = LayerMask.NameToLayer("Ladder");
        public static int Stairs = LayerMask.NameToLayer("Stairs");
        public static int Player = LayerMask.NameToLayer("Player");
        public static int Monster = LayerMask.NameToLayer("Monster");


        public static int GroundMask = 1 << LayerMask.NameToLayer("Ground");
        public static int DeadMask = 1 << LayerMask.NameToLayer("Dead");
        public static int ObjectMask = 1 << LayerMask.NameToLayer("Object");
        public static int StaticObjectMask = 1 << LayerMask.NameToLayer("StaticObject");
        public static int LaderMask = 1 << LayerMask.NameToLayer("Ladder");
        public static int StairsMask = 1 << LayerMask.NameToLayer("Stairs");
        public static int PlayerMask = 1 << LayerMask.NameToLayer("Player");
        public static int MonsterMask = 1 << LayerMask.NameToLayer("Monster");
        
        public static int ToMask(int value)
        {
            return 1 << value;
        }
        public static int ToValue(int mask)
        {
            int count = 0;
            bool result = true;
            while (result)
            {
                ++count;
                if ((mask = mask >> 1) <= 1) result = false;
            }
            return count;
        }
        
    }

}