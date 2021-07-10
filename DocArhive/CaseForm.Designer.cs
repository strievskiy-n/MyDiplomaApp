namespace DocArhive
{
    partial class CaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaseForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureSetBut = new System.Windows.Forms.PictureBox();
            this.pictureBackBtn = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ListDocBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSetBut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBackBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(140, 92);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(453, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(340, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(319, 42);
            this.label2.TabIndex = 39;
            this.label2.Text = "Список документов";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(218)))), ((int)(((byte)(216)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(218)))), ((int)(((byte)(216)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(245, 52);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(46, 30);
            this.button2.TabIndex = 40;
            this.button2.Text = "Дела";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureSetBut
            // 
            this.pictureSetBut.Image = ((System.Drawing.Image)(resources.GetObject("pictureSetBut.Image")));
            this.pictureSetBut.Location = new System.Drawing.Point(103, 53);
            this.pictureSetBut.Name = "pictureSetBut";
            this.pictureSetBut.Size = new System.Drawing.Size(28, 28);
            this.pictureSetBut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureSetBut.TabIndex = 44;
            this.pictureSetBut.TabStop = false;
            this.pictureSetBut.Click += new System.EventHandler(this.pictureSetBut_Click);
            // 
            // pictureBackBtn
            // 
            this.pictureBackBtn.Image = ((System.Drawing.Image)(resources.GetObject("pictureBackBtn.Image")));
            this.pictureBackBtn.Location = new System.Drawing.Point(140, 53);
            this.pictureBackBtn.Name = "pictureBackBtn";
            this.pictureBackBtn.Size = new System.Drawing.Size(28, 28);
            this.pictureBackBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBackBtn.TabIndex = 43;
            this.pictureBackBtn.TabStop = false;
            this.pictureBackBtn.Click += new System.EventHandler(this.pictureBackBtn_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(218)))), ((int)(((byte)(216)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(218)))), ((int)(((byte)(216)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(176, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 30);
            this.button1.TabIndex = 46;
            this.button1.Text = "Отделы";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // ListDocBtn
            // 
            this.ListDocBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(218)))), ((int)(((byte)(216)))));
            this.ListDocBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(218)))), ((int)(((byte)(216)))));
            this.ListDocBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ListDocBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ListDocBtn.ForeColor = System.Drawing.Color.White;
            this.ListDocBtn.Location = new System.Drawing.Point(442, 52);
            this.ListDocBtn.Name = "ListDocBtn";
            this.ListDocBtn.Size = new System.Drawing.Size(151, 30);
            this.ListDocBtn.TabIndex = 47;
            this.ListDocBtn.Text = "Список документов";
            this.ListDocBtn.UseVisualStyleBackColor = false;
            this.ListDocBtn.Click += new System.EventHandler(this.ListDocBtn_Click);
            // 
            // CaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 475);
            this.Controls.Add(this.ListDocBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureSetBut);
            this.Controls.Add(this.pictureBackBtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "CaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CaseForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CaseForm_FormClosing);
            this.Load += new System.EventHandler(this.CaseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSetBut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBackBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureSetBut;
        private System.Windows.Forms.PictureBox pictureBackBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ListDocBtn;
    }
}