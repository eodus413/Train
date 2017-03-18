using System.Collections.Generic;

namespace ProjectCatMan
{
    public abstract class UnitFactoryMethod
    {
        public abstract IUnitFactory GetFactory(UnitType type);
    }
}