using UnityEngine;
using ProjectTrain.Weapon;
using System.Collections.Generic;

namespace ProjectTrain
{
    public partial class Player : Unit
    {
        Transform hand;

        List<WeaponBase> weapons = new List<WeaponBase>();
    }
}