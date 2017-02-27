using UnityEngine;

namespace ProjectTrain.Weapon
{
    public abstract partial class WeaponBase : MonoBehaviour
    {
        protected abstract void Start();

        public virtual void Initialize
            (GameObject bullet,AudioClip[] shotClips,AudioClip reloadClip,
            float coolTime,float startDelay,int damage,int maxAmmo)
        {
            this.magazine = new Magazine(maxAmmo);

            this.owner = transform.parent.parent.GetComponent<Unit>();     //부모에서 컴포넌트 가져옴
            this.animator = owner.GetComponent<Animator>();         //가져온 부모에서 aniamtor 가져옴

            this.shotPoint = transform.GetChild(0);             

            this.bullet = bullet;
            this.shotClips = shotClips;
            this.reloadClip = reloadClip;
            this.reloadDelay = animator.GetClip(reloadAnimationName).length;

            this.coolTime = coolTime;
            this.startDelay = startDelay;

            this.damage = damage;

        }
    }
}