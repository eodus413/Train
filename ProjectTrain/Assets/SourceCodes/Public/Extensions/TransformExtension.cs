﻿using UnityEngine;
using Entity;

public static class TransformExtension
{
    static Vector2 turnRight = new Vector2(1, 1);
    static Vector2 turnLeft = new Vector2(-1, 1);
    public static void TurnLeft(this Transform lv)
    {
        lv.localScale = turnLeft;
    }
    public static void TurnRight(this Transform lv)
    {
        lv.localScale = turnRight;
    }
    public static void Turn2D(this Transform lv, Vector2 direction)
    {
        if (direction == Vector2.left) lv.TurnLeft();
        else if (direction == Vector2.right) lv.TurnRight();
        else return;
    }

    public static Vector2 TargetLocation(this Transform center, GameObject target)
    {
        bool isLeft = target.transform.position.x < center.transform.position.x;
        if (isLeft) return Vector2.left;
        else return Vector2.right;
    }
    
    public static bool isLeftTo(this Transform transform, Transform target)
    {
        return (transform.position.x < target.transform.position.x) ;
    }
    public static bool isRightTo(this Transform transform,Transform target)
    {
        return (transform.position.x > target.transform.position.x);
    }

}
