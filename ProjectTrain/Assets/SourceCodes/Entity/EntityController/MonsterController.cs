using UnityEngine;
using Entity;
using System.Collections;

namespace Entity.Controller
{
    public partial class MonsterController : EntityController
    {
        //생성자
        public MonsterController(EntityBase entity, float reactionVelocity = 1f) : base(entity)
        {
            this.reactionVelocity = reactionVelocity;

            targetingMethod = new TargetingToLookDirection(entity, 1f, entity.type, LayerManager.Layers.GroundMask, entity);
        }
        //인터페이스
        //구현
        public bool isLive
        {
            get
            {
                return false;
            }
        }

        public override IEnumerator Start()
        {
            while (isActive)
            {
                yield return Targeting();
                yield return new WaitForSeconds(routineDelay);
            }
        }
        

        private float reactionVelocity;
        private float targetingDelay
        {
            get { return reactionVelocity; }
        }
        private float checkTargetDelay
        {
            get { return reactionVelocity; }
        }

        ITargetingMethod targetingMethod;
        IEnumerator Targeting()
        {
            yield return new WaitForSeconds(targetingDelay);
            //targeting으로 고쳐야함
            entity.Move(Direction.right);
        }
        
        //제거 혹은 수정
        //EntityBase targetEntity
        //{
        //    get { return sight.target.GetComponent<EntityBase>(); }
        //}
        
        const float deadBodyRemainTime = 5f;
        IEnumerator Dead()
        {
            entity.Dead();
            yield return new WaitForSeconds(deadBodyRemainTime);
            Color c = Color.white;
            for (float i = 1f; i > 0f; i -= 0.1f)
            {
                c.a = i;
                entity.baseRenderer.color = c; 
                yield return new WaitForSeconds(0.1f);
            }
            entity.gameObject.SetActive(false);
            //죽음 애니메이션
            //대기
            //사라짐
        }
    }
}
