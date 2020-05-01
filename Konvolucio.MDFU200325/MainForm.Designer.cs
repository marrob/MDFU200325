namespace Konvolucio.MDFU200325
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLoadTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelLastModify = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelRowColumn = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonWrite = new System.Windows.Forms.Button();
            this.checkBoxLogEnable = new System.Windows.Forms.CheckBox();
            this.NumericUpDownAddress = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownAddress)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.toolStripStatusLoadTime,
            this.toolStripStatusLabelLastModify,
            this.toolStripStatusLabelRowColumn,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelVersion,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 129);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(694, 24);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(0, 19);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // toolStripStatusLoadTime
            // 
            this.toolStripStatusLoadTime.Name = "toolStripStatusLoadTime";
            this.toolStripStatusLoadTime.Size = new System.Drawing.Size(63, 19);
            this.toolStripStatusLoadTime.Text = "Load Time";
            // 
            // toolStripStatusLabelLastModify
            // 
            this.toolStripStatusLabelLastModify.AutoToolTip = true;
            this.toolStripStatusLabelLastModify.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabelLastModify.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabelLastModify.Name = "toolStripStatusLabelLastModify";
            this.toolStripStatusLabelLastModify.Size = new System.Drawing.Size(121, 19);
            this.toolStripStatusLabelLastModify.Text = "Last write timestamp";
            // 
            // toolStripStatusLabelRowColumn
            // 
            this.toolStripStatusLabelRowColumn.AutoToolTip = true;
            this.toolStripStatusLabelRowColumn.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.toolStripStatusLabelRowColumn.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabelRowColumn.Name = "toolStripStatusLabelRowColumn";
            this.toolStripStatusLabelRowColumn.Size = new System.Drawing.Size(80, 19);
            this.toolStripStatusLabelRowColumn.Text = "Row Column";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(254, 19);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabelVersion
            // 
            this.toolStripStatusLabelVersion.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabelVersion.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabelVersion.Name = "toolStripStatusLabelVersion";
            this.toolStripStatusLabelVersion.Size = new System.Drawing.Size(58, 19);
            this.toolStripStatusLabelVersion.Text = "VERSION";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.Color.Orange;
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(103, 19);
            this.toolStripStatusLabel2.Text = "KONVOLUCIÓ BT";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(6, 46);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(682, 23);
            this.ProgressBar.TabIndex = 6;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(526, 96);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 8;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            // 
            // buttonWrite
            // 
            this.buttonWrite.Location = new System.Drawing.Point(607, 96);
            this.buttonWrite.Name = "buttonWrite";
            this.buttonWrite.Size = new System.Drawing.Size(75, 23);
            this.buttonWrite.TabIndex = 9;
            this.buttonWrite.Text = "Write";
            this.buttonWrite.UseVisualStyleBackColor = true;
            // 
            // checkBoxLogEnable
            // 
            this.checkBoxLogEnable.AutoSize = true;
            this.checkBoxLogEnable.Location = new System.Drawing.Point(12, 96);
            this.checkBoxLogEnable.Name = "checkBoxLogEnable";
            this.checkBoxLogEnable.Size = new System.Drawing.Size(80, 17);
            this.checkBoxLogEnable.TabIndex = 10;
            this.checkBoxLogEnable.Text = "Log Enable";
            this.checkBoxLogEnable.UseVisualStyleBackColor = true;
            // 
            // NumericUpDownAddress
            // 
            this.NumericUpDownAddress.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Konvolucio.MDFU200325.Properties.Settings.Default, "Address", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NumericUpDownAddress.Location = new System.Drawing.Point(101, 16);
            this.NumericUpDownAddress.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.NumericUpDownAddress.Name = "NumericUpDownAddress";
            this.NumericUpDownAddress.Size = new System.Drawing.Size(47, 20);
            this.NumericUpDownAddress.TabIndex = 11;
            this.NumericUpDownAddress.Value = global::Konvolucio.MDFU200325.Properties.Settings.Default.Address;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Server Address:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(227, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Baudrate:";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(313, 51);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(50, 13);
            this.labelStatus.TabIndex = 15;
            this.labelStatus.Text = "STATUS";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 153);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NumericUpDownAddress);
            this.Controls.Add(this.checkBoxLogEnable);
            this.Controls.Add(this.buttonWrite);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Form1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownAddress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripSplitButton1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLoadTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLastModify;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRowColumn;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelVersion;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.CheckBox checkBoxLogEnable;
        public System.Windows.Forms.NumericUpDown NumericUpDownAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonWrite;
        private System.Windows.Forms.Button buttonBrowse;
    }
}

