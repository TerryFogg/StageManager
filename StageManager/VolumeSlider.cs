using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StageManager
{
    public partial class ModernVolumeSlider : Control
    {
        private int _value = 50;
        private bool _dragging;
        [Category("Behavior")]
        public event EventHandler ValueChanged;

        [Category("Behavior")]
        public int Value
        {
            get => _value;
            set
            {
                int newValue = Math.Max(0, Math.Min(100, value));

                if (_value != newValue)
                {
                    _value = newValue;
                    Invalidate();
                    ValueChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public Color TrackColor { get; set; } = Color.FromArgb(60, 60, 60);
        public Color FillColor { get; set; } = Color.FromArgb(29, 185, 84); // Spotify green
        public Color ThumbColor { get; set; } = Color.White;

        public ModernVolumeSlider()
        {
            DoubleBuffered = true;
            Height = 40;
            Width = 300;

            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint,
                true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int textboxWidth = 50;
            int sliderWidth = Width - textboxWidth - 10;

            Rectangle trackRect =
                new Rectangle(10, Height / 2 - 3, sliderWidth - 20, 6);

            float percent = _value / 100f;

            Rectangle fillRect =
                new Rectangle(
                    trackRect.X,
                    trackRect.Y,
                    (int)(trackRect.Width * percent),
                    trackRect.Height);

            using (GraphicsPath trackPath = RoundedRect(trackRect, 6))
            {
                using (SolidBrush brush = new SolidBrush(TrackColor))
                    g.FillPath(brush, trackPath);
            }

            if (fillRect.Width > 0)
            {
                using (GraphicsPath fillPath = RoundedRect(fillRect, 6))
                {
                    using (SolidBrush brush = new SolidBrush(FillColor))
                        g.FillPath(brush, fillPath);
                }
            }

            int thumbSize = 16;

            int thumbX =
                trackRect.X +
                (int)(trackRect.Width * percent) -
                thumbSize / 2;

            int thumbY = trackRect.Y + trackRect.Height / 2 - thumbSize / 2;

            using (SolidBrush brush = new SolidBrush(ThumbColor))
                g.FillEllipse(brush, thumbX, thumbY, thumbSize, thumbSize);

            using (Pen pen = new Pen(Color.LightGray))
                g.DrawEllipse(pen, thumbX, thumbY, thumbSize, thumbSize);

            Rectangle textRect =
                new Rectangle(
                    sliderWidth,
                    0,
                    textboxWidth,
                    Height);

            TextRenderer.DrawText(
                g,
                _value.ToString(),
                Font,
                textRect,
                ForeColor,
                TextFormatFlags.VerticalCenter |
                TextFormatFlags.HorizontalCenter);

            DrawVolumeIcon(g, new Rectangle(5, 8, 20, 20));
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            _dragging = true;
            UpdateValue(e.X);
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_dragging)
                UpdateValue(e.X);

            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _dragging = false;
            base.OnMouseUp(e);
        }

        private void UpdateValue(int mouseX)
        {
            int sliderWidth = Width - 60;
            int usableWidth = sliderWidth - 20;

            int x = Math.Max(10, Math.Min(10 + usableWidth, mouseX));

            Value = (int)(((float)(x - 10) / usableWidth) * 100f);
        }

        private GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            int diameter = radius * 2;

            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);

            path.CloseFigure();

            return path;
        }
        private void DrawVolumeIcon(Graphics g, Rectangle r)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                // Speaker body
                PointF[] speaker =
                {
            new PointF(r.X,                 r.Y + r.Height * 0.35f),
            new PointF(r.X + r.Width*0.25f,r.Y + r.Height * 0.35f),
            new PointF(r.X + r.Width*0.55f,r.Y),
            new PointF(r.X + r.Width*0.55f,r.Bottom),
            new PointF(r.X + r.Width*0.25f,r.Y + r.Height * 0.65f),
            new PointF(r.X,                 r.Y + r.Height * 0.65f)
        };

                g.FillPolygon(brush, speaker);
            }

            using (Pen pen = new Pen(Color.White, 2f))
            {
                pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

                if (Value == 0)
                {
                    g.DrawLine(
                        pen,
                        r.Right - 10,
                        r.Y + 3,
                        r.Right - 2,
                        r.Bottom - 3);

                    g.DrawLine(
                        pen,
                        r.Right - 2,
                        r.Y + 3,
                        r.Right - 10,
                        r.Bottom - 3);
                }
                else if (Value < 50)
                {
                    g.DrawArc(
                        pen,
                        r.X + r.Width * 0.45f,
                        r.Y + 4,
                        10,
                        r.Height - 8,
                        -45,
                        90);
                }
                else
                {
                    g.DrawArc(
                        pen,
                        r.X + r.Width * 0.45f,
                        r.Y + 4,
                        10,
                        r.Height - 8,
                        -45,
                        90);

                    g.DrawArc(
                        pen,
                        r.X + r.Width * 0.45f,
                        r.Y,
                        18,
                        r.Height,
                        -45,
                        90);
                }
            }
        }
    }
}