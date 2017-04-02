using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class Layer
{
    public static int PlayerLayer = 1;
}

public class UnitSight : MonoBehaviour
{
    public delegate void EnemyState();
    public event EnemyState EnemyEnter;
    public event EnemyState EnemyExit;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == Layer.PlayerLayer) return;
    }
}
