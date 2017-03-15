namespace ProjectCatMan
{
    public interface IKillable : IUnitProperty
    {
        UnitBase unit { get; }
        bool isLive { get; }
        void Killed();
    }
}