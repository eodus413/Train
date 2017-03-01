namespace ProjectTrain
{
    public interface IAttackable
    {
        bool isLive { get; }
        int hp { get; }
        void Attacked(AttackData data);
    }
}