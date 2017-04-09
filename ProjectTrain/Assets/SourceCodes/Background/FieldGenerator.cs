using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Background
{
    public class FieldGenerator : MonoBehaviour
    {
        [SerializeField]
        private Stages stage;
        GameObject fieldPrefab;
        void Awake()
        {
            fieldPrefab = Resources.Load<GameObject>("Colliders/" + stage.ToString());
            Instantiate(fieldPrefab, transform);
        }
    }
}