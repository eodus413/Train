using UnityEngine;

namespace Entity.Decoration
{
    public partial class TargetingArea : MonoBehaviour
    {
        [Header("DetectData")]
        [SerializeField]
        private LayerMask detectLayerMask;  //감지할 레이어들

        [SerializeField]
        private float detectingRange;   //감지할 범위
        
        private CircleCollider2D detectCollider;
        
        public bool isDetectedTarget { get; private set; }

        private EntityBase entity;
    }
}

namespace Entity.Decoration
{
    public partial class TargetingArea : MonoBehaviour
    {
        GameObject targetObj;
        public EntityBase target { get; private set; }
        void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.IsTouchingLayers(detectLayerMask)) return;
            isDetectedTarget = true;
            targetObj = other.gameObject;
            target = targetObj.GetComponent<EntityBase>();
        }
    }
}

namespace Entity.Decoration
{
    using LayerManager;
    public partial class TargetingArea : MonoBehaviour
    {
        void Awake()
        {
            detectCollider = gameObject.AddComponent<CircleCollider2D>();
            detectCollider.isTrigger = true;
            detectCollider.radius = detectingRange;

            entity = transform.parent.GetComponent<EntityBase>();
            detectLayerMask = Layers.EntitiesMask;

            gameObject.layer = Layers.TargetingArea;
            gameObject.name = "TargetingArea";
        }
    }
}