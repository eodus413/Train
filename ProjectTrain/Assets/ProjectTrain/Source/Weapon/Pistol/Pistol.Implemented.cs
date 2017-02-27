using UnityEngine;

namespace ProjectTrain.Weapon
{
    public partial class Pistol : WeaponBase
    {
        const string unitTag = "Unit";
        protected override IAttackable GetTarget()
        {
            Debug.DrawRay(shotPoint.position, transform.right, Color.red);
            RaycastHit2D hit = Physics2D.Raycast(shotPoint.position,
                                                    transform.right, maximumRange);
            if (!hit) return null;

            GameObject hitObj = hit.collider.gameObject;

            if (hitObj == null) return null;        //충돌이 안됬으면 return

            if (hitObj.CompareTag(unitTag) == false) return null;

            Debug.Log(hit.point);

            return hitObj.GetComponent<Unit>();
        }
    }

}