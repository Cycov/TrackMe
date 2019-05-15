namespace TrackMeApp
{
    partial class StatisticsForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.breaksLabel = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.workedTimeLabel = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.windowsListBox = new System.Windows.Forms.ListBox();
            this.processesListBox = new System.Windows.Forms.ListBox();
            this.windowsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.appsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.materialTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.windowsChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appsChart)).BeginInit();
            this.SuspendLayout();
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPage1);
            this.materialTabControl1.Controls.Add(this.tabPage2);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.materialTabControl1.Location = new System.Drawing.Point(0, 80);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(800, 370);
            this.materialTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.breaksLabel);
            this.tabPage1.Controls.Add(this.materialLabel3);
            this.tabPage1.Controls.Add(this.workedTimeLabel);
            this.tabPage1.Controls.Add(this.materialLabel1);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.windowsListBox);
            this.tabPage1.Controls.Add(this.processesListBox);
            this.tabPage1.Controls.Add(this.windowsChart);
            this.tabPage1.Controls.Add(this.appsChart);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 344);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // breaksLabel
            // 
            this.breaksLabel.AutoSize = true;
            this.breaksLabel.Depth = 0;
            this.breaksLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.breaksLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.breaksLabel.Location = new System.Drawing.Point(637, 7);
            this.breaksLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.breaksLabel.Name = "breaksLabel";
            this.breaksLabel.Size = new System.Drawing.Size(0, 19);
            this.breaksLabel.TabIndex = 4;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(572, 11);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(59, 19);
            this.materialLabel3.TabIndex = 4;
            this.materialLabel3.Text = "Breaks:";
            // 
            // workedTimeLabel
            // 
            this.workedTimeLabel.AutoSize = true;
            this.workedTimeLabel.Depth = 0;
            this.workedTimeLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.workedTimeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.workedTimeLabel.Location = new System.Drawing.Point(362, 7);
            this.workedTimeLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.workedTimeLabel.Name = "workedTimeLabel";
            this.workedTimeLabel.Size = new System.Drawing.Size(0, 19);
            this.workedTimeLabel.TabIndex = 4;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(292, 10);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(64, 19);
            this.materialLabel1.TabIndex = 4;
            this.materialLabel1.Text = "Worked:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(8, 8);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(373, 169);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(45, 39);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Paint);
            // 
            // windowsListBox
            // 
            this.windowsListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.windowsListBox.FormattingEnabled = true;
            this.windowsListBox.Location = new System.Drawing.Point(643, 48);
            this.windowsListBox.Name = "windowsListBox";
            this.windowsListBox.Size = new System.Drawing.Size(141, 277);
            this.windowsListBox.TabIndex = 1;
            this.windowsListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBox_DrawItem);
            // 
            // processesListBox
            // 
            this.processesListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.processesListBox.FormattingEnabled = true;
            this.processesListBox.Location = new System.Drawing.Point(238, 48);
            this.processesListBox.Name = "processesListBox";
            this.processesListBox.Size = new System.Drawing.Size(129, 277);
            this.processesListBox.TabIndex = 1;
            this.processesListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBox_DrawItem);
            this.processesListBox.SelectedIndexChanged += new System.EventHandler(this.ProcessesListBox_SelectedIndexChanged);
            // 
            // windowsChart
            // 
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Gainsboro;
            chartArea1.Name = "ChartArea1";
            this.windowsChart.ChartAreas.Add(chartArea1);
            this.windowsChart.Location = new System.Drawing.Point(424, 48);
            this.windowsChart.Name = "windowsChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Name = "Series1";
            this.windowsChart.Series.Add(series1);
            this.windowsChart.Size = new System.Drawing.Size(213, 252);
            this.windowsChart.TabIndex = 0;
            this.windowsChart.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Windows";
            title2.Name = "Title2";
            title2.Text = "00:00:00";
            this.windowsChart.Titles.Add(title1);
            this.windowsChart.Titles.Add(title2);
            // 
            // appsChart
            // 
            chartArea2.AxisX.LabelStyle.ForeColor = System.Drawing.Color.WhiteSmoke;
            chartArea2.AxisX.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea2.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.WhiteSmoke;
            chartArea2.AxisX2.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.WhiteSmoke;
            chartArea2.AxisY.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea2.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.WhiteSmoke;
            chartArea2.AxisY2.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea2.Name = "ChartArea1";
            this.appsChart.ChartAreas.Add(chartArea2);
            this.appsChart.Location = new System.Drawing.Point(19, 48);
            this.appsChart.Name = "appsChart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.Name = "Series1";
            this.appsChart.Series.Add(series2);
            this.appsChart.Size = new System.Drawing.Size(213, 252);
            this.appsChart.TabIndex = 0;
            this.appsChart.Text = "chart1";
            title3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title3.Name = "Title1";
            title3.Text = "Applications";
            this.appsChart.Titles.Add(title3);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 344);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(0, 50);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(800, 34);
            this.materialTabSelector1.TabIndex = 1;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.materialTabSelector1);
            this.Controls.Add(this.materialTabControl1);
            this.Name = "StatisticsForm";
            this.Text = "Statistics";
            this.materialTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.windowsChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appsChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private System.Windows.Forms.DataVisualization.Charting.Chart appsChart;
        private System.Windows.Forms.ListBox processesListBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private MaterialSkin.Controls.MaterialLabel breaksLabel;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel workedTimeLabel;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.ListBox windowsListBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart windowsChart;
    }
}