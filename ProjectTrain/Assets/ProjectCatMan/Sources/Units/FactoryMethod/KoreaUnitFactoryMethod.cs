using UnityEngine;

namespace ProjectCatMan
{
    public class KoreaUnitFactoryMethod : UnitFactoryMethod
    {
        public override IUnitFactory GetFactory(UnitType type)
        {
            if (type == UnitType.Normal)
            {
                return new NormalMonsterFactory();
            }
            else if (type == UnitType.Upgrade)
            {
                return new UpgradeMonsterFactory();
            }
            return null;
        }
    }

}