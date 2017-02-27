using UnityEngine;

namespace ProjectTrain.Weapon
{
    public partial class Pistol : WeaponBase
    {
        #region InitializeData
        const int maxAmmo = 8;
        const float coolTime = 1f;
        const float startDelay = 1f;
        const int damage = 5;

        const string bulletPath = "Prefabs/Weapon/Pistol/Bullet";
        const string shotClipPath_1 = "Sounds/Weapon/Pistol/Shot_1";
        const string shotClipPath_2 = "Sounds/Weapon/Pistol/Shot_2";
        const string shotClipPath_3 = "Sounds/Weapon/Pistol/Shot_3";
        const string reloadClipPath = "Sounds/Weapon/Pistol/Reload";
        #endregion

        protected override void Start()
        {
            Initialize(
                Resources.Load<GameObject>(bulletPath),
                new AudioClip[] {   Resources.Load<AudioClip>(shotClipPath_1),
                                    Resources.Load<AudioClip>(shotClipPath_2),
                                    Resources.Load<AudioClip>(shotClipPath_3) },
                Resources.Load<AudioClip>(reloadClipPath),
                coolTime,
                startDelay,
                damage,
                maxAmmo
                );
        }

        public override void Initialize
            (GameObject bullet, AudioClip[] shotClips, AudioClip reloadClip,
            float coolTime, float startDelay,int damage,int maxAmmo)
        {
            base.Initialize(    bullet,
                                shotClips,
                                reloadClip,
                                coolTime,
                                startDelay,
                                damage,
                                maxAmmo
                                );
        }
    }
}