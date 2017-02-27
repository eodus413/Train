using UnityEngine;
using ProjectTrain;
using ProjectTrain.Weapon;

namespace ProjectTrain
{
    public partial class Player : Unit
    {
        const float speed = 0.5f;
        
        public override void Initialize()
        {
            Initialize(10, new MovementBase(transform, speed),new PlayerAnimation(this,animator));
        }

        protected override void Initialize(int hp, MovementBase movement, UnitAnimation animation)
        {
            base.Initialize(hp, movement,animation);

            hand = transform.GetChild(0);

            int count = hand.transform.childCount;
            WeaponBase temp;
            for (int i = 0; i < count; ++i)
            {
                temp = hand.transform.GetChild(i).GetComponent<WeaponBase>();

                if (temp != null)
                {
                    weapons.Add(temp);
                }
            }
        }
    }
}


