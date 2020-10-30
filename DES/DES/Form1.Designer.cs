namespace DES
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Title = new System.Windows.Forms.Label();
            this.ENCODE_BOTTON = new System.Windows.Forms.Button();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.tbIV = new System.Windows.Forms.TextBox();
            this.lbKey = new System.Windows.Forms.Label();
            this.lbIV = new System.Windows.Forms.Label();
            this.DECODE_BOTTOM = new System.Windows.Forms.Button();
            this.lbFile = new System.Windows.Forms.Label();
            this.FileBotton = new System.Windows.Forms.Button();
            this.Filename = new System.Windows.Forms.Label();
            this.Show1 = new System.Windows.Forms.Label();
            this.Show2 = new System.Windows.Forms.Label();
            this.Note1 = new System.Windows.Forms.Label();
            this.Note2 = new System.Windows.Forms.Label();
            this.Note0 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Big John", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Title.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.Title.Location = new System.Drawing.Point(186, 111);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(979, 64);
            this.Title.TabIndex = 0;
            this.Title.Text = "—— DES Cryptograph ——";
            // 
            // ENCODE_BOTTON
            // 
            this.ENCODE_BOTTON.FlatAppearance.BorderSize = 0;
            this.ENCODE_BOTTON.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.ENCODE_BOTTON.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.ENCODE_BOTTON.ForeColor = System.Drawing.Color.DodgerBlue;
            this.ENCODE_BOTTON.Location = new System.Drawing.Point(364, 598);
            this.ENCODE_BOTTON.Name = "ENCODE_BOTTON";
            this.ENCODE_BOTTON.Size = new System.Drawing.Size(150, 46);
            this.ENCODE_BOTTON.TabIndex = 1;
            this.ENCODE_BOTTON.Text = "ENCODE";
            this.ENCODE_BOTTON.UseVisualStyleBackColor = true;
            this.ENCODE_BOTTON.Click += new System.EventHandler(this.encodeBotton_Click);
            // 
            // tbKey
            // 
            this.tbKey.Location = new System.Drawing.Point(224, 376);
            this.tbKey.Name = "tbKey";
            this.tbKey.PasswordChar = '*';
            this.tbKey.Size = new System.Drawing.Size(890, 38);
            this.tbKey.TabIndex = 2;
            // 
            // tbIV
            // 
            this.tbIV.Location = new System.Drawing.Point(224, 490);
            this.tbIV.Name = "tbIV";
            this.tbIV.PasswordChar = '*';
            this.tbIV.Size = new System.Drawing.Size(890, 38);
            this.tbIV.TabIndex = 2;
            // 
            // lbKey
            // 
            this.lbKey.AutoSize = true;
            this.lbKey.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbKey.Location = new System.Drawing.Point(139, 376);
            this.lbKey.Name = "lbKey";
            this.lbKey.Size = new System.Drawing.Size(76, 35);
            this.lbKey.TabIndex = 3;
            this.lbKey.Text = "Key :";
            // 
            // lbIV
            // 
            this.lbIV.AutoSize = true;
            this.lbIV.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbIV.Location = new System.Drawing.Point(139, 490);
            this.lbIV.Name = "lbIV";
            this.lbIV.Size = new System.Drawing.Size(72, 35);
            this.lbIV.TabIndex = 3;
            this.lbIV.Text = "IV   :";
            // 
            // DECODE_BOTTOM
            // 
            this.DECODE_BOTTOM.FlatAppearance.BorderSize = 0;
            this.DECODE_BOTTOM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.DECODE_BOTTOM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.DECODE_BOTTOM.ForeColor = System.Drawing.Color.DodgerBlue;
            this.DECODE_BOTTOM.Location = new System.Drawing.Point(857, 598);
            this.DECODE_BOTTOM.Name = "DECODE_BOTTOM";
            this.DECODE_BOTTOM.Size = new System.Drawing.Size(150, 46);
            this.DECODE_BOTTOM.TabIndex = 1;
            this.DECODE_BOTTOM.Text = "DECODE";
            this.DECODE_BOTTOM.UseVisualStyleBackColor = true;
            this.DECODE_BOTTOM.Click += new System.EventHandler(this.decodeBotton_Click);
            // 
            // lbFile
            // 
            this.lbFile.AutoSize = true;
            this.lbFile.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbFile.Location = new System.Drawing.Point(139, 263);
            this.lbFile.Name = "lbFile";
            this.lbFile.Size = new System.Drawing.Size(73, 35);
            this.lbFile.TabIndex = 3;
            this.lbFile.Text = "File :";
            // 
            // FileBotton
            // 
            this.FileBotton.Location = new System.Drawing.Point(1036, 258);
            this.FileBotton.Name = "FileBotton";
            this.FileBotton.Size = new System.Drawing.Size(150, 46);
            this.FileBotton.TabIndex = 1;
            this.FileBotton.Text = "Select File";
            this.FileBotton.UseVisualStyleBackColor = true;
            this.FileBotton.Click += new System.EventHandler(this.FileBotton_Click);
            // 
            // Filename
            // 
            this.Filename.AutoSize = true;
            this.Filename.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Filename.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Filename.Location = new System.Drawing.Point(224, 263);
            this.Filename.Name = "Filename";
            this.Filename.Size = new System.Drawing.Size(105, 35);
            this.Filename.TabIndex = 3;
            this.Filename.Text = "No File";
            // 
            // Show1
            // 
            this.Show1.AutoSize = true;
            this.Show1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Show1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Show1.Location = new System.Drawing.Point(1138, 376);
            this.Show1.Name = "Show1";
            this.Show1.Size = new System.Drawing.Size(83, 35);
            this.Show1.TabIndex = 3;
            this.Show1.Text = "show";
            this.Show1.Click += new System.EventHandler(this.Show1_Click);
            // 
            // Show2
            // 
            this.Show2.AutoSize = true;
            this.Show2.BackColor = System.Drawing.SystemColors.Control;
            this.Show2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Show2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Show2.Location = new System.Drawing.Point(1138, 490);
            this.Show2.Name = "Show2";
            this.Show2.Size = new System.Drawing.Size(83, 35);
            this.Show2.TabIndex = 3;
            this.Show2.Text = "show";
            this.Show2.Click += new System.EventHandler(this.Show2_Click);
            // 
            // Note1
            // 
            this.Note1.AutoSize = true;
            this.Note1.ForeColor = System.Drawing.Color.Red;
            this.Note1.Location = new System.Drawing.Point(224, 417);
            this.Note1.Name = "Note1";
            this.Note1.Size = new System.Drawing.Size(0, 31);
            this.Note1.TabIndex = 4;
            // 
            // Note2
            // 
            this.Note2.AutoSize = true;
            this.Note2.ForeColor = System.Drawing.Color.Red;
            this.Note2.Location = new System.Drawing.Point(228, 531);
            this.Note2.Name = "Note2";
            this.Note2.Size = new System.Drawing.Size(0, 31);
            this.Note2.TabIndex = 4;
            // 
            // Note0
            // 
            this.Note0.AutoSize = true;
            this.Note0.ForeColor = System.Drawing.Color.Red;
            this.Note0.Location = new System.Drawing.Point(224, 298);
            this.Note0.Name = "Note0";
            this.Note0.Size = new System.Drawing.Size(0, 31);
            this.Note0.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 795);
            this.Controls.Add(this.Note0);
            this.Controls.Add(this.Note2);
            this.Controls.Add(this.Note1);
            this.Controls.Add(this.Show2);
            this.Controls.Add(this.Show1);
            this.Controls.Add(this.Filename);
            this.Controls.Add(this.FileBotton);
            this.Controls.Add(this.lbFile);
            this.Controls.Add(this.DECODE_BOTTOM);
            this.Controls.Add(this.lbIV);
            this.Controls.Add(this.lbKey);
            this.Controls.Add(this.tbIV);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.ENCODE_BOTTON);
            this.Controls.Add(this.Title);
            this.Name = "Form1";
            this.Text = "DES by 18307130163 傅尔正";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button ENCODE_BOTTON;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.TextBox tbIV;
        private System.Windows.Forms.Label lbKey;
        private System.Windows.Forms.Label lbIV;
        private System.Windows.Forms.Button DECODE_BOTTOM;
        private System.Windows.Forms.Label lbFile;
        private System.Windows.Forms.Button FileBotton;
        private System.Windows.Forms.Label Filename;
        private System.Windows.Forms.Label Show1;
        private System.Windows.Forms.Label Show2;
        private System.Windows.Forms.Label Note1;
        private System.Windows.Forms.Label Note2;
        private System.Windows.Forms.Label Note0;
    }
}

