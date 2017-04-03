using System;
using UnityEngine;
using System.Collections;

namespace FieldObject
{
    public abstract class FieldObjectBase : MonoBehaviour
    {
        void Awake()
        {
            DoInitialize();
        }
        protected virtual void DoInitialize()
        {

        }
        public abstract void Interact();
    }
}