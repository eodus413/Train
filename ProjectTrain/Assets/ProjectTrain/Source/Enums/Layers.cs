using UnityEngine;

namespace ProjectTrain
{
    public static class Layers
    {
        public static int Nothing       = LayerMask.NameToLayer("Nothing");
        public static int Everything    = LayerMask.NameToLayer("Everything");
        public static int Player        = LayerMask.NameToLayer("Player");
        public static int Enemy         = LayerMask.NameToLayer("Enemy");
        public static int Ground        = LayerMask.NameToLayer("Ground");
        public static int Dead          = LayerMask.NameToLayer("Dead");
        public static int Object        = LayerMask.NameToLayer("Object");
        public static int StaticObject  = LayerMask.NameToLayer("StaticObject");
        public static int Lader         = LayerMask.NameToLayer("Ladder");
        public static int Stairs        = LayerMask.NameToLayer("Stairs");


        public static int PlayerMask    = 1 << LayerMask.NameToLayer("Player");
        public static int EnemyMask     = 1 << LayerMask.NameToLayer("Enemy");
        public static int GroundMask    = 1 << LayerMask.NameToLayer("Ground");
        public static int DeadMask      = 1 << LayerMask.NameToLayer("Dead");
        public static int ObjectMask    = 1 << LayerMask.NameToLayer("Object");
        public static int StaticObjectMask = 1 << LayerMask.NameToLayer("StaticObject");
        public static int LaderMask     = 1 << LayerMask.NameToLayer("Ladder");
        public static int StairsMask    = 1 << LayerMask.NameToLayer("Stairs");

        public static int ToMask(int value)
        {
            return 1 << value;
        }
        public static int ToValue(int mask)
        {
            int count = 0;
            bool result = true;
            while(result)
            {
                ++count;
                if ((mask = mask >> 1) <= 1) result = false;
            }
            return count;
        }
    }

}