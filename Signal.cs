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
        public SignalType SignalType { get; set; }
        public double Amplitude { get; set; }
        public double Frequency { get; set; }
        double Period => 1 / Frequency;
        public int Length { get; set; } // sec
        public double DutyCycle { get; set; } // SignalType.Impulse related. 0..1
        public WaveFormat WaveFormat { get; set; }

        public float[] Emit()
        {
            switch (SignalType)
            {
                case SignalType.Sine:
                    return EmitSine();
                case SignalType.Impulse:
                    return EmitImpulse();
                case SignalType.Triangle:
                    break;
                case SignalType.Sawtooth:
                    break;
                case SignalType.Noise:
                    break;
                default:
                    return EmitSine();
            }
            return EmitSine(); // todo remove
        }

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

        public float[] EmitImpulse()
        {
            var result = new float[Length * WaveFormat.SampleRate];
            for (int n = 0; n < result.Length; n++)
            {
                float sample = (float)(Amplitude *  (((n / (double)WaveFormat.SampleRate) % Period) / Period > DutyCycle ? 0 : 1));
                result[n] = sample;
            }
            return result;
        }
    }
}
