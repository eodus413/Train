using System;
using UnityEngine;
using System.Collections;

namespace FieldObject
{
    public abstract class FieldObjectBase : MonoBehaviour
    {
        [Header("Collider")]
        [SerializeField]
        private bool isTrigger = true;

        void Awake()
        {
            Collider2D col = gameObject.GetComponent<Collider2D>();
            if (!col) gameObject.AddComponent<Collider2D>();
            col.isTrigger = isTrigger; 
        }

        protected abstract void OnTriggerEnter2D(Collider2D other);
    }
}