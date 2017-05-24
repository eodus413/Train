using UnityEngine;
using System.Collections;

namespace Entity.Controller
{
    public abstract partial class EntityController
    {
        public const float moveRoutineDelay = 0.01f;

        public float routineDelay { get; private set; }

        public bool isActive { get; private set; }
        public void Inactive()
        {
            isActive = false;
        }
        public void Active()
        {
            isActive = true;
            entity.StartCoroutine(ControllerRoutine());
        }
    }

    public abstract partial class EntityController
    {
        public EntityBase entity { get; private set; }
        public EntityController(EntityBase entity,float routineDelay = 0.05f)
        {
            isActive = true;
            this.entity = entity;
            this.routineDelay = routineDelay;
        }
    }

    public abstract partial class EntityController
    {
        IEnumerator ControllerRoutine()
        {
            yield return Inititliaze();
            while(isActive)
            {
                yield return Update();
            }
            yield return Release();
        }

        protected abstract IEnumerator Inititliaze();

        protected abstract IEnumerator Update();
        protected abstract IEnumerator Release();
    }
}