using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Signal
    {
        public float Amplitude { get; set; }
        public float Frequency { get; set; }
        public int Length { get; set; } // sec
        public WaveFormat WaveFormat { get; set; }

        public float[] EmitSine()
        {
            var result = new float[Length * WaveFormat.SampleRate];
            for (int n = 0; n < result.Length; n++)
            {
                float sample = (float)(Amplitude * Math.Sin((2 * Math.PI * n * Frequency) / WaveFormat.SampleRate));
                result[n] = sample;
            }
            return result;
        }
    }
}
