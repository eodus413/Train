using UnityEngine;

namespace ProjectTrain
{
    public abstract partial class Unit : MonoBehaviour, IAttackable, IInitilaizable
    {
        public int layer { get; private set; }
        private int deadLayer;
        /// <summary>
        /// 데이터
        /// </summary>
        private int _hp;            //property 있음 Unit.inteface
        Direction _moveDirection;
        Direction _lookingDirection;//보고 있는 방향 property 있음 Unit.interface
        
        /// <summary>
        /// 컴포넌트
        /// </summary>
        public new SpriteRenderer renderer { get; private set; }
        public new Collider2D collider { get; private set; }
        public new Rigidbody2D rigidbody { get; private set; }
        public Animator animator { get; private set; }

        public MovementBase movement { get; private set; }

        public new UnitAnimation animation { get; private set; }
    }
}