using UnityEngine;

namespace ProjectCatMan
{
    public interface IController
    {
        void Initialize();
        void Execute();
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
    }
    #endregion

    #region Player
    public partial class PlayerController : UnitController
    {
        #region Interface
        public PlayerController(UnitBase unit, Animator animator) : base(unit)
        {
            this.animator = animator;
            lookAtTheMouse = new LookAtTheMouse(gameObject);
        }

        public override void Initialize()
        {
            CommandInitialize();
        }
        public override void Execute()
        {
            if (killable.isLive == false) return;

            InputCommand();

            lookAtTheMouse.Looking();
            AnimatorParameterUpdate();
        }
        #endregion

        #region Behavior
        LookAtTheMouse lookAtTheMouse;
        #endregion

        #region Animations
        public Animator animator { get; private set; }

        // A_ 는 Animation 약자
        const string A_isMoving = "isMoving";
        const string A_isBackMoving = "isBackMoving";
        const string A_isDead = "isDead";
        
        void AnimatorParameterUpdate()
        {
            bool isBack = lookAtTheMouse.direction != movable.moveDirection;   //isBack 은 player가 보고잇는 방향과 움직이는 방향이 다르면 true
           
            animator.SetBool(A_isBackMoving, movable.isMoving & isBack);
            animator.SetBool(A_isMoving, movable.isMoving);

            animator.SetBool(A_isDead, !(killable.isLive));
        }
        #endregion

        #region Input
        //button command
        ICommand buttonW;
        ICommand buttonA;
        ICommand buttonS;
        ICommand buttonD;
        ICommand buttonMouse0;

        void CommandInitialize()
        {
            buttonW = new MoveCommand(movable,Direction.None);
            buttonA = new MoveCommand(movable, Direction.Left);
            buttonS = new MoveCommand(movable, Direction.None);
            buttonD = new MoveCommand(movable, Direction.Right);
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