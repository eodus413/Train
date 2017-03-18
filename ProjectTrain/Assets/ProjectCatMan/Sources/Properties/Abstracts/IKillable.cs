namespace ProjectCatMan
{
    public interface IKillable : IUnitProperty
    {
        bool isLive { get; }
        void Killed();
    }
}