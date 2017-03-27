using UnityEngine;
using System.Collections.Generic;

namespace ProjectCatMan
{
    public partial class UnitBase : MonoBehaviour
    {
        Life life;
        public ISee see { get; private set; }
        public IMovable movable { get; private set; }
        
        [SerializeField]
        public Team team { get; private set; }
        [SerializeField]
        Friendly friendly;
        [SerializeField]
        UnitType type;
        

        IUnitFactory factory;

        UnitController controller;
        void Awake()
        {
            animator = GetComponent<Animator>();

            factory     =       InGameManager.currentFactory(type);

            team        =       factory.SetTeam();
            friendly    =       factory.SetFriendly();
            
            see         =       factory.SetSee(this);
            movable     =       factory.SetMovable(this);
            
            life        = 
            controller  = 
        }
    }

    #region Interfaces
    public partial class UnitBase : MonoBehaviour
    {
        public bool isMoving
        {
            get { return movable.isMoving; }
        }
        public bool isBack
        {
            get
            {
                return see.direction.Vec3ToDir() != movable.moveDirection;
            }
        }
        public bool isBackMoving
        {
            get
            {
                return movable.isMoving & isBack;
            }
        }
        public bool isAttacking
        {
            get
            {
                return false;
            }
        }

        public bool isLive
        {
            get { return life.isLive; }
        }
        public bool isDead
        {
            get { return !life.isDead; }
        }

        public void Attacked(AttackData data)
        {
            life.Attacked(data);
        }
    }
    #endregion

    #region Animation
    public partial class UnitBase : MonoBehaviour
    {
        Animator animator;
    }
    #endregion

    #region Implemented
    public partial class UnitBase : MonoBehaviour
    {
        readonly string A_isDead = AnimationParameters.isDead.ToString();
        void Dead()
        {
            animator.SetBool(A_isDead, true);
        }
    }
    #endregion
}




















