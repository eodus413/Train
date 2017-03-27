namespace ProjectCatMan
{
    public class UnitController
    {
        public UnitController(UnitBase unit)
        {
            this.unit = unit;
        }

        public UnitBase unit { get; private set; }
    }
}