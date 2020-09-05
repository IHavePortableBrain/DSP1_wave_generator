using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public partial class Form1 : Form
    {
        public Signal Signal;
        public Signal AmplitudeModulatingSignal;
        public Signal FrequncyModulatingSignal;
        public List<Signal> _polysignal = new List<Signal>();
        public readonly WaveFormat waveFormat = new WaveFormat(44100, 24, 1);
        public readonly string OutputDir = Path.Combine(Environment.CurrentDirectory, Constants.OutputDirName);
        private string OutputFileName => "file.wav";// Guid.NewGuid().ToString() + ".wav";

        public Form1()
        {
            Directory.CreateDirectory(OutputDir);
            InitializeComponent();
            Signal = new Signal(new Random())
            {
                SignalType = ((IEnumerable<SignalType>)cbSignalType.DataSource).First(),
                Length = Constants.Signal.Length,
                Amplitude = (double)edtAmplitude.Value,
                Frequency = (double)edtFrequency.Value,
                WaveFormat = waveFormat,
                DutyCycle = (double)edtDutyCycle.Value,
            };
            BindControls();
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            var samples = Signal.Emit();
            WriteToFile(samples, $"{Signal}.wav");
        }

        private void btnRecordPolysignal_Click(object sender, EventArgs e)
        {
            if (_polysignal.Count > 1)
            {
                var samples = _polysignal.Emit();
                var fileName = string.Join("+", _polysignal.Select(p => p.ToString()));
                WriteToFile(samples, $"{fileName}.wav");
            }
            else
            {
                MessageBox.Show("Polysignal component count must be > 1.");
            }
        }

        private void WriteToFile(float[] samples, string fileName)
        {
            string tempFile = Path.Combine(OutputDir, fileName);
            //WaveFileWriter.CreateWaveFile(tempFile, new NullWaveProvider(waveFormat));
            using (var fs = new FileStream(tempFile, FileMode.Create, FileAccess.Write))
            using (WaveFileWriter writer = new WaveFileWriter(fs, waveFormat))
            {
                //var bytes = new byte[samples.Length * 4];
                //Buffer.BlockCopy(samples, 0, bytes, 0, bytes.Length);
                //writer.Write(bytes, 0, bytes.Length);
                //writer.WriteSample(samples[0]);
                writer.WriteSamples(samples, 0, samples.Length);
            }
        }

        protected void BindControls()
        {
            edtAmplitude.DataBindings.Add(new Binding
                (nameof(edtAmplitude.Value), Signal, nameof(Signal.Amplitude)));
            edtFrequency.DataBindings.Add(new Binding
                (nameof(edtFrequency.Value), Signal, nameof(Signal.Frequency)));
            cbSignalType.DataBindings.Add(new Binding
                (nameof(cbSignalType.SelectedItem), Signal, nameof(Signal.SignalType)));
            edtDutyCycle.DataBindings.Add(new Binding
                (nameof(edtDutyCycle.Value), Signal, nameof(Signal.DutyCycle)));
        }

        private void btnAddToPolysignal_Click(object sender, EventArgs e)
        {
            _polysignal.Add(Signal.Clone());
            lblPolysignalCountValue.Text = _polysignal.Count.ToString(); // todo refactor, use event or model binding or smth else
        }

        private void btnClearPolysignal_Click(object sender, EventArgs e)
        {
            _polysignal.Clear();
            lblPolysignalCountValue.Text = _polysignal.Count.ToString(); // todo refactor, use event or model binding or smth else
            Signal.AmplitudeModulating = null;
            Signal.FrequencyModulating = null;
        }

        private void btnSetAsAmplModulating_Click(object sender, EventArgs e)
        {
            Signal.AmplitudeModulating = null; // crutch?
            Signal.FrequencyModulating = null; // crutch?
            AmplitudeModulatingSignal = Signal.Clone();
            Signal.AmplitudeModulating = AmplitudeModulatingSignal;
            foreach (var signal in _polysignal)
            {
                signal.AmplitudeModulating = AmplitudeModulatingSignal;
            }
        }

        private void btnSetFrequencyMoulatingSignal_Click(object sender, EventArgs e)
        {
            Signal.AmplitudeModulating = null; // crutch?
            Signal.FrequencyModulating = null; // crutch?
            FrequncyModulatingSignal = Signal.Clone();
            Signal.FrequencyModulating = FrequncyModulatingSignal;
            foreach (var signal in _polysignal)
            {
                signal.FrequencyModulating = FrequncyModulatingSignal;
            }
        }
    }
}
