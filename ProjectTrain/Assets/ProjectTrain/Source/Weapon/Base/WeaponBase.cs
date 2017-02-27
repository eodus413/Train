using UnityEngine;

namespace ProjectTrain.Weapon
{
    public abstract partial class WeaponBase : MonoBehaviour
    {
        public Unit owner { get; private set; }     //무기 주인

        public Magazine magazine { get; private set; }  //탄창

        /// <summary>
        /// 데이터
        /// </summary>
        [SerializeField] int damage;                //무기 공격력

        public Transform shotPoint { get; private set; }      //발사지점 리소스

        [SerializeField] GameObject bullet;         //프리팹 리소스
        [SerializeField] AudioClip[] shotClips;     //발사 사운드 리소스
        [SerializeField] AudioClip reloadClip;      //재장전 사운드 리소스

        float coolTime;     //시전후 재시전 딜레이
        float startDelay;   //시작하기 전 딜레이 
        float reloadDelay;  //장전 딜레이 (애니메이션과 통일)
                
        /// <summary>
        /// 컴포넌트
        /// </summary>
        Animator animator;

        /// <summary>
        /// 애니메이션 이름
        /// </summary>
        const string reloadAnimationName    = "Reload";
        const string shotAnimationName      = "Shot";
    }
}