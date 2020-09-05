namespace NAudio.Wave
{
    public class NullWaveProvider : IWaveProvider
    {
        public WaveFormat WaveFormat { get; }

        public NullWaveProvider(WaveFormat waveFormat)
        {
            WaveFormat = waveFormat;
        }

        public int Read(byte[] buffer, int offset, int count)
        {
            return 0;
        }
    }
}
