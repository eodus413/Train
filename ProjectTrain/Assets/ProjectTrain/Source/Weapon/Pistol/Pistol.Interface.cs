using UnityEngine;

namespace ProjectTrain.Weapon
{
    public partial class Pistol : WeaponBase
    {
        public override void Shot()
        {
            GameObject instance = emptyCatridges.Get(false);
            instance.SetActive(true);
            instance.transform.position = transform.position;
            instance.transform.rotation = transform.rotation;
            base.Shot();
        }
    }
}