using System;

namespace PhysicsExperiments.Core
{
    public class GameTime
    {
        public GameTime(DateTime now, int milliseconds)
        {
            Time = now;
            MillisecondsElapsed = milliseconds;
        }

        public DateTime Time { get; private set; }
        public int MillisecondsElapsed { get; private set; }

        public double SecondsElapsedSince(DateTime time)
        {
            return Time.Subtract(time).TotalMilliseconds/1000;
        }
    }
}