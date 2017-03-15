namespace ProjectCatMan
{
    public abstract class UnitFactoryMethod
    {
        public abstract IUnitFactory GetFactory(UnitType type);
    }
}