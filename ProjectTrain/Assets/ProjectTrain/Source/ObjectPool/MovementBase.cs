using UnityEngine;

namespace ProjectTrain
{
    public partial class MovementBase
    { 
        Transform transform;
        public bool isMoving { get; private set; }
        public Vector3 direction { get; private set; }
        public float speed { get; private set; }
        public float deltaSpeed { get { return speed * Time.deltaTime; } }
    }
}