using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StageManager
{
    public partial class AudioButton : Control
    {
        public event EventHandler PlayClicked;
        public event EventHandler StopClicked;
               private readonly Timer _timer = new Timer();
 private WaveStream _reader;
        public AudioButton()
        {
            InitializeComponent();
            DoubleBuffered = true;
            _timer.Interval = 100;
            _timer.Tick += (s, e) => Invalidate();
            _timer.Start();
            BackColor = Color.Green;
        }

        public WaveStream Reader
        {
            get => _reader;
            set
            {
                _reader = value;
                Invalidate();
            }
        }
        public bool IsPlaying
        {
            get;
            set;
        }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            if (IsPlaying)
            {
                IsPlaying = false;
                StopClicked?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                IsPlaying = true;
                BackColor = Color.Cyan;
                PlayClicked?.Invoke(this, EventArgs.Empty);
            }

            Invalidate();
        }

        public void PerformClick()
        {
            OnClick(EventArgs.Empty);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode =
                System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            float progress = 0;

            if (_reader != null &&
                _reader.TotalTime.TotalMilliseconds > 0)
            {
                progress = (float)
                    (_reader.CurrentTime.TotalMilliseconds /
                     _reader.TotalTime.TotalMilliseconds);
            }
            Rectangle ringRect =
                new Rectangle(4, 4, Width + 8, Height + 8);

            using (var pen = new Pen(Color.LightGray, 6))
                e.Graphics.DrawArc(pen, ringRect, 0, 360);

            using (var pen = new Pen(Color.DodgerBlue, 6))
                e.Graphics.DrawArc(
                    pen,
                    ringRect,
                    -90,
                    360 * progress);

            if (IsPlaying)
                DrawStop(e.Graphics);
            else
                DrawPlay(e.Graphics);
        }
        private void DrawStop(Graphics g)
        {
            int sz = Width / 3;

            Rectangle r = new Rectangle(
                (Width - sz) / 2,
                (Height - sz) / 2,
                sz,
                sz);

            g.FillRectangle(Brushes.Black, r);
        }

        private void DrawPlay(Graphics g)
        {
            int sz = Width / 3;

            Point[] triangle =
            {
            new Point((Width - sz)/2, (Height - sz)/2),
            new Point((Width - sz)/2, (Height + sz)/2),
            new Point((Width + sz)/2, Height/2)
        };

            g.FillPolygon(Brushes.Black, triangle);
        }


        protected override void OnMouseClick(MouseEventArgs e)
        {
            int cx = Width / 2;
            int cy = Height / 2;

            double dx = e.X - cx;
            double dy = e.Y - cy;

            double distance = Math.Sqrt(dx * dx + dy * dy);

            if (distance <= (Width / 2) + 10)
            {
                OnClick(EventArgs.Empty);
            }

            base.OnMouseClick(e);
        }

    }
}

