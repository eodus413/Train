using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FieldObject
{
    public class Door : FieldObjectBase
    {
        protected override void DoInitialize()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            //soundload
        }
        public override void Interact()
        {
            StartCoroutine(FadeOut());
        }
        SpriteRenderer spriteRenderer;
        IEnumerator FadeOut()
        {
            Color color = spriteRenderer.color;
            for (float i = 1f; i > 0; i -= 0.1f)
            {
                yield return new WaitForSeconds(0.1f);
                color.a = i;
                spriteRenderer.color = color;
            }
            gameObject.SetActive(false);
        }
    }
}
