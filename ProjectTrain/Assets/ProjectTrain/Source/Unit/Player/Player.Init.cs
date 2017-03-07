using UnityEngine;
using ProjectTrain;
using ProjectTrain.Weapon;

namespace ProjectTrain
{
    public partial class Player : Unit
    {
        public const int orgHp = 10;
        const float orgSpeed = 0.5f;
        
        public override void Initialize()
        {
            Initialize( Layers.Player,
                        orgHp,
                        new PlayerMovement(transform,this, orgSpeed),
                        new PlayerAnimation(this,animator));
        }

        protected override void Initialize(int layer,int hp, MovementBase movement, UnitAnimation animation)
        {
            base.Initialize(layer,hp, movement,animation);

            hand = transform.FindChild("Hand");

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


