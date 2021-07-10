namespace DocArhive
{
    partial class AddDepart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDepart));
            this.label5 = new System.Windows.Forms.Label();
            this.btnCheckLogin = new System.Windows.Forms.Button();
            this.NameOfNewDep = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pictureBackBtn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBackBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(40, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(278, 26);
            this.label5.TabIndex = 36;
            this.label5.Text = "Выберете начальника отдела:";
            // 
            // btnCheckLogin
            // 
            this.btnCheckLogin.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnCheckLogin.FlatAppearance.BorderSize = 0;
            this.btnCheckLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCheckLogin.ForeColor = System.Drawing.Color.Black;
            this.btnCheckLogin.Location = new System.Drawing.Point(281, 300);
            this.btnCheckLogin.Name = "btnCheckLogin";
            this.btnCheckLogin.Size = new System.Drawing.Size(98, 37);
            this.btnCheckLogin.TabIndex = 35;
            this.btnCheckLogin.Text = "Добавить";
            this.btnCheckLogin.UseVisualStyleBackColor = false;
            this.btnCheckLogin.Click += new System.EventHandler(this.btnCheckLogin_Click);
            // 
            // NameOfNewDep
            // 
            this.NameOfNewDep.BackColor = System.Drawing.Color.White;
            this.NameOfNewDep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameOfNewDep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameOfNewDep.Location = new System.Drawing.Point(324, 200);
            this.NameOfNewDep.Name = "NameOfNewDep";
            this.NameOfNewDep.Size = new System.Drawing.Size(185, 26);
            this.NameOfNewDep.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(123, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 26);
            this.label4.TabIndex = 32;
            this.label4.Text = "Введите имя отдела:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(552, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 348);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(215, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(294, 118);
            this.label2.TabIndex = 37;
            this.label2.Text = "Добавление \r\n    отдела";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(324, 248);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(185, 21);
            this.comboBox1.TabIndex = 50;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // pictureBackBtn
            // 
            this.pictureBackBtn.Image = ((System.Drawing.Image)(resources.GetObject("pictureBackBtn.Image")));
            this.pictureBackBtn.Location = new System.Drawing.Point(109, 38);
            this.pictureBackBtn.Name = "pictureBackBtn";
            this.pictureBackBtn.Size = new System.Drawing.Size(28, 28);
            this.pictureBackBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBackBtn.TabIndex = 51;
            this.pictureBackBtn.TabStop = false;
            this.pictureBackBtn.Click += new System.EventHandler(this.pictureBackBtn_Click);
            // 
            // AddDepart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBackBtn);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCheckLogin);
            this.Controls.Add(this.NameOfNewDep);
            this.Controls.Add(this.label4);
            this.Name = "AddDepart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddDepart";
            this.Load += new System.EventHandler(this.AddDepart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBackBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCheckLogin;
        private System.Windows.Forms.TextBox NameOfNewDep;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.PictureBox pictureBackBtn;
    }
}