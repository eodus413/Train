using UnityEngine;

namespace ProjectCatMan
{
    public partial class PlayerController : UnitController
    {
        #region Interface
        public PlayerController(UnitBase unit,Animator animator) : base(unit)
        {
            this.animator = animator;
        }
        
        public override void Initialize()
        {
            CommandInitialize();
        }
        public override void Execute()
        {
            if (killable.isLive == false) return;

            InputCommand();

            Look();
            AnimatorParameterUpdate();
        }
        public override void PhysicsExecute()
        {
        }
        #endregion

        #region Behavior
        private Direction lookDirection;
        void Look()
        {
            Vector3 positionAtView = Camera.main.WorldToScreenPoint(transform.position);

            Vector3 look = Input.mousePosition.Location(positionAtView);
            lookDirection = look.Vec3ToDir();
            gameObject.Turn2D(lookDirection);
        }
        #endregion

        #region Animations
        public Animator animator { get; private set; }

        // A_ 는 Animation 약자
        const string A_isMoving = "isMoving";
        const string A_isBackMoving = "isBackMoving";
        const string A_isDead = "isDead";

        void AnimatorParameterUpdate()
        {
            bool isBack = lookDirection != movable.moveDirection;   //isBack 은 player가 보고잇는 방향과 움직이는 방향이 다르면 true
            Debug.Log(movable.moveDirection);
            if(isBack) animator.SetBool(A_isBackMoving, movable.isMoving);
            else animator.SetBool(A_isMoving, movable.isMoving);

            animator.SetBool(A_isDead, !(killable.isLive));
        }
        #endregion

        #region Input
        ICommand buttonW;
        ICommand buttonA;
        ICommand buttonS;
        ICommand buttonD;
        ICommand buttonMouse0;

        void CommandInitialize()
        {
            buttonA = new MoveLeftCommand(movable);
            buttonD = new MoveRightCommand(movable);
            buttonW = new MoveUpCommand(movable);
            buttonS = new MoveDownCommand(movable);
        }
        void InputCommand()
        {
            if (Input.GetKey(KeyCode.W)) buttonW.Execute();
            if (Input.GetKey(KeyCode.A)) buttonA.Execute();
            if (Input.GetKey(KeyCode.S)) buttonS.Execute();
            if (Input.GetKey(KeyCode.D)) buttonD.Execute();
            if (Input.GetMouseButtonDown(0)) buttonMouse0.Execute();
        }
        #endregion
    }
}