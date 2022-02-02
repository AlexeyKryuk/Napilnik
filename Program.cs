namespace Napilnik
{
    class Program
    {
        public void Play()
        {
            _effects.StartEnableAnimation();
        }

        public void Stop()
        {
            _pool.Free(this);
        }

        static void Main(string[] args)
        {
        }
    }
}
