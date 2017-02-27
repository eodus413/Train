namespace ProjectTrain.Weapon
{
    public class Magazine
    {
        public bool empty { get { return current < 1; } }
        public int emptyAmount { get { return max - current; } }
        public int currentAmount { get { return current; } }
        public bool pull {get { return current == max; } }

        public void Reload(int ammoAmount)
        {
            if (ammoAmount < 0) return;

            current += ammoAmount;

            if (current > max) current = max;
        }
        
        public int ShotBullet(int amount)//넘어온 값만큼 총알을 사용 후 실제 사용한 수만큼 return
        {
            if (empty) return 0;

            int value = 0;

            if (current - amount > 0) value = amount;
            else value = current;

            current -= amount;

            return value;
        }

        int current;
        public readonly int max;
        public Magazine(int max)
        {
            this.max = max;
            this.current = max;
        }
    }
}