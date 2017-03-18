using UnityEngine;

namespace ProjectCatMan
{
    public class UnitBase : MonoBehaviour
    {
        public IDamageable damageable { get; private set; }
        public IKillable killable { get; private set; }
        public ISeeable seeable { get; private set; }
        public IMovable movable { get; private set; }

        [SerializeField]
        UnitType type;
        IUnitFactory factory;
        IController controller;

        public Animator animator { get; private set; }
        void Awake()
        {
            animator = GetComponent<Animator>();

            factory = InGameManager.currentFactory(type);
  
            damageable  =       factory.SetDamageable(this);
            killable    =       factory.SetKillable(this);
            seeable     =       factory.SetSeeable(this);
            movable     =       factory.SetMovable(this);

            controller  =       factory.SetController(this);

            controller.Initialize();
        }
        void Update()
        {
            controller.Execute();
        }
        void FixedUpdate()
        {
            controller.PhysicsExecute();
        }
    }
}