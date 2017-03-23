using UnityEngine;

namespace ProjectCatMan
{
    public interface IWeapon : IItem, IUse
    {
        IAttack attack { get; }
    }

    public class Gun : IWeapon
    {
        public Gun(UnitBase attacker, int damage, float range)
        {
            attack = new AttackDirect(attacker, damage);
            targeting = new TargetingToRaycast(shotPoint, range, Team.Monster.LayerMask(), Layers.GroundMask);

            GameObject prefab = Resources.Load<GameObject>("Prefab/Weapon/Gun");

            GameObject gun = GameObject.Instantiate(prefab,attacker.transform) as GameObject;

            this.shotPoint = gun.transform.GetChild(0);
            this.range = range;
        }

        #region Item

        public ItemType type
        {
            get { return ItemType.Equipment; }
        }
        #endregion



        #region Use

        public void Use()
        {
            attack.Attack(target.attackable);
        }
        #endregion




        #region Attack
        public IAttack attack { get; private set; }
        #endregion




        #region Gun
        public ITargeting targeting { get; private set; }
        public Transform shotPoint { get; private set; }
        
        public float range { get; private set; }

        public UnitBase target
        {
            get
            {
                return targeting.target.GetComponent<UnitBase>();
            }
        }
        #endregion
    }
}