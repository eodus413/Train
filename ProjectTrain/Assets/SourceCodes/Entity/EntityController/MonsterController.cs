using UnityEngine;
using Entity;
using System.Collections;

namespace Entity.Controller
{
    public partial class MonsterController : EntityController
    {
        public override IEnumerator Start()
        {
            while (isActive)
            {
                if (target == null) yield return Targeting();
                yield return new WaitForSeconds(routineDelay);
            }
        }

        GameObject target;

        private float targetingDelay;
        IEnumerator Targeting()
        {
            sight.Seeing();
            yield return new WaitForSeconds(targetingDelay);
        }
        
        //Coroutine _currentCoroutine;
        //Coroutine SetState(IEnumerator state)
        //{
        //    if (_currentCoroutine != null)
        //        entity.StopCoroutine(_currentCoroutine);
        //    return _currentCoroutine = entity.StartCoroutine(state);
        //}

        //IEnumerator AI()
        //{
        //    do
        //    {
        //        if (isA == true) yield return SetState();
        //    } while ();
        //}
    }


    public partial class MonsterController : EntityController
    {
        EntitySight sight;
        public MonsterController(EntityBase entity,float reactionVelocity = 1f) : base(entity)
        {
            sight = entity.sight;
            targetingDelay = reactionVelocity;
        }
    }
}
