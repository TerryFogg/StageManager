namespace StageManager
{
    partial class PlayAudioItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.modernVolumeSlider1 = new StageManager.ModernVolumeSlider();
            this.SuspendLayout();
            // 
            // modernVolumeSlider1
            // 
            this.modernVolumeSlider1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.modernVolumeSlider1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(185)))), ((int)(((byte)(84)))));
            this.modernVolumeSlider1.Location = new System.Drawing.Point(0, 150);
            this.modernVolumeSlider1.Name = "modernVolumeSlider1";
            this.modernVolumeSlider1.Size = new System.Drawing.Size(252, 40);
            this.modernVolumeSlider1.TabIndex = 0;
            this.modernVolumeSlider1.Text = "modernVolumeSlider1";
            this.modernVolumeSlider1.ThumbColor = System.Drawing.Color.White;
            this.modernVolumeSlider1.TrackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.modernVolumeSlider1.Value = 50;
            // 
            // PlayAudioItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.modernVolumeSlider1);
            this.Name = "PlayAudioItem";
            this.Size = new System.Drawing.Size(252, 190);
            this.ResumeLayout(false);

        }

        #endregion

        private ModernVolumeSlider modernVolumeSlider1;
    }
}
