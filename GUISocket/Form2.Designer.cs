﻿namespace GUISocket
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
            btnLoginOK.Location = new Point(119, 128);
            btnLoginOK.Name = "btnLoginOK";
            btnLoginOK.Size = new Size(75, 23);
            btnLoginOK.TabIndex = 2;
            btnLoginOK.Text = "Log in";
            btnLoginOK.UseVisualStyleBackColor = true;
            btnLoginOK.Click += btnLoginOK_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 232);
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
    }
}