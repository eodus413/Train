using UnityEngine;
using Weapon;

public static class AmmoTypeExtension
{
    public static GameObject GetBulletPrefab(this AmmoType type)
    {
        string path = "Prefabs/Bullets/";

        return Resources.Load<GameObject>(path + type.ToString());
    }
}