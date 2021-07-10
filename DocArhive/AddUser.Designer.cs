namespace DocArhive
{
    partial class AddUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUser));
            this.pictureBackBtn = new System.Windows.Forms.PictureBox();
            this.NameOfNewUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DepartChoose = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AddBtn = new System.Windows.Forms.Button();
            this.LogOfNewUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PasswordOfNewUser = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Role = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBackBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBackBtn
            // 
            this.pictureBackBtn.Image = ((System.Drawing.Image)(resources.GetObject("pictureBackBtn.Image")));
            this.pictureBackBtn.Location = new System.Drawing.Point(135, 56);
            this.pictureBackBtn.Name = "pictureBackBtn";
            this.pictureBackBtn.Size = new System.Drawing.Size(28, 28);
            this.pictureBackBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBackBtn.TabIndex = 153;
            this.pictureBackBtn.TabStop = false;
            this.pictureBackBtn.Click += new System.EventHandler(this.pictureBackBtn_Click);
            // 
            // NameOfNewUser
            // 
            this.NameOfNewUser.BackColor = System.Drawing.Color.White;
            this.NameOfNewUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameOfNewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameOfNewUser.Location = new System.Drawing.Point(404, 183);
            this.NameOfNewUser.Name = "NameOfNewUser";
            this.NameOfNewUser.Size = new System.Drawing.Size(185, 26);
            this.NameOfNewUser.TabIndex = 162;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(141, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 26);
            this.label1.TabIndex = 161;
            this.label1.Text = "Введите имя пользователя:";
            // 
            // DepartChoose
            // 
            this.DepartChoose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DepartChoose.FormattingEnabled = true;
            this.DepartChoose.Location = new System.Drawing.Point(404, 373);
            this.DepartChoose.Name = "DepartChoose";
            this.DepartChoose.Size = new System.Drawing.Size(185, 21);
            this.DepartChoose.TabIndex = 160;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(632, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 348);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 159;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 33F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(295, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(290, 54);
            this.label2.TabIndex = 158;
            this.label2.Text = "  Добавление ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(112, 368);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(286, 26);
            this.label5.TabIndex = 157;
            this.label5.Text = "Выберете отдел пользователя:";
            // 
            // AddBtn
            // 
            this.AddBtn.BackColor = System.Drawing.Color.PaleTurquoise;
            this.AddBtn.FlatAppearance.BorderSize = 0;
            this.AddBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddBtn.ForeColor = System.Drawing.Color.Black;
            this.AddBtn.Location = new System.Drawing.Point(363, 415);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(98, 37);
            this.AddBtn.TabIndex = 156;
            this.AddBtn.Text = "Добавить";
            this.AddBtn.UseVisualStyleBackColor = false;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // LogOfNewUser
            // 
            this.LogOfNewUser.BackColor = System.Drawing.Color.White;
            this.LogOfNewUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LogOfNewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LogOfNewUser.Location = new System.Drawing.Point(404, 231);
            this.LogOfNewUser.Name = "LogOfNewUser";
            this.LogOfNewUser.Size = new System.Drawing.Size(185, 26);
            this.LogOfNewUser.TabIndex = 155;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(125, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(273, 26);
            this.label4.TabIndex = 154;
            this.label4.Text = "Введите логин пользователя:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 33F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(300, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(285, 54);
            this.label3.TabIndex = 163;
            this.label3.Text = "пользователя";
            // 
            // PasswordOfNewUser
            // 
            this.PasswordOfNewUser.BackColor = System.Drawing.Color.White;
            this.PasswordOfNewUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordOfNewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordOfNewUser.Location = new System.Drawing.Point(404, 279);
            this.PasswordOfNewUser.Name = "PasswordOfNewUser";
            this.PasswordOfNewUser.Size = new System.Drawing.Size(185, 26);
            this.PasswordOfNewUser.TabIndex = 167;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(112, 277);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(286, 26);
            this.label6.TabIndex = 166;
            this.label6.Text = "Введите пароль пользователя:";
            // 
            // Role
            // 
            this.Role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Role.FormattingEnabled = true;
            this.Role.Items.AddRange(new object[] {
            "Пользователь",
            "Администратор"});
            this.Role.Location = new System.Drawing.Point(404, 330);
            this.Role.Name = "Role";
            this.Role.Size = new System.Drawing.Size(185, 21);
            this.Role.TabIndex = 169;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(120, 324);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(278, 26);
            this.label7.TabIndex = 168;
            this.label7.Text = "Выберете роль пользователя:";
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(926, 505);
            this.Controls.Add(this.Role);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.PasswordOfNewUser);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NameOfNewUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DepartChoose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.LogOfNewUser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBackBtn);
            this.Name = "AddUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddUser";
            this.Load += new System.EventHandler(this.AddUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBackBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBackBtn;
        private System.Windows.Forms.TextBox NameOfNewUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox DepartChoose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.TextBox LogOfNewUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PasswordOfNewUser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox Role;
        private System.Windows.Forms.Label label7;
    }
}