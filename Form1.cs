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
        WaveFormat waveFormat = new WaveFormat(8000, 24, 1);
        public Signal _signal;
        string _outputDir = Path.Combine(Environment.CurrentDirectory, Constants.OutputDirName);
        private string OutputFileName => Guid.NewGuid().ToString() + ".wav";

        public Form1()
        {
            Directory.CreateDirectory(_outputDir);
            InitializeComponent();

            _signal = new Signal()
            {
                Length = 10,
                Amplitude = (float)edtAmplitude.Value,
                Frequency = (float)edtFrequency.Value,
                WaveFormat = waveFormat,
            };
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            string tempFile = Path.Combine(_outputDir, OutputFileName);
            using (var fs = new FileStream(tempFile, FileMode.OpenOrCreate, FileAccess.Write))
            using (WaveFileWriter writer = new WaveFileWriter(fs, waveFormat))
            {
                var sine = _signal.EmitSine();
                writer.WriteSamples(sine, 0, sine.Length);
            }
        }
    }
}
