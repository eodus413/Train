namespace Entity
{
    public struct AttackData
    {
        public AttackData(EntityBase attaker, int damage, Direction direction)
        {
            this.attaker = attaker;
            this.damage = damage;
            this.direction = direction;
        }
        public EntityBase attaker { get; private set; } //공격 시전한 Entity
        public int damage { get; private set; }  //공격력
        public Direction direction { get; private set; } //공격 방향
    }
}