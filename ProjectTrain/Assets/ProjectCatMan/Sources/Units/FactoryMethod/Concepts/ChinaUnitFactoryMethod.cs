﻿namespace ProjectCatMan
{ 
    public class ChinaUnitFactoryMethod : UnitFactoryMethod
    {
        public override IUnitFactory GetFactory(UnitType type)
        {
            if (type == UnitType.Normal) return new NormalMonsterFactory();
            else if (type == UnitType.Upgrade) return new UpgradeMonsterFactory();
            else if (type == UnitType.Player) return new PlayerFactory();
            else return new EmptyMonsterFactory();
        }
    }
}