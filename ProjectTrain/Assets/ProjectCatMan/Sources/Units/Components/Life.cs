using UnityEngine;

namespace ProjectCatMan
{
    public class Life
    {
        public Life(int hp, Dead deadEvent)
        {
            baseHealth = new Health(hp);
            health = new Health(hp);
            this.deadEvent += deadEvent;
        }

        readonly IAttackable baseHealth;
        IAttackable health;
        //IAttackable mental
        //IAttackable highdration

        public delegate void Dead();
        public event Dead deadEvent;

        public void Attacked(AttackData data)
        {
            health.Attacked(data);

            if (isDead) deadEvent();
        }

        public bool isLive
        {
            get { return health.value > 0; }
        }
        public bool isDead
        {
            get { return health.value <= 0; }
        }
    }
}