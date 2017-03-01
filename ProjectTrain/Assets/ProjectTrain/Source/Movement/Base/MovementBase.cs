using UnityEngine;

namespace ProjectTrain
{
    public partial class MovementBase
    { 
        Transform transform;
        public Vector3 direction { get; private set; }
        public float speed { get; private set; }
    }
}