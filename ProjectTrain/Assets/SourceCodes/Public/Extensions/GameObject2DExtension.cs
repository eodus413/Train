using UnityEngine;
using Entity;

public static class GameObject2DExtension
{
    static Vector2 turnRight = new Vector2(1, 1);
    static Vector2 turnLeft = new Vector2(-1, 1);
    public static void TurnLeft(this GameObject lv)
    {
        lv.transform.localScale = turnLeft;
    }
    public static void TurnRight(this GameObject lv)
    {
        lv.transform.localScale = turnRight;
    }
    public static void Turn2D(this GameObject lv, Vector2 direction)
    {
        if (direction == Vector2.left) lv.TurnLeft();
        else if (direction == Vector2.right) lv.TurnRight();
        else return;
    }


    public static Vector2 TargetLocation(this GameObject center,GameObject target)
    {
        bool isLeft = target.transform.position.x < center.transform.position.x;
        if (isLeft) return Vector2.left;
        else return Vector2.right;
    }
}
