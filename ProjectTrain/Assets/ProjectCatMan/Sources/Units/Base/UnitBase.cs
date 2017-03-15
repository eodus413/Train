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

        void Awake()
        {
            factory = InGameManager.currentFactory(type); 
        }
        void Update()
        {
            if (!killable.isLive) return;

            movable.Move();

 
            seeable.Seeing();
        }
    }
}