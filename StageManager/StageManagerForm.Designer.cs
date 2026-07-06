namespace StageManager
{
    partial class StageManagerForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StageManagerForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.soundCues = new StageManager.SoundCues();
            this.lblLoading = new System.Windows.Forms.Label();
            this.scriptViewer1 = new StageManager.ScriptViewer();
            this.tsbtnFiveSecondFade = new System.Windows.Forms.ToolStripButton();
            this.tsbtnTwoSecondFade = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnReset = new System.Windows.Forms.ToolStripButton();
            this.tstrpComboBoxShows = new System.Windows.Forms.ToolStripComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 60);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Info;
            this.splitContainer1.Panel1.Controls.Add(this.soundCues);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblLoading);
            this.splitContainer1.Panel2.Controls.Add(this.scriptViewer1);
            this.splitContainer1.Panel2.Margin = new System.Windows.Forms.Padding(5);
            this.splitContainer1.Size = new System.Drawing.Size(1092, 725);
            this.splitContainer1.SplitterDistance = 369;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 1;
            // 
            // soundCues
            // 
            this.soundCues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soundCues.Location = new System.Drawing.Point(0, 0);
            this.soundCues.Name = "soundCues";
            this.soundCues.Size = new System.Drawing.Size(369, 725);
            this.soundCues.TabIndex = 0;
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoading.Location = new System.Drawing.Point(148, 225);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(372, 54);
            this.lblLoading.TabIndex = 1;
            this.lblLoading.Text = "Loading Script ...";
            // 
            // scriptViewer1
            // 
            this.scriptViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptViewer1.Location = new System.Drawing.Point(0, 0);
            this.scriptViewer1.Name = "scriptViewer1";
            this.scriptViewer1.Size = new System.Drawing.Size(715, 725);
            this.scriptViewer1.TabIndex = 0;
            // tsbtnFiveSecondFade
            // 
            this.tsbtnFiveSecondFade.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tsbtnFiveSecondFade.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnFiveSecondFade.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbtnFiveSecondFade.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnFiveSecondFade.Image")));
            this.tsbtnFiveSecondFade.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnFiveSecondFade.Name = "tsbtnFiveSecondFade";
            this.tsbtnFiveSecondFade.Size = new System.Drawing.Size(151, 57);
            this.tsbtnFiveSecondFade.Text = "5 Second Fade";
            this.tsbtnFiveSecondFade.Click += new System.EventHandler(this.tsbFiveSecondFade_Click);
            // 
            // tsbtnTwoSecondFade
            // 
            this.tsbtnTwoSecondFade.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tsbtnTwoSecondFade.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnTwoSecondFade.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbtnTwoSecondFade.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnTwoSecondFade.Image")));
            this.tsbtnTwoSecondFade.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnTwoSecondFade.Name = "tsbtnTwoSecondFade";
            this.tsbtnTwoSecondFade.Size = new System.Drawing.Size(151, 57);
            this.tsbtnTwoSecondFade.Text = "2 Second Fade";
            this.tsbtnTwoSecondFade.Click += new System.EventHandler(this.tsbtnTwoSecondFade_Click);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(6, 60);
            // 
            // tsbtnReset
            // 
            this.tsbtnReset.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tsbtnReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnReset.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbtnReset.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnReset.Image")));
            this.tsbtnReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnReset.Name = "tsbtnReset";
            this.tsbtnReset.Size = new System.Drawing.Size(68, 57);
            this.tsbtnReset.Text = "Reset";
            this.tsbtnReset.Click += new System.EventHandler(this.tsbtnReset_Click);
            // 
            // tstrpComboBoxShows
            // 
            this.tstrpComboBoxShows.BackColor = System.Drawing.SystemColors.Highlight;
            this.tstrpComboBoxShows.DropDownWidth = 250;
            this.tstrpComboBoxShows.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tstrpComboBoxShows.Name = "tstrpComboBoxShows";
            this.tstrpComboBoxShows.Size = new System.Drawing.Size(250, 60);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnFiveSecondFade,
            this.tsbtnTwoSecondFade,
            this.toolStripSplitButton1,
            this.tstrpComboBoxShows,
            this.tsbtnReset});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1092, 60);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // StageManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 785);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "StageManagerForm";
            this.Text = "StageManagerForm";
            this.Load += new System.EventHandler(this.StageManagerForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private SoundCues soundCues;
        private ScriptViewer scriptViewer1;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.ToolStripButton tsbtnFiveSecondFade;
        private System.Windows.Forms.ToolStripButton tsbtnTwoSecondFade;
        private System.Windows.Forms.ToolStripSeparator toolStripSplitButton1;
        private System.Windows.Forms.ToolStripButton tsbtnReset;
        private System.Windows.Forms.ToolStripComboBox tstrpComboBoxShows;
        private System.Windows.Forms.ToolStrip toolStrip1;
    }
}