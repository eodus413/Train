using System;
using UnityEngine;

namespace ProjectTrain
{
    public partial class Player : Unit
    {
        bool isLayerStairs(GameObject other)
        {
            if (other.layer == Layers.Lader) return true;
            if (other.layer == Layers.Stairs) return true;

            return false;
        }
        void OnTriggerStay2D(Collider2D other)
        {
            if (isLayerStairs(other.gameObject) == false) return;

            float speed = movement.speed;
            if (Input.GetKey(KeyCode.S))
            {
                rigidbody.velocity = new Vector2(0, -speed);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                rigidbody.velocity = new Vector2(0, speed);
            }
            else
            {
                rigidbody.velocity = new Vector2(0, 0.2f);
            }
        }
    }
}