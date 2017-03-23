using UnityEngine;

namespace ProjectCatMan
{
    public interface IController
    {
    }
    public interface IInitializableController
    {
        void Initialize();
    }
    public interface IExecutableController
    {
        void Execute();
    }
    #region Unit

    public abstract class UnitController : IController,IInitializableController,IExecutableController
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
        public PlayerController(UnitBase unit) : base(unit)
        {
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
        }
        #endregion

        #region Behavior
        LookAtTheMouse lookAtTheMouse;
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