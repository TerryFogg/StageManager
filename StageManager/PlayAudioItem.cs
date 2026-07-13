using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace StageManager
{
    using NAudio.Wave;
    using NAudio.Wave.SampleProviders;
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public enum FadeType
    {
        TwoSecondFade,
        FiveSecondFade
    }

    public partial class PlayAudioItem : UserControl
    {
        private float _progress;
        private bool _isPlaying;
        private const int RingDiameter = 50;
        private const int PlaySize = 16;
        private const int StopSize = 14;
        //public bool continousPlayItem { get; set; }
        private bool PlayingOrPlayed { get; set; }
        private WaveFileReader waveReader { get; set; }
        private WaveOutEvent outputDevice { get; set; }
        private Mp3FileReader mp3Reader { get; set; }
        private readonly Timer FadeTimer = new Timer();
        private int TimerTick = 100; // milliseconds
        private float CurrentFractionReduction = 0;
        private const float FractionReductionFor2SecondFade = 1/20f; // 2 seconds / 100 ms per tick
        private const float FractionReductionFor5SecondFade = 1/50f; // 5 seconds / 100 ms per tick
        private FadeType currentFadeType;
        private WaveStream _reader;


        private AudioFileReader audioFile;
        private FadeInOutSampleProvider fadeProvider;


        private readonly Timer _timer = new Timer();

        private float fadeStartVolume;
        public PlayAudioItem(System.IO.Stream stream, string Title)
        {
            InitializeComponent();
            IsPlaying = false;
            PlayingOrPlayed = false;
            BackColor = Color.Green;

            DoubleBuffered = true;
            Cursor = Cursors.Hand;


            audioFile = new AudioFileReader(fileName);

            fadeProvider = new FadeInOutSampleProvider(audioFile, true);


            if (DesignMode)
            {
                Caption = "01. Audio Cue One";

            }
            else
            {
                Caption = Title;
            }

            modernVolumeSlider1.ValueChanged += (s, e) =>
            {

                float vol = modernVolumeSlider1.Value / 100f;
                outputDevice.Volume = vol;
            };
            waveReader = new WaveFileReader(stream);
            outputDevice = new WaveOutEvent();
            outputDevice.Init(waveReader);

            FadeTimer.Tick +=Fade_timer_Tick;

            // Visually 
            _timer.Interval = 100;
            _timer.Tick += (s, e) => Invalidate();
            _timer.Start();

        }
        public void FadeAudio(FadeType fadeType)
        {
            currentFadeType = fadeType;
            fadeStartVolume = CurrentVolume;
            CurrentFractionReduction = 1.0f;
            FadeTimer.Interval = TimerTick;
            FadeTimer.Start();
        }
        public float CurrentVolume
        {
            get { return outputDevice.Volume; }
            set { outputDevice.Volume = value; }
        }

        private void Fade_timer_Tick(object sender, EventArgs e)
        {
            switch (currentFadeType)
            {
                case FadeType.TwoSecondFade:
                    CurrentFractionReduction -= FractionReductionFor2SecondFade;
                    break;
                case FadeType.FiveSecondFade:
                    CurrentFractionReduction -= FractionReductionFor5SecondFade;
                    break;
            }

            float newVolume = fadeStartVolume * CurrentFractionReduction; 

            // Allow 0.1f as the minimum volume to avoid floating-point precision issues.
            // If the volume is less than or equal to 0.1f, stop the timer and reset the volume to 1.0f.
            if (newVolume > 0.1f)
            {
                CurrentVolume  = newVolume;
            }
            else
            {
                FadeTimer.Stop();
                CurrentVolume = 0f;
                StopAudio();
            }
        }

        private string _caption = "";

        public string Caption
        {
            get => _caption;
            set
            {
                _caption = value;
                Invalidate();
            }
        }

        public bool IsPlaying
        {
            get => _isPlaying;
            set
            {
                _isPlaying = value;
                Invalidate();
            }
        }
        public void StartAudio()
        {
            StopAudio();

            // Save as current audio item in the StageManagerForm
            StageManagerForm stageManagerForm = this.FindForm() as StageManagerForm;
            stageManagerForm.CurrentAudioItem = this;

            PlayingOrPlayed = true;
            BackColor = Color.Cyan;
            // Stop any currently playing audio item
            outputDevice.Volume = modernVolumeSlider1.Value / 100f;
            waveReader.Position = 0;
            outputDevice.Play();
        }

        public void FadeAudio2(FadeType fadeType)
        {
            int duration =
                fadeType == FadeType.TwoSecondFade
                ? 2000
                : 5000;

            fadeProvider.BeginFadeOut(duration);

            Task.Run(async () =>
            {
                await Task.Delay(duration);

                if (InvokeRequired)
                {
                    Invoke(new Action(StopAudio));
                }
                else
                {
                    StopAudio();
                }
            });
        }


        public void StopAudio()
        {
            outputDevice.Stop();
            BackColor = Color.Cyan;
            IsPlaying = false;
        }
        public void Reset()
        {
            StopAudio();
            BackColor = Color.Green;
            waveReader.Position = 0;
            Invalidate();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            if (IsPlaying)
            {
                StopAudio();
            }
            else
            {
                StartAudio();
            }
            IsPlaying = !IsPlaying;

            Invalidate();
        }

        #region Drawing and Painting
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            const int RingThickness = 6;
            const float StartAngle = -90f;

            // Outer border
            Rectangle borderRect = new Rectangle(
                0,
                0,
                Width - 1,
                Height - 1);

            using (Pen borderPen = new Pen(Color.LightGray))
            {
                g.DrawRectangle(borderPen, borderRect);
            }

            // Fixed-size ring centered in the control
            Rectangle ringRect = new Rectangle(
                (Width - RingDiameter) / 2 + RingThickness / 2,
                (Height - RingDiameter) / 2 + RingThickness / 2,
                RingDiameter - RingThickness,
                RingDiameter - RingThickness);

            // Centre of ring
            int centerX = ringRect.Left + ringRect.Width / 2;
            int centerY = ringRect.Top + ringRect.Height / 2;


            // Calculate playback progress
            float progress = 0f;

            if (waveReader != null &&
                waveReader.TotalTime.TotalMilliseconds > 0)
            {
                progress =
                    (float)(waveReader.CurrentTime.TotalMilliseconds /
                            waveReader.TotalTime.TotalMilliseconds);
            }

            progress = Math.Max(0f, Math.Min(1f, progress));

            // Background ring
            using (Pen pen = new Pen(Color.Gainsboro, RingThickness))
            {
                g.DrawArc(
                    pen,
                    ringRect,
                    StartAngle,
                    360f);
            }

            // Progress ring
            using (Pen pen = new Pen(Color.DodgerBlue, RingThickness))
            {
                g.DrawArc(
                    pen,
                    ringRect,
                    StartAngle,
                    360f * progress);
            }

            // Draw Play / Stop icon
            if (_isPlaying)
            {
                Rectangle stopRect = new Rectangle(
                    centerX - StopSize / 2,
                    centerY - StopSize / 2,
                    StopSize,
                    StopSize);

                g.FillRectangle(Brushes.Black, stopRect);
            }
            else
            {
                Point[] triangle =
                {
            new Point(centerX - PlaySize / 2,
                      centerY - PlaySize / 2),

            new Point(centerX - PlaySize / 2,
                      centerY + PlaySize / 2),

            new Point(centerX + PlaySize / 2,
                      centerY)
        };

                g.FillPolygon(Brushes.Black, triangle);
            }

            // Draw top-left text
            Rectangle textRect = new Rectangle(
                8,
                4,
                Width - 16,
                Height - 8);
            Font soundText = new Font("Arial", 10, FontStyle.Regular);
            TextRenderer.DrawText(
                g,
                Caption,
                soundText,
                textRect,
                ForeColor,
                TextFormatFlags.Left |
                TextFormatFlags.Top |
                TextFormatFlags.WordBreak);
        }

        private void DrawPlay(Graphics g)
        {
            Point[] triangle =
            {
        new Point((Width - PlaySize) / 2,
                  (Height - PlaySize) / 2),

        new Point((Width - PlaySize) / 2,
                  (Height + PlaySize) / 2),

        new Point((Width + PlaySize) / 2,
                  Height / 2)
    };

            g.FillPolygon(Brushes.Black, triangle);
        }

        private void DrawStop(Graphics g)
        {
            Rectangle rect = new Rectangle(
                (Width - StopSize) / 2,
                (Height - StopSize) / 2,
                StopSize,
                StopSize);

            g.FillRectangle(Brushes.Black, rect);
        }
        #endregion
    }
}
