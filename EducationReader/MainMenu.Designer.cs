namespace EducationReader
{
    partial class MainMenu
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
            this.btHiragana = new System.Windows.Forms.Button();
            this.btNumber = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btHiragana
            // 
            this.btHiragana.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btHiragana.Font = new System.Drawing.Font("Meiryo UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btHiragana.Location = new System.Drawing.Point(29, 47);
            this.btHiragana.Name = "btHiragana";
            this.btHiragana.Size = new System.Drawing.Size(223, 67);
            this.btHiragana.TabIndex = 0;
            this.btHiragana.Text = "ひらがな";
            this.btHiragana.UseVisualStyleBackColor = false;
            this.btHiragana.Click += new System.EventHandler(this.btHiragana_Click);
            // 
            // btNumber
            // 
            this.btNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btNumber.Font = new System.Drawing.Font("Meiryo UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btNumber.Location = new System.Drawing.Point(29, 148);
            this.btNumber.Name = "btNumber";
            this.btNumber.Size = new System.Drawing.Size(223, 67);
            this.btNumber.TabIndex = 0;
            this.btNumber.Text = "すうじ";
            this.btNumber.UseVisualStyleBackColor = false;
            this.btNumber.Click += new System.EventHandler(this.btNumber_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 258);
            this.Controls.Add(this.btNumber);
            this.Controls.Add(this.btHiragana);
            this.Name = "MainMenu";
            this.Text = "メニュー";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btHiragana;
        private System.Windows.Forms.Button btNumber;
    }
}