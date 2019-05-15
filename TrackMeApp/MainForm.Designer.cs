namespace TrackMeApp
{
    partial class MainForm
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
            this.toggleStateBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.statistics = new MaterialSkin.Controls.MaterialFlatButton();
            this.stopBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.topMostBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.elapsedTimerLabel = new MaterialSkin.Controls.MaterialLabel();
            this.poolStatusTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // toggleStateBtn
            // 
            this.toggleStateBtn.AutoSize = true;
            this.toggleStateBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.toggleStateBtn.Depth = 0;
            this.toggleStateBtn.Icon = null;
            this.toggleStateBtn.Location = new System.Drawing.Point(3, 107);
            this.toggleStateBtn.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.toggleStateBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.toggleStateBtn.Name = "toggleStateBtn";
            this.toggleStateBtn.Primary = false;
            this.toggleStateBtn.Size = new System.Drawing.Size(64, 36);
            this.toggleStateBtn.TabIndex = 0;
            this.toggleStateBtn.Text = "Start";
            this.toggleStateBtn.UseVisualStyleBackColor = true;
            this.toggleStateBtn.Click += new System.EventHandler(this.toggleStateBtn_Click);
            // 
            // statistics
            // 
            this.statistics.AutoSize = true;
            this.statistics.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.statistics.Depth = 0;
            this.statistics.Icon = null;
            this.statistics.Location = new System.Drawing.Point(122, 68);
            this.statistics.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.statistics.MouseState = MaterialSkin.MouseState.HOVER;
            this.statistics.Name = "statistics";
            this.statistics.Primary = false;
            this.statistics.Size = new System.Drawing.Size(84, 36);
            this.statistics.TabIndex = 2;
            this.statistics.Text = "Stastics";
            this.statistics.UseVisualStyleBackColor = true;
            this.statistics.Click += new System.EventHandler(this.statistics_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.AutoSize = true;
            this.stopBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.stopBtn.Depth = 0;
            this.stopBtn.Icon = null;
            this.stopBtn.Location = new System.Drawing.Point(65, 107);
            this.stopBtn.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.stopBtn.MinimumSize = new System.Drawing.Size(30, 0);
            this.stopBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Primary = false;
            this.stopBtn.Size = new System.Drawing.Size(56, 36);
            this.stopBtn.TabIndex = 4;
            this.stopBtn.Text = "Stop";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // topMostBtn
            // 
            this.topMostBtn.AutoSize = true;
            this.topMostBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.topMostBtn.Depth = 0;
            this.topMostBtn.Icon = null;
            this.topMostBtn.Location = new System.Drawing.Point(122, 107);
            this.topMostBtn.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.topMostBtn.MinimumSize = new System.Drawing.Size(30, 0);
            this.topMostBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.topMostBtn.Name = "topMostBtn";
            this.topMostBtn.Primary = false;
            this.topMostBtn.Size = new System.Drawing.Size(86, 36);
            this.topMostBtn.TabIndex = 5;
            this.topMostBtn.Text = "TopMost";
            this.topMostBtn.UseVisualStyleBackColor = true;
            // 
            // elapsedTimerLabel
            // 
            this.elapsedTimerLabel.AutoSize = true;
            this.elapsedTimerLabel.Depth = 0;
            this.elapsedTimerLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.elapsedTimerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.elapsedTimerLabel.Location = new System.Drawing.Point(32, 72);
            this.elapsedTimerLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.elapsedTimerLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.elapsedTimerLabel.Name = "elapsedTimerLabel";
            this.elapsedTimerLabel.Size = new System.Drawing.Size(65, 19);
            this.elapsedTimerLabel.TabIndex = 6;
            this.elapsedTimerLabel.Text = "00:00:00";
            // 
            // poolStatusTimer
            // 
            this.poolStatusTimer.Interval = 1000;
            this.poolStatusTimer.Tick += new System.EventHandler(this.poolStatusTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 145);
            this.Controls.Add(this.elapsedTimerLabel);
            this.Controls.Add(this.topMostBtn);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.statistics);
            this.Controls.Add(this.toggleStateBtn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Track Me";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialFlatButton toggleStateBtn;
        private MaterialSkin.Controls.MaterialFlatButton statistics;
        private MaterialSkin.Controls.MaterialFlatButton stopBtn;
        private MaterialSkin.Controls.MaterialFlatButton topMostBtn;
        private MaterialSkin.Controls.MaterialLabel elapsedTimerLabel;
        private System.Windows.Forms.Timer poolStatusTimer;
    }
}

