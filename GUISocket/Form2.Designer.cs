namespace GUISocket
{
    partial class Form2
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
            textBox1 = new TextBox();
            label1 = new Label();
            btnLoginOK = new Button();
            panel1 = new Panel();
            button1 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(121, 38);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 41);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 1;
            label1.Text = "User Name";
            // 
            // btnLoginOK
            // 
            btnLoginOK.Location = new Point(290, 41);
            btnLoginOK.Name = "btnLoginOK";
            btnLoginOK.Size = new Size(75, 23);
            btnLoginOK.TabIndex = 2;
            btnLoginOK.Text = "Log in";
            btnLoginOK.UseVisualStyleBackColor = true;
            btnLoginOK.Click += btnLoginOK_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Location = new Point(308, 148);
            panel1.Name = "panel1";
            panel1.Size = new Size(707, 408);
            panel1.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(523, 49);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "add pbox";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1046, 583);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(btnLoginOK);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "Form2";
            Text = "Log in Page";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Button btnLoginOK;
        private Panel panel1;
        private Button button1;
    }
}