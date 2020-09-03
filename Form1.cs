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
        public readonly WaveFormat waveFormat = new WaveFormat(8000, 24, 1);
        public readonly string OutputDir = Path.Combine(Environment.CurrentDirectory, Constants.OutputDirName);
        private string OutputFileName => "file.wav";// Guid.NewGuid().ToString() + ".wav";

        public Form1()
        {
            Directory.CreateDirectory(OutputDir);
            InitializeComponent();
            Signal = new Signal()
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
            string tempFile = Path.Combine(OutputDir, OutputFileName);
            using (var fs = new FileStream(tempFile, FileMode.OpenOrCreate, FileAccess.Write))
            using (WaveFileWriter writer = new WaveFileWriter(fs, waveFormat))
            {
                var signal = Signal.Emit();
                writer.WriteSamples(signal, 0, signal.Length);
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
    }
}
