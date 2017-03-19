using UnityEngine;

namespace ProjectCatMan
{
    public interface IController
    {
        void Initialize();
        void Execute();
        void PhysicsExecute();
    }

    #region Unit

    public abstract class UnitController : IController
    {
        public UnitController(UnitBase unit)
        {
            this.unit = unit;
            this.transform = unit.transform;
            this.gameObject = unit.gameObject;

            this.attackable = unit.attackable;
            this.killable = unit.killable;
            this.see = unit.see;
            this.movable = unit.movable;
        }

        public abstract void Initialize();
        public abstract void Execute();
        public abstract void PhysicsExecute();



        public UnitBase unit { get; private set; }
        public Transform transform { get; private set; }
        public GameObject gameObject { get; private set; }

        public IAttackable attackable { get; private set; }
        public IKillable killable { get; private set; }
        public ISee see { get; private set; }
        public IMovable movable { get; private set; }
    }
    #endregion

    #region Monster
    public class BasicMonsterController : UnitController
    {
        public BasicMonsterController(UnitBase unit) : base(unit)
        {

        }
        public override void Initialize()
        {
        }
        public override void Execute()
        {
            if (killable.isLive == false) return;

            see.Seeing();
        }
        public override void PhysicsExecute()
        {
            movable.Move();
        }
    }
    #endregion

    #region Player
    public partial class PlayerController : UnitController
    {
        #region Interface
        public PlayerController(UnitBase unit, Animator animator) : base(unit)
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
        const string A_isMoving     = "isMoving";
        const string A_isBackMoving = "isBackMoving";
        const string A_isDead       = "isDead";

        void AnimatorParameterUpdate()
        {
            bool isBack = lookDirection != movable.moveDirection;   //isBack 은 player가 보고잇는 방향과 움직이는 방향이 다르면 true

            Debug.Log(movable.isMoving);

            animator.SetBool(A_isBackMoving, movable.isMoving & isBack);
            animator.SetBool(A_isMoving, movable.isMoving);


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
            else if (Input.GetKey(KeyCode.S)) buttonA.Execute();
            else
            {
                buttonW.Undo();
                buttonS.Undo();
            }

            if (Input.GetKey(KeyCode.A)) buttonA.Execute();
            else if (Input.GetKey(KeyCode.D)) buttonD.Execute();
            else
            {
                buttonA.Undo();
                buttonD.Undo();
            }
            if (Input.GetMouseButtonDown(0)) buttonMouse0.Execute();

        }
        #endregion
    }
    #endregion
}