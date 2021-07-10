namespace DocArhive
{
    partial class ChangeUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeUser));
            this.Role = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.PasswordOfUser = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.NameOfUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DepartChoose = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AddBtn = new System.Windows.Forms.Button();
            this.LogOfUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBackBtn = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBackBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // Role
            // 
            this.Role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Role.FormattingEnabled = true;
            this.Role.Location = new System.Drawing.Point(400, 307);
            this.Role.Name = "Role";
            this.Role.Size = new System.Drawing.Size(185, 21);
            this.Role.TabIndex = 184;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(202, 301);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 26);
            this.label7.TabIndex = 183;
            this.label7.Text = "Роль пользователя:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // PasswordOfUser
            // 
            this.PasswordOfUser.BackColor = System.Drawing.Color.White;
            this.PasswordOfUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordOfUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordOfUser.Location = new System.Drawing.Point(400, 256);
            this.PasswordOfUser.Name = "PasswordOfUser";
            this.PasswordOfUser.Size = new System.Drawing.Size(185, 26);
            this.PasswordOfUser.TabIndex = 182;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(179, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(211, 26);
            this.label6.TabIndex = 181;
            this.label6.Text = "Пароль пользователя:";
            // 
            // NameOfUser
            // 
            this.NameOfUser.BackColor = System.Drawing.Color.White;
            this.NameOfUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameOfUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameOfUser.Location = new System.Drawing.Point(400, 160);
            this.NameOfUser.Name = "NameOfUser";
            this.NameOfUser.Size = new System.Drawing.Size(185, 26);
            this.NameOfUser.TabIndex = 179;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(208, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 26);
            this.label1.TabIndex = 178;
            this.label1.Text = "Имя пользователя:";
            // 
            // DepartChoose
            // 
            this.DepartChoose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DepartChoose.FormattingEnabled = true;
            this.DepartChoose.Location = new System.Drawing.Point(400, 350);
            this.DepartChoose.Name = "DepartChoose";
            this.DepartChoose.Size = new System.Drawing.Size(185, 21);
            this.DepartChoose.TabIndex = 177;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 33F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(204, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(418, 108);
            this.label2.TabIndex = 175;
            this.label2.Text = "Изменение  данных \r\n    пользователя";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(191, 345);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(199, 26);
            this.label5.TabIndex = 174;
            this.label5.Text = "Отдел пользователя:";
            // 
            // AddBtn
            // 
            this.AddBtn.BackColor = System.Drawing.Color.PaleTurquoise;
            this.AddBtn.FlatAppearance.BorderSize = 0;
            this.AddBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddBtn.ForeColor = System.Drawing.Color.Black;
            this.AddBtn.Location = new System.Drawing.Point(359, 392);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(98, 37);
            this.AddBtn.TabIndex = 173;
            this.AddBtn.Text = "Изменить";
            this.AddBtn.UseVisualStyleBackColor = false;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // LogOfUser
            // 
            this.LogOfUser.BackColor = System.Drawing.Color.White;
            this.LogOfUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LogOfUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LogOfUser.Location = new System.Drawing.Point(400, 208);
            this.LogOfUser.Name = "LogOfUser";
            this.LogOfUser.Size = new System.Drawing.Size(185, 26);
            this.LogOfUser.TabIndex = 172;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(192, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 26);
            this.label4.TabIndex = 171;
            this.label4.Text = "Логин пользователя:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(628, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 348);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 176;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBackBtn
            // 
            this.pictureBackBtn.Image = ((System.Drawing.Image)(resources.GetObject("pictureBackBtn.Image")));
            this.pictureBackBtn.Location = new System.Drawing.Point(131, 33);
            this.pictureBackBtn.Name = "pictureBackBtn";
            this.pictureBackBtn.Size = new System.Drawing.Size(28, 28);
            this.pictureBackBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBackBtn.TabIndex = 170;
            this.pictureBackBtn.TabStop = false;
            this.pictureBackBtn.Click += new System.EventHandler(this.pictureBackBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(482, 392);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(325, 26);
            this.label3.TabIndex = 185;
            this.label3.Text = "* При изменении отдела пользователя, он снимается со всех \r\nответственных должнос" +
    "тей в других отделах";
            // 
            // ChangeUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(907, 453);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Role);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.PasswordOfUser);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.NameOfUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DepartChoose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.LogOfUser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBackBtn);
            this.Name = "ChangeUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangeUser";
            this.Load += new System.EventHandler(this.ChangeUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBackBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Role;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox PasswordOfUser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox NameOfUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox DepartChoose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.TextBox LogOfUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBackBtn;
        private System.Windows.Forms.Label label3;
    }
}