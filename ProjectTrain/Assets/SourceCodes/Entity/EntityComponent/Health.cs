namespace Entity
{
    //Health 인터페이스
    public interface IHealth
    {
        int baseHp { get; }
        int hp { get; }
        void TakeDamage(int damage);
        void Regeneration(int value);
    }


    //Entity 의 체력
    public class DefaultHealth : IHealth
    {
        //생성자
        public DefaultHealth(int hp)
        {
            this._baseHp = hp;
            this.hp = hp;
        }

        //인터페이스
        public int baseHp { get { return _baseHp; } }

        public int hp
        {
            get { return _hp; }
            private set { _hp = value; }
        }

        public void TakeDamage(int damage)
        {
            if (damage <= 0) return;
            hp -= damage;
        }
        public void Regeneration(int value)
        {
            if (value <= 0) return;
            hp += value;
        }

        //구현
        private readonly int _baseHp;
        private int _hp;
    }
}