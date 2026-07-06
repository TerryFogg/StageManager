using DocumentFormat.OpenXml.Drawing;
using NAudio.Wave;
using StageManager;
using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;

namespace StageManager
{
    public partial class PlayItem : UserControl
    {
        public bool continousPlayItem { get; set; }
        private bool PlayingOrPlayed { get; set; }
        private WaveFileReader waveReader { get; set; }
        private WaveOutEvent outputDevice { get; set; }
        private Mp3FileReader mp3Reader { get; set; }

        public PlayItem(System.IO.Stream stream, string Title, bool IsContinuous)
        {
            this.InitializeComponent();

            continousPlayItem = IsContinuous;
            this.textBox1.Text = Title;
            this.PlayingOrPlayed = false;
            playButton.BackColor = Color.Green;

            outputDevice = new WaveOutEvent();
            waveReader = new WaveFileReader(stream);
            outputDevice.Init(waveReader);


            audioButton1.Reader = waveReader;

            audioButton1.PlayClicked +=AudioButton1_PlayClicked;
            audioButton1.StopClicked +=AudioButton1_StopClicked;
        }

        private void AudioButton1_StopClicked(object sender, EventArgs e)
        {

            outputDevice.Stop();
            waveReader.Position = 0;
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (this.audioButton1.IsPlaying)
            {
                Stop();
            }
            else
            {
                //StartAudio();
            }
        }
        private void AudioButton1_PlayClicked(object sender, EventArgs e)
        {

            //StartAudio();
        }

        public float CurrentVolume
        {
            get { return outputDevice.Volume; }
            set { outputDevice.Volume = value; }
        }


        public void Reset()
        {
            outputDevice.Stop();
            playButton.BackColor = Color.Green;
            this.audioButton1.IsPlaying = false;
            this.audioButton1.BackColor = Color.Green;
            this.PlayingOrPlayed = false;
            waveReader.Position = 0;
        }

        public void Stop()
        {
            outputDevice.Stop();
            this.audioButton1.IsPlaying = false;
            this.PlayingOrPlayed = true;
            waveReader.Position = 0;
        }


        //private void StartAudio()
        //{
        //    if (!PlayingOrPlayed)
        //    {
        //        StageManagerForm stageManagerForm = this.FindForm() as StageManagerForm;

        //        if (stageManagerForm.CurrentPlayItem != null)
        //        {
        //            stageManagerForm.CurrentPlayItem.Stop();
        //        }
        //        stageManagerForm.CurrentPlayItem = this;
        //        playButton.BackColor = Color.Cyan;
        //    }
        //    playButton.BackColor = Color.Cyan;
        //    this.playButton.Enabled = true;
        //    outputDevice.Volume = 1.0f;
        //    waveReader.Position = 0;
        //    outputDevice.Play();

        //    this.audioButton1.IsPlaying = true;
        //    this.PlayingOrPlayed = true;
        //    this.audioButton1.BackColor = Color.Cyan;
        //}
    }
}
