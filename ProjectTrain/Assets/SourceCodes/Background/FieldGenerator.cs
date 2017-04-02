using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Background
{
    public class FieldGenerator : MonoBehaviour
    {
        GameObject fieldPrefab;
        void Awake()
        {
            fieldPrefab = Resources.Load<GameObject>("Colliders/Collider");
            Instantiate(fieldPrefab, transform);
        }
    }
}