using System;

namespace BeaterDemo
{
    public static class TimeUtils
    {
        public static long CurrentUnixTime() {

            var timespan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long)timespan.TotalSeconds;
            
        }
    }
}