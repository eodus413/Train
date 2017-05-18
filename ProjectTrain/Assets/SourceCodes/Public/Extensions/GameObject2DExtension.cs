using UnityEngine;
public static class GameObject2DExtension
{
    public static void TurnLeft(this GameObject lv)
    {
        Vector3 vec = lv.transform.localScale;
        vec.Set(Mathf.Abs(vec.x) * -1, vec.y, vec.z);
        lv.transform.localScale = vec;
    }
    public static void TurnRight(this GameObject lv)
    {
        Vector3 vec = lv.transform.localScale;
        vec.Set(Mathf.Abs(vec.x), vec.y, vec.z);
        lv.transform.localScale = vec;
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
