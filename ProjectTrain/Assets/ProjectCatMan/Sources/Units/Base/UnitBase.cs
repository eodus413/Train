using UnityEngine;
using System.Collections.Generic;

namespace ProjectCatMan
{
    public partial class UnitBase : MonoBehaviour
    {
        List<IItem> inventory = new List<IItem>();  //unit 마다 inventory 보유 
        
        public IAttackable attackable { get; private set; }
        public IKillable killable { get; private set; }
        public ISee see { get; private set; }
        public IMovable movable { get; private set; }
        
        [SerializeField]
        Team team;
        [SerializeField]
        Friendly friendly;
        [SerializeField]
        UnitType type;
        

        IUnitFactory factory;
        IController controller;

        public Animator animator { get; private set; }
        void Awake()
        {
            animator = GetComponent<Animator>();

            factory = InGameManager.currentFactory(type);

            team        =       factory.SetTeam();
            friendly    =       factory.SetFriendly();
            
            attackable  =       factory.SetAttackable(this);
            killable    =       factory.SetKillable(this);
            see         =       factory.SetSee(this);
            movable     =       factory.SetMovable(this);

            controller  =       factory.SetController(this);

            controller.Initialize();
        }
        void Update()
        {
            controller.Execute();
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
                return see.direction != movable.moveDirection;
            }
        }
        public bool isBackMoving
        {
            get
            {
                return movable.isMoving & isBack;
            }
        }

    }
    #endregion
}