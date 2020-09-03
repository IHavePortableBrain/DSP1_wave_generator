using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public static class SignalExtensions
    {
        /// <summary>
        /// Emits polysignal.
        /// </summary>
        public static float[] Emit(this IEnumerable<Signal> signals)
        {
            if (signals.Select(s => s.SampleCount).ToHashSet().Count != 1)
            {
                throw new ArgumentException("All signals must have same sample count.");
            }

            var samples = new float[signals.First().SampleCount];
            Parallel.ForEach(signals, signal =>
            {
                for (int n = 0; n < samples.Length; n++)
                {
                    samples[n] += signal.EmitSample(n);
                }
            });

            return samples;
        }
    }
}
