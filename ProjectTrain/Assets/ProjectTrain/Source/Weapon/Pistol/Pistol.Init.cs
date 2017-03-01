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
        
        const string shotClipPath_1 = "Sounds/Weapon/Pistol/Shot_1";
        const string shotClipPath_2 = "Sounds/Weapon/Pistol/Shot_2";
        const string shotClipPath_3 = "Sounds/Weapon/Pistol/Shot_3";
        const string reloadClipPath = "Sounds/Weapon/Pistol/Reload";

        const string emptyCatridgePath = "Prefabs/Weapon/EmptyCateridge";
        #endregion


        protected override void Start()
        {
            Initialize(
                new AudioClip[] {   Resources.Load<AudioClip>(shotClipPath_1),
                                    Resources.Load<AudioClip>(shotClipPath_2),
                                    Resources.Load<AudioClip>(shotClipPath_3) },
                Resources.Load<AudioClip>(reloadClipPath),
                coolTime,
                damage,
                maxAmmo
                );

            emptyCatridge = Resources.Load<GameObject>(emptyCatridgePath);
            emptyCatridges = new GameObjectPool(emptyCatridge,30);

        }

        public override void Initialize
            (AudioClip[] shotClips, AudioClip reloadClip,
            float coolTime,int damage,int maxAmmo)
        {
            base.Initialize(
                                shotClips,
                                reloadClip,
                                coolTime,
                                damage,
                                maxAmmo
                                );

            this.mask += 1 << LayerMask.NameToLayer("Enemy");
            this.mask += 1 << LayerMask.NameToLayer("Ground");
            this.mask += 1 << LayerMask.NameToLayer("Object");
        }
    }
}