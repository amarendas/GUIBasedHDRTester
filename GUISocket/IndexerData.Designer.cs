namespace GUISocket
{
    partial class IndexerData
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
            dgvIndexer = new DataGridView();
            btmReadCalibFile = new Button();
            write = new Button();
            btnReadIndexerData = new Button();
            richTextBox1 = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)dgvIndexer).BeginInit();
            SuspendLayout();
            // 
            // dgvIndexer
            // 
            dgvIndexer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIndexer.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvIndexer.Location = new Point(12, 72);
            dgvIndexer.Name = "dgvIndexer";
            dgvIndexer.RowTemplate.Height = 25;
            dgvIndexer.Size = new Size(490, 366);
            dgvIndexer.TabIndex = 0;
            // 
            // btmReadCalibFile
            // 
            btmReadCalibFile.Location = new Point(31, 23);
            btmReadCalibFile.Name = "btmReadCalibFile";
            btmReadCalibFile.Size = new Size(120, 36);
            btmReadCalibFile.TabIndex = 1;
            btmReadCalibFile.Text = "Read Calib fille";
            btmReadCalibFile.UseVisualStyleBackColor = true;
            btmReadCalibFile.Click += btmReadCalibFile_Click;
            // 
            // write
            // 
            write.Location = new Point(206, 23);
            write.Name = "write";
            write.Size = new Size(114, 40);
            write.TabIndex = 2;
            write.Text = "Save indexr Data";
            write.UseVisualStyleBackColor = true;
            write.Click += write_Click;
            // 
            // btnReadIndexerData
            // 
            btnReadIndexerData.Location = new Point(525, 30);
            btnReadIndexerData.Name = "btnReadIndexerData";
            btnReadIndexerData.Size = new Size(252, 29);
            btnReadIndexerData.TabIndex = 3;
            btnReadIndexerData.Text = "Read current Indexer File";
            btnReadIndexerData.UseVisualStyleBackColor = true;
            btnReadIndexerData.Click += btnReadIndexerData_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(521, 84);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(256, 354);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "";
            // 
            // IndexerData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(richTextBox1);
            Controls.Add(btnReadIndexerData);
            Controls.Add(write);
            Controls.Add(btmReadCalibFile);
            Controls.Add(dgvIndexer);
            Name = "IndexerData";
            Text = "IndexerData";
            Load += IndexerData_Load;
            ((System.ComponentModel.ISupportInitialize)dgvIndexer).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvIndexer;
        private Button btmReadCalibFile;
        private Button write;
        private Button btnReadIndexerData;
        private RichTextBox richTextBox1;
    }
}