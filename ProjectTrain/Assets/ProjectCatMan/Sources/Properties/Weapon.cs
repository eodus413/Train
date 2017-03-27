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

            float sight = 1f;
            int detectMask = attacker.team.AttackLayerMask();
            int denyMask = Layers.GroundMask;
            see = new SeeFoward(attacker.transform, sight, detectMask, denyMask);

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
            target.Attacked(new AttackData(attack.attacker, attack.damage));
        }
        #endregion




        #region Attack
        public IAttack attack { get; private set; }
        #endregion




        #region Gun
        public ISee see { get; private set; }
        public Transform shotPoint { get; private set; }
        
        public float range { get; private set; }

        public UnitBase target
        {
            get
            {
                return see.current.GetComponent<UnitBase>();
            }
        }
        #endregion
    }
}