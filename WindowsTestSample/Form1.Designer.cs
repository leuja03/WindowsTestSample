﻿namespace WindowsTestSample
{
    partial class Form1
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
         this.button1 = new System.Windows.Forms.Button();
         this.m_richTextBox1 = new System.Windows.Forms.RichTextBox();
         this.SuspendLayout();
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(36, 23);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 23);
         this.button1.TabIndex = 0;
         this.button1.Text = "Push me";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // m_richTextBox1
         // 
         this.m_richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.m_richTextBox1.Location = new System.Drawing.Point(11, 64);
         this.m_richTextBox1.Name = "m_richTextBox1";
         this.m_richTextBox1.Size = new System.Drawing.Size(466, 293);
         this.m_richTextBox1.TabIndex = 1;
         this.m_richTextBox1.Text = "";
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(489, 369);
         this.Controls.Add(this.m_richTextBox1);
         this.Controls.Add(this.button1);
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox m_richTextBox1;
    }
}

