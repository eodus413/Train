using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAI : MonoBehaviour
{
    UnitBase unit;
    IEnumerator AIBehavior()
    {
        while(unit.isLive)
        {
            yield return new WaitUntil(isFindEnemy);
        }
    }

    void MoveToTarget()
    {

    }

    bool isFindEnemy()
    {
        return true;
    }
}
