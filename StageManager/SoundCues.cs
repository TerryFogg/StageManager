using System;
using System.Windows.Forms;

namespace StageManager
{
    public partial class SoundCues : UserControl
    {
        public SoundCues()
        {
            InitializeComponent();
        }
        private void SoundCues_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            this.flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            this.flowLayoutPanel1.AutoScroll = true;
        }
        internal void AddPlayItem(PlayAudioItem pi)
        {
            this.flowLayoutPanel1.Controls.Add(pi);
        }

        internal void Reset()
        {
            foreach (object c in flowLayoutPanel1.Controls)
            {
                if (c is PlayAudioItem playAudioItem)
                {
                    playAudioItem.Reset();
                }
            }
        }
        internal void ClearPlayItems()
        {
            flowLayoutPanel1.Controls.Clear();
        }
    }
}