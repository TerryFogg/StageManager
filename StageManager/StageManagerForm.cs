using DocumentFormat.OpenXml.Office2013.Drawing.Chart;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace StageManager
{
    public partial class StageManagerForm : Form
    {
        public PlayAudioItem CurrentAudioItem { get; set; }

        private float CurrentFractionReduction = 0;
        private const float FractionReductionFor2SecondFade = 1/20f; // 2 seconds / 100 ms per tick
        private const float FractionReductionFor5SecondFade = 1/50f; // 5 seconds / 100 ms per tick
        public StageManagerForm()
        {
            InitializeComponent();
            tstrpComboBoxShows.ComboBox.SelectionChangeCommitted += ComboBox_SelectionChangeCommitted;
            lblLoading.Visible = false;
        }

        private void ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selectedShow = tstrpComboBoxShows.SelectedItem?.ToString();
            ReadInSounds(selectedShow);
            lblLoading.Visible = true;
            this.Refresh();
            this.scriptViewer1.ReadExcelFile(selectedShow, $"{selectedShow}.xlsx");
            lblLoading.Visible = false;

        }

        private void StageManagerForm_Load(object sender, EventArgs e)
        {
            tsbtnTwoSecondFade.BackColor = Color.Green;
            tsbtnFiveSecondFade.BackColor = Color.Green;

            List<string> shows = scriptViewer1.ReadShows();
            foreach (string s in shows)
            {
                tstrpComboBoxShows.Items.Add(s);
            }

        }
        private void ReadInSounds(string SoundPath)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string path = Path.Combine(documentsPath + @"\QLTG_Shows\" + SoundPath);

            var files = Directory.GetFiles(path)
                .Where(f => !Path.GetFileName(f).StartsWith("XX") && !Path.GetFileName(f).EndsWith("xlsx"))
                .ToList();

            string filesXX = Directory.GetFiles(path, "XX*.*").SingleOrDefault()?.ToString();

            soundCues.ClearPlayItems();

            if (!String.IsNullOrEmpty(filesXX))
            {
                string title = Path.GetFileNameWithoutExtension(filesXX);
                var waveStream = File.OpenRead(filesXX);
                PlayAudioItem pi = new PlayAudioItem(waveStream, title, true);
                soundCues.AddPlayItem(pi);
            }

            foreach (string file in files)
            {
                string title = Path.GetFileNameWithoutExtension(file);
                var waveStream = File.OpenRead(file);
                PlayAudioItem pi = new PlayAudioItem(waveStream, title, false);
                soundCues.AddPlayItem(pi);
            }
        }
        private void tsbtnStop_Click(object sender, EventArgs e)
        {
            soundCues.Stop();
        }
        private void tsbtnTwoSecondFade_Click(object sender, EventArgs e)
        {
            if( this.CurrentAudioItem != null)
            {
                this.CurrentAudioItem.FadeAudio(FadeType.TwoSecondFade);
            }
        }
        private void tsbFiveSecondFade_Click(object sender, EventArgs e)
        {
            if (this.CurrentAudioItem != null)
            {
                this.CurrentAudioItem.FadeAudio(FadeType.FiveSecondFade);
            }
        }
        private void tsbtnReset_Click(object sender, EventArgs e)
        {
            soundCues.Reset();
        }
        private void tsbFlockOfTigers_Click(object sender, EventArgs e)
        {
            ReadInSounds("Flock of Tigers");
            lblLoading.Visible = true;
            this.Refresh();
            this.scriptViewer1.ReadExcelFile(@"Flock of Tigers", @"AFlockofTigers.xlsx");
            lblLoading.Visible = false;
        }

        private void tsbRedHanded_Click(object sender, EventArgs e)
        {
            lblLoading.Visible = true;
            ReadInSounds("Red-Handed");
            lblLoading.Visible = true;
            {
                this.Refresh();
                this.scriptViewer1.ReadExcelFile(@"Red-Handed", @"RedHanded.xlsx");
            }
            lblLoading.Visible = false;
        }

        private void tsbtnStopContinuous_Click(object sender, EventArgs e)
        {
            soundCues.StopContinuous();
        }

    }
}
