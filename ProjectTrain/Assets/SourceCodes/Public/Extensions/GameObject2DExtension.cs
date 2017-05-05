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
    public static void Turn2D(this GameObject lv,Direction direction)
    {
        if (direction.isLeft) lv.TurnLeft();
        else if (direction.isRight) lv.TurnRight();
        else return;
    }


    public static Direction TargetLocation(this GameObject center,GameObject target)
    {
        bool isLeft = target.transform.position.x < center.transform.position.x;
        if (isLeft) return Direction.left;
        else return Direction.right;
    }
}
