namespace DocArhive
{
    partial class Login
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCheckLogin = new System.Windows.Forms.Button();
            this.tbCheckPassword = new System.Windows.Forms.TextBox();
            this.tbCheckLogin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(178, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(393, 53);
            this.label2.TabIndex = 23;
            this.label2.Text = "Электронный архив";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(302, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 19);
            this.label1.TabIndex = 24;
            this.label1.Text = "Деловых документов организации";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnCheckLogin
            // 
            this.btnCheckLogin.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnCheckLogin.FlatAppearance.BorderSize = 0;
            this.btnCheckLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCheckLogin.ForeColor = System.Drawing.Color.Black;
            this.btnCheckLogin.Location = new System.Drawing.Point(360, 320);
            this.btnCheckLogin.Name = "btnCheckLogin";
            this.btnCheckLogin.Size = new System.Drawing.Size(98, 37);
            this.btnCheckLogin.TabIndex = 29;
            this.btnCheckLogin.Text = "Войти";
            this.btnCheckLogin.UseVisualStyleBackColor = false;
            this.btnCheckLogin.Click += new System.EventHandler(this.btnCheckLogin_Click);
            // 
            // tbCheckPassword
            // 
            this.tbCheckPassword.BackColor = System.Drawing.Color.White;
            this.tbCheckPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCheckPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbCheckPassword.Location = new System.Drawing.Point(360, 267);
            this.tbCheckPassword.Name = "tbCheckPassword";
            this.tbCheckPassword.Size = new System.Drawing.Size(152, 26);
            this.tbCheckPassword.TabIndex = 28;
            // 
            // tbCheckLogin
            // 
            this.tbCheckLogin.BackColor = System.Drawing.Color.White;
            this.tbCheckLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCheckLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbCheckLogin.Location = new System.Drawing.Point(360, 220);
            this.tbCheckLogin.Name = "tbCheckLogin";
            this.tbCheckLogin.Size = new System.Drawing.Size(152, 26);
            this.tbCheckLogin.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(290, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 26);
            this.label4.TabIndex = 25;
            this.label4.Text = "логин:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(577, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 348);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(277, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 26);
            this.label5.TabIndex = 31;
            this.label5.Text = "пароль:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1001, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCheckLogin);
            this.Controls.Add(this.tbCheckPassword);
            this.Controls.Add(this.tbCheckLogin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCheckLogin;
        private System.Windows.Forms.TextBox tbCheckPassword;
        private System.Windows.Forms.TextBox tbCheckLogin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
    }
}

