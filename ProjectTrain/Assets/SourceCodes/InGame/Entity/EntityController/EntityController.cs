using UnityEngine;
using System.Collections;

namespace Entity.Controller
{
    public abstract partial class EntityController
    {
        public const float moveRoutineDelay = 0.01f;

        public float routineDelay { get; private set; }
        public void SlowDownDelay(float value)
        {
            if (value <= 1) return;
            routineDelay *= value;
        } 
        public void SpeedUpDelay(float value)
        {
            if (value <= 1) return;
            routineDelay /= value;
        }
        public void AddDelay(float value)
        {
            routineDelay += value;
        }
        public void MinusDelay(float value)
        {
            routineDelay -= value;
        }

        public abstract IEnumerator Start();

        public bool isActive { get; private set; }
        public void Inactive()
        {
            isActive = false;
        }
        public void Active()
        {
            isActive = true;
        }
    }

    public abstract partial class EntityController
    {
        public EntityBase entity { get; private set; }
        public Transform entityTransform { get; private set; }
        public EntityController(EntityBase entity,float routineDelay = 0.05f)
        {
            isActive = true;
            this.entity = entity;
            this.routineDelay = routineDelay;
            this.entityTransform = entity.transform;
        }
    }
}