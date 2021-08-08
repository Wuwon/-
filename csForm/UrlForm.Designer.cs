
namespace Cafe_Solution.csForm
{
    partial class UrlForm
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
            this.URL_textBox = new System.Windows.Forms.TextBox();
            this.LoadBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // URL_textBox
            // 
            this.URL_textBox.Location = new System.Drawing.Point(52, 2);
            this.URL_textBox.Name = "URL_textBox";
            this.URL_textBox.Size = new System.Drawing.Size(138, 21);
            this.URL_textBox.TabIndex = 0;
            this.URL_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.URL_textBox_KeyDown);
            // 
            // LoadBtn
            // 
            this.LoadBtn.Location = new System.Drawing.Point(193, 0);
            this.LoadBtn.Name = "LoadBtn";
            this.LoadBtn.Size = new System.Drawing.Size(75, 23);
            this.LoadBtn.TabIndex = 1;
            this.LoadBtn.Text = "접속";
            this.LoadBtn.UseVisualStyleBackColor = true;
            this.LoadBtn.Click += new System.EventHandler(this.LoadBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "URL";
            // 
            // UrlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 26);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LoadBtn);
            this.Controls.Add(this.URL_textBox);
            this.KeyPreview = true;
            this.Name = "UrlForm";
            this.Text = "UrlForm";
            this.Load += new System.EventHandler(this.UrlForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UrlForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox URL_textBox;
        private System.Windows.Forms.Button LoadBtn;
        private System.Windows.Forms.Label label1;
    }
}