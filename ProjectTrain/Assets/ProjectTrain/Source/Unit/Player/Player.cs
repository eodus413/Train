using UnityEngine;
using ProjectTrain.Weapon;
using System.Collections.Generic;

namespace ProjectTrain
{
    public partial class Player : Unit
    {
        Transform hand;

        [SerializeField] List<WeaponBase> weapons = new List<WeaponBase>();
        const string backMoveAnimationName = "MoveBack";
    }
}