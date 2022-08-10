namespace LanguagePlayer
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.inputBox = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labGameover = new System.Windows.Forms.Label();
            this.labMessage = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.Button();
            this.cbPause = new System.Windows.Forms.CheckBox();
            this.comboPatten = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudSpeed = new System.Windows.Forms.NumericUpDown();
            this.labHitCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timerAddWord = new System.Windows.Forms.Timer(this.components);
            this.timerMoveWords = new System.Windows.Forms.Timer(this.components);
            this.timerRemove = new System.Windows.Forms.Timer(this.components);
            this.comboDocs = new System.Windows.Forms.ComboBox();
            this.txtExclude = new System.Windows.Forms.TextBox();
            this.txtAddExclude = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // inputBox
            // 
            this.inputBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputBox.Font = new System.Drawing.Font("新細明體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.inputBox.Location = new System.Drawing.Point(0, 420);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(297, 30);
            this.inputBox.TabIndex = 0;
            this.inputBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.inputBox_KeyUp);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.txtAddExclude);
            this.splitContainer1.Panel1.Controls.Add(this.labGameover);
            this.splitContainer1.Panel1.Controls.Add(this.inputBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainer1.Panel2.Controls.Add(this.txtExclude);
            this.splitContainer1.Panel2.Controls.Add(this.comboDocs);
            this.splitContainer1.Panel2.Controls.Add(this.labMessage);
            this.splitContainer1.Panel2.Controls.Add(this.btnRestart);
            this.splitContainer1.Panel2.Controls.Add(this.cbPause);
            this.splitContainer1.Panel2.Controls.Add(this.comboPatten);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.nudSpeed);
            this.splitContainer1.Panel2.Controls.Add(this.labHitCount);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.btnUpload);
            this.splitContainer1.Panel2.Controls.Add(this.txtSource);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 673;
            this.splitContainer1.TabIndex = 1;
            // 
            // labGameover
            // 
            this.labGameover.AutoSize = true;
            this.labGameover.Font = new System.Drawing.Font("新細明體", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labGameover.ForeColor = System.Drawing.Color.Red;
            this.labGameover.Location = new System.Drawing.Point(198, 155);
            this.labGameover.Name = "labGameover";
            this.labGameover.Size = new System.Drawing.Size(0, 64);
            this.labGameover.TabIndex = 2;
            this.labGameover.Visible = false;
            // 
            // labMessage
            // 
            this.labMessage.AutoSize = true;
            this.labMessage.Location = new System.Drawing.Point(3, 316);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(58, 12);
            this.labMessage.TabIndex = 9;
            this.labMessage.Text = "labMessage";
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(59, 293);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(61, 23);
            this.btnRestart.TabIndex = 8;
            this.btnRestart.Text = "重啟";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // cbPause
            // 
            this.cbPause.AutoSize = true;
            this.cbPause.Location = new System.Drawing.Point(5, 297);
            this.cbPause.Name = "cbPause";
            this.cbPause.Size = new System.Drawing.Size(48, 16);
            this.cbPause.TabIndex = 3;
            this.cbPause.Text = "暫停";
            this.cbPause.UseVisualStyleBackColor = true;
            this.cbPause.Click += new System.EventHandler(this.cbPause_Click);
            // 
            // comboPatten
            // 
            this.comboPatten.DisplayMember = "Value";
            this.comboPatten.FormattingEnabled = true;
            this.comboPatten.Location = new System.Drawing.Point(0, 215);
            this.comboPatten.Name = "comboPatten";
            this.comboPatten.Size = new System.Drawing.Size(121, 20);
            this.comboPatten.TabIndex = 7;
            this.comboPatten.Text = "[A-z\']{2,}";
            this.comboPatten.ValueMember = "Value";
            this.comboPatten.SelectedIndexChanged += new System.EventHandler(this.comboPatten_SelectedIndexChanged);
            this.comboPatten.TextChanged += new System.EventHandler(this.comboPatten_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "Speed";
            // 
            // nudSpeed
            // 
            this.nudSpeed.Location = new System.Drawing.Point(3, 261);
            this.nudSpeed.Name = "nudSpeed";
            this.nudSpeed.Size = new System.Drawing.Size(120, 22);
            this.nudSpeed.TabIndex = 5;
            this.nudSpeed.ValueChanged += new System.EventHandler(this.nudSpeed_ValueChanged);
            // 
            // labHitCount
            // 
            this.labHitCount.AutoSize = true;
            this.labHitCount.Location = new System.Drawing.Point(3, 177);
            this.labHitCount.Name = "labHitCount";
            this.labHitCount.Size = new System.Drawing.Size(23, 12);
            this.labHitCount.TabIndex = 1;
            this.labHitCount.Text = "0次";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pattern:";
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(0, 138);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(123, 23);
            this.btnUpload.TabIndex = 2;
            this.btnUpload.Text = "上傳";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // txtSource
            // 
            this.txtSource.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSource.Location = new System.Drawing.Point(0, 0);
            this.txtSource.Multiline = true;
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(123, 119);
            this.txtSource.TabIndex = 1;
            this.txtSource.Text = resources.GetString("txtSource.Text");
            this.txtSource.TextChanged += new System.EventHandler(this.txtSource_TextChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "txt";
            this.openFileDialog1.Filter = "文字檔|*.txt";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "選擇要上傳的文字檔";
            // 
            // timerAddWord
            // 
            this.timerAddWord.Enabled = true;
            this.timerAddWord.Interval = 1500;
            this.timerAddWord.Tick += new System.EventHandler(this.timerAddWord_Tick);
            // 
            // timerMoveWords
            // 
            this.timerMoveWords.Enabled = true;
            this.timerMoveWords.Tick += new System.EventHandler(this.timerMoveWords_Tick);
            // 
            // timerRemove
            // 
            this.timerRemove.Enabled = true;
            this.timerRemove.Interval = 10;
            this.timerRemove.Tick += new System.EventHandler(this.timerRemove_Tick);
            // 
            // comboDocs
            // 
            this.comboDocs.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboDocs.FormattingEnabled = true;
            this.comboDocs.Location = new System.Drawing.Point(0, 119);
            this.comboDocs.Name = "comboDocs";
            this.comboDocs.Size = new System.Drawing.Size(123, 20);
            this.comboDocs.TabIndex = 10;
            this.comboDocs.Text = "current.txt";
            this.comboDocs.SelectedIndexChanged += new System.EventHandler(this.comboDocs_SelectedIndexChanged);
            // 
            // txtExclude
            // 
            this.txtExclude.Location = new System.Drawing.Point(0, 343);
            this.txtExclude.Multiline = true;
            this.txtExclude.Name = "txtExclude";
            this.txtExclude.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtExclude.Size = new System.Drawing.Size(120, 104);
            this.txtExclude.TabIndex = 11;
            this.txtExclude.Leave += new System.EventHandler(this.txtExclude_Leave);
            // 
            // txtAddExclude
            // 
            this.txtAddExclude.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddExclude.Font = new System.Drawing.Font("新細明體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtAddExclude.Location = new System.Drawing.Point(373, 417);
            this.txtAddExclude.Name = "txtAddExclude";
            this.txtAddExclude.Size = new System.Drawing.Size(297, 30);
            this.txtAddExclude.TabIndex = 3;
            this.txtAddExclude.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAddExclude_KeyUp);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(334, 428);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "排除";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "Language Palyer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerAddWord;
        private System.Windows.Forms.Timer timerMoveWords;
        private System.Windows.Forms.Label labHitCount;
        private System.Windows.Forms.Label labGameover;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudSpeed;
        private System.Windows.Forms.ComboBox comboPatten;
        private System.Windows.Forms.CheckBox cbPause;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Timer timerRemove;
        private System.Windows.Forms.Label labMessage;
        private System.Windows.Forms.ComboBox comboDocs;
        private System.Windows.Forms.TextBox txtExclude;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddExclude;
    }
}

