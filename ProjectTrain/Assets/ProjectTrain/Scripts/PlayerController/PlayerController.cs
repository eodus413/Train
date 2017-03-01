using UnityEngine;
using System.Collections;

namespace ProjectTrain
{
    public class PlayerController : MonoBehaviour
    {
        void Awake()
        {
            player = GetComponent<Player>();
        }
        void Update()
        {
            Handling();
        }

        public Player player;

        public void Handling()
        {
            player.Look(getLookDirection());
        }

        private Direction getLookDirection()
        {
            float halfBar;

            halfBar = Camera.main.WorldToScreenPoint(transform.position).x;
            if (Input.mousePosition.x < halfBar)
            {
                return Direction.Left;
            }
            return Direction.Right;
        }
    }
}
