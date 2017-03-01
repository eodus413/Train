namespace ProjectTrain
{
    public class State
    {
        private int current = 0;

        private const int idle = 0;
        public const int move = 1;
        public const int attack = 2;
        public const int action = 4;
        public const int reload = 8;

        public bool Is(int state)
        {
            return (state & current) != idle;
        }
        public void Set(int state)
        {
            current |= state;
        }
        public void SetIdle()
        {
            current = idle;
        }
        public bool IsIdle()
        {
            return current == idle;
        }
        public void Remove(int state)
        {
            current -= state;
        }
    }
}