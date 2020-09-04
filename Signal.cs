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
        public Signal FrequencyModulating;
        public double ModulationK { get; set; } = Constants.Signal.ModulationK;// modulation coefficient, not used but can be
        public SignalType SignalType { get; set; }
        public double Amplitude { get; set; }
        public double Frequency { get; set; }
        double Period => 1 / Frequency;
        public int Length { get; set; } // sec
        public double DutyCycle { get; set; } // SignalType.Impulse related. 0..1
        public WaveFormat WaveFormat { get; set; }
        public int SampleCount => Length * WaveFormat.SampleRate;
        public double Fi { get; set; }

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
            Fi = default;
            if (FrequencyModulating != null)
            {
                FrequencyModulating.Fi = default;
            }
            if (AmplitudeModulating != null)
            {
                AmplitudeModulating.Fi = default;
            }
            return result;
        }

        public float EmitSample(int n)
        {
            // Frequency = (1 + FrequencyModulating?.EmitSample(n)) * Frequency ?? Frequency;
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
            Fi += 2 * Math.PI * 1 * (1 + (FrequencyModulating?.EmitSample(n) ?? 0)) * Frequency / WaveFormat.SampleRate;
            return (float)(Amplitude * Math.Sin(Fi));
        }

        private float EmitImpulseSample(int n)
        {
            var T = Period / (1 + (FrequencyModulating?.EmitSample(n) ?? 0));
            return (float)(Amplitude * (((n / (double)WaveFormat.SampleRate) % T) / T > DutyCycle ? 0 : 1));
        }

        private float EmitTriangleSample(int n)
        {
            Fi += 2 * Math.PI * (1 + (FrequencyModulating?.EmitSample(n) ?? 0)) * Frequency * 1 / WaveFormat.SampleRate;
            return (float)(2 * Amplitude / Math.PI * Math.Asin(Math.Sin(Fi)));
        }

        private float EmitSawtoothSample(int n)
        {
            Fi += Math.PI * (1 + (FrequencyModulating?.EmitSample(n) ?? 0)) * Frequency * 1 / WaveFormat.SampleRate;
            return (float)(-2 * Amplitude / Math.PI * Math.Atan(1 / Math.Tan(Fi)));
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
