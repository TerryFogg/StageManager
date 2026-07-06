namespace StageManager
{
    partial class PlayItem
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
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.playButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            //this.playAudioItem1 = new StageManager.PlayAudioItem();
            //this.audioButton1 = new StageManager.AudioButton();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(818, 29);
            this.textBox1.TabIndex = 0;
            // 
            // playButton
            // 
            this.playButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.Location = new System.Drawing.Point(4, 41);
            this.playButton.Margin = new System.Windows.Forms.Padding(4);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(277, 503);
            this.playButton.TabIndex = 7;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // playAudioItem1
            // 
            this.playAudioItem1.BackColor = System.Drawing.Color.Transparent;
            this.playAudioItem1.Caption = "Audio Item";
            this.playAudioItem1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playAudioItem1.IsPlaying = false;
            this.playAudioItem1.Location = new System.Drawing.Point(384, 211);
            this.playAudioItem1.Name = "playAudioItem1";
            this.playAudioItem1.Progress = 0F;
            this.playAudioItem1.Size = new System.Drawing.Size(291, 152);
            this.playAudioItem1.TabIndex = 10;
            // 
            // audioButton1
            // 
            this.audioButton1.BackColor = System.Drawing.Color.Green;
            this.audioButton1.IsPlaying = false;
            this.audioButton1.Location = new System.Drawing.Point(14, 51);
            this.audioButton1.Name = "audioButton1";
            this.audioButton1.Reader = null;
            this.audioButton1.Size = new System.Drawing.Size(96, 98);
            this.audioButton1.TabIndex = 9;
            this.audioButton1.Text = "audioButton1";
            // 
            // PlayItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.playAudioItem1);
            this.Controls.Add(this.audioButton1);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PlayItem";
            this.Size = new System.Drawing.Size(818, 551);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Timer timer1;
        private AudioButton audioButton1;
        private PlayAudioItem playAudioItem1;
    }
}
