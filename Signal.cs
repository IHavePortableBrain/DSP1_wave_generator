using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    [Serializable]
    public class Signal
    {
        private readonly Random random;
        public Signal AmplitudeModulating;
        public double ModulationK { get; set; } = Constants.Signal.ModulationK;// modulation coefficient
        public SignalType SignalType { get; set; }
        public double Amplitude { get; set; }
        public double Frequency { get; set; }
        double Period => 1 / Frequency;
        public int Length { get; set; } // sec
        public double DutyCycle { get; set; } // SignalType.Impulse related. 0..1
        public WaveFormat WaveFormat { get; set; }
        public int SampleCount => Length * WaveFormat.SampleRate;

        public Signal(Random random)
        {
            this.random = random;
        }

        public float[] Emit()
        {
            var result = new float[SampleCount];
            for (int n = 0; n < result.Length; n++)
            {
                float sample = EmitSample(n);
                result[n] = sample;
            }
            return result;
        }

        public float EmitSample(int n)
        {
            float result;
            switch (SignalType)
            {
                case SignalType.Sine:
                    result = EmitSineSample(n);
                    break;
                case SignalType.Impulse:
                    result = EmitImpulseSample(n);
                    break;
                case SignalType.Triangle:
                    result = EmitTriangleSample(n);
                    break;
                case SignalType.Sawtooth:
                    result = EmitSawtoothSample(n);
                    break;
                case SignalType.Noise:
                    result = EmitNoiseSample(n);
                    break;
                default:
                    result = EmitNoiseSample(n);
                    break;
            }
            return AmplitudeModulating == null ? result : result * (1 + AmplitudeModulating.EmitSample(n));
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
            return (float)((random.NextDouble() > 0.5 ? 1 : -1) * random.NextDouble() * Amplitude);
        }

        public override string ToString()
        {
            return $"{SignalType};freq={Frequency};ampl={Amplitude}";
        }

        public Signal Clone()
        {
            var result = (Signal)MemberwiseClone();
            result.WaveFormat = new WaveFormat(WaveFormat.SampleRate, WaveFormat.BitsPerSample, WaveFormat.Channels);
            return result;
        }
    }
}
