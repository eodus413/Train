using UnityEngine;

namespace ProjectTrain.Weapon
{
    public partial class Pistol : WeaponBase
    {
        float maximumRange = 1f;

        [SerializeField] LayerMask mask;

        GameObject emptyCatridge;
        GameObjectPool emptyCatridges; 
    }
}