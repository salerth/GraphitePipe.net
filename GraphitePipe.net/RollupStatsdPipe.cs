using System;
using System.Linq;

namespace Rbi.Monitoring.Graphite
{
    public class RollupStatsdPipe : StatsdPipe
    {
        public RollupStatsdPipe(string host, int port)
            : base(host, port)
        {

        }

        public bool Timing(Key key, int value)
        {
            return Timing(key, value, 1.0);
        }

        public bool Timing(Key key, int value, double sampleRate)
        {
            var pass = Send(sampleRate, String.Format("{0}:{1:d}|ms", key.FullKeyName, value)) ? true : false;
            pass = Send(sampleRate, String.Format("{0}:{1:d}|ms", key.DataCentreKeyName, value)) ? pass : false;
            pass = Send(sampleRate, String.Format("{0}:{1:d}|ms", key.VerticalKeyName, value)) ? pass : false;

            return pass;
        }

        public bool Decrement(Key key)
        {
            return Increment(key, -1, 1.0);
        }

        public bool Decrement(Key key, int magnitude)
        {
            return Decrement(key, magnitude, 1.0);
        }

        public bool Decrement(Key key, int magnitude, double sampleRate)
        {
            magnitude = magnitude < 0 ? magnitude : -magnitude;
            return Increment(key, magnitude, sampleRate);
        }

        public bool Decrement(params Key[] keys)
        {
            return Increment(-1, 1.0, keys);
        }

        public bool Decrement(int magnitude, params Key[] keys)
        {
            magnitude = magnitude < 0 ? magnitude : -magnitude;
            return Increment(magnitude, 1.0, keys);
        }

        public bool Decrement(int magnitude, double sampleRate, params Key[] keys)
        {
            magnitude = magnitude < 0 ? magnitude : -magnitude;
            return Increment(magnitude, sampleRate, keys);
        }

        public bool Increment(Key key)
        {
            return Increment(key, 1, 1.0);
        }

        public bool Increment(Key key, int magnitude)
        {
            return Increment(key, magnitude, 1.0);
        }

        public bool Increment(Key key, int magnitude, double sampleRate)
        {
            var pass = Send(String.Format("{0}:{1}|c", key.FullKeyName, magnitude), sampleRate) ? true : false;
            pass = Send(String.Format("{0}:{1}|c", key.DataCentreKeyName, magnitude), sampleRate) ? pass : false;
            pass = Send(String.Format("{0}:{1}|c", key.VerticalKeyName, magnitude), sampleRate) ? pass : false;

            return pass;
        }

        public bool Increment(int magnitude, double sampleRate, params Key[] keys)
        {
            var pass = Send(sampleRate, keys.Select(key => String.Format("{0}:{1}|c", key.FullKeyName, magnitude)).ToArray())
                            ? true
                            : false;

            pass = Send(sampleRate, keys.Select(key => String.Format("{0}:{1}|c", key.DataCentreKeyName, magnitude)).ToArray())
                ? pass
                : false;

            pass = Send(sampleRate, keys.Select(key => String.Format("{0}:{1}|c", key.VerticalKeyName, magnitude)).ToArray())
                ? pass
                : false;

            return pass;
        }
    }
}
