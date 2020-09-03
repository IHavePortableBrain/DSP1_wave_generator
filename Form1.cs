using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public partial class Form1 : Form
    {
        public Signal Signal;
        public List<Signal> _polysignal = new List<Signal>();
        public readonly WaveFormat waveFormat = new WaveFormat(8000, 24, 1);
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
                DutyCycle = Constants.Signal.DutyCycle,
            };
            BindControls();
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            var samples = Signal.Emit();
            WriteToFile(samples);
        }

        private void btnRecordPolysignal_Click(object sender, EventArgs e)
        {
            if (_polysignal.Count > 1)
            {
                var samples = _polysignal.Emit();
                WriteToFile(samples);
            }
            else
            {
                MessageBox.Show("Polysignal component count must be > 1.");
            }
        }

        private void WriteToFile(float[] samples)
        {
            string tempFile = Path.Combine(OutputDir, OutputFileName);
            using (var fs = new FileStream(tempFile, FileMode.OpenOrCreate, FileAccess.Write))
            using (WaveFileWriter writer = new WaveFileWriter(fs, waveFormat))
            {
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
        }

        private void btnAddToPolysignal_Click(object sender, EventArgs e)
        {
            _polysignal.Add(Signal);
            lblPolysignalCountValue.Text = _polysignal.Count.ToString(); // todo refactor, use event or model binding or smth else
        }

        private void btnClearPolysignal_Click(object sender, EventArgs e)
        {
            _polysignal.Clear();
            lblPolysignalCountValue.Text = _polysignal.Count.ToString(); // todo refactor, use event or model binding or smth else
        }
    }
}
