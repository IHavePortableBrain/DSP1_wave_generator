using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Signal
    {
        private readonly Random random;

        public SignalType SignalType { get; set; }
        public double Amplitude { get; set; }
        public double Frequency { get; set; }
        double Period => 1 / Frequency;
        public int Length { get; set; } // sec
        public double DutyCycle { get; set; } // SignalType.Impulse related. 0..1
        public WaveFormat WaveFormat { get; set; }

        public Signal(Random random)
        {
            this.random = random;
        }

        public float[] Emit()
        {
            var result = new float[Length * WaveFormat.SampleRate];
            for (int n = 0; n < result.Length; n++)
            {
                float sample = EmitSample(n);
                result[n] = sample;
            }
            return result;
        }

        public float EmitSample(int n)
        {
            switch (SignalType)
            {
                case SignalType.Sine:
                    return EmitSineSample(n);
                case SignalType.Impulse:
                    return EmitImpulseSample(n);
                case SignalType.Triangle:
                    return EmitTriangleSample(n);
                case SignalType.Sawtooth:
                    return EmitSawtoothSample(n);
                case SignalType.Noise:
                    return EmitNoiseSample(n);
                default:
                    return EmitNoiseSample(n);
            }
        }

        private float EmitSineSample(int n)
        {
            return (float)(Amplitude * Math.Sin(2 * Math.PI * n * Frequency / WaveFormat.SampleRate));
        }

        private float EmitImpulseSample(int n)
        {
            return (float)(Amplitude * (((n / (double)WaveFormat.SampleRate) % Period) / Period > DutyCycle ? 0 : 1));
        }

        private float EmitTriangleSample(int n)
        {
            return (float)(2 * Amplitude / Math.PI * Math.Asin(Math.Sin(2 * Math.PI * Frequency * n / WaveFormat.SampleRate)));
        }

        private float EmitSawtoothSample(int n)
        {
            return (float)(-2 * Amplitude / Math.PI * Math.Atan(1 / Math.Tan(Math.PI * Frequency * n / WaveFormat.SampleRate)));
        }

        private float EmitNoiseSample(int n)
        {
            return (float)(random.NextDouble() * Amplitude);
        }
    }
}
