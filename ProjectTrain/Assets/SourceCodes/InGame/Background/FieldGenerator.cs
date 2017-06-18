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
        public void Initialize(Stages stage)
        {
            this.stage = stage;
            fieldPrefab = Resources.Load<GameObject>("Colliders/" + stage.ToString());
            Instantiate(fieldPrefab, transform);
        }
    }
}