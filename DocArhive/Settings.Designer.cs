namespace DocArhive
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.label2 = new System.Windows.Forms.Label();
            this.Users = new System.Windows.Forms.ListView();
            this.NameOfUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Login = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Password = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Role = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Depart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChangeDataButton = new System.Windows.Forms.Button();
            this.pictureBackBtn = new System.Windows.Forms.PictureBox();
            this.ChangeButton = new System.Windows.Forms.Button();
            this.DelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBackBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(391, -1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 42);
            this.label2.TabIndex = 149;
            this.label2.Text = "Настройки";
            // 
            // Users
            // 
            this.Users.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameOfUser,
            this.Login,
            this.Password,
            this.Role,
            this.Depart});
            this.Users.GridLines = true;
            this.Users.HideSelection = false;
            this.Users.Location = new System.Drawing.Point(169, 56);
            this.Users.MultiSelect = false;
            this.Users.Name = "Users";
            this.Users.Size = new System.Drawing.Size(495, 458);
            this.Users.TabIndex = 153;
            this.Users.UseCompatibleStateImageBehavior = false;
            this.Users.View = System.Windows.Forms.View.Details;
            // 
            // NameOfUser
            // 
            this.NameOfUser.Text = "Имя";
            this.NameOfUser.Width = 140;
            // 
            // Login
            // 
            this.Login.Text = "Логин";
            this.Login.Width = 80;
            // 
            // Password
            // 
            this.Password.Text = "Пароль";
            this.Password.Width = 80;
            // 
            // Role
            // 
            this.Role.Text = "Роль";
            // 
            // Depart
            // 
            this.Depart.Text = "Департамент";
            this.Depart.Width = 130;
            // 
            // ChangeDataButton
            // 
            this.ChangeDataButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(218)))), ((int)(((byte)(216)))));
            this.ChangeDataButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(218)))), ((int)(((byte)(216)))));
            this.ChangeDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeDataButton.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChangeDataButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.ChangeDataButton.Location = new System.Drawing.Point(670, 56);
            this.ChangeDataButton.Name = "ChangeDataButton";
            this.ChangeDataButton.Size = new System.Drawing.Size(162, 58);
            this.ChangeDataButton.TabIndex = 154;
            this.ChangeDataButton.Text = "  Добавить\r\nпользователя";
            this.ChangeDataButton.UseVisualStyleBackColor = false;
            this.ChangeDataButton.Click += new System.EventHandler(this.ChangeDataButton_Click);
            // 
            // pictureBackBtn
            // 
            this.pictureBackBtn.Image = ((System.Drawing.Image)(resources.GetObject("pictureBackBtn.Image")));
            this.pictureBackBtn.Location = new System.Drawing.Point(135, 56);
            this.pictureBackBtn.Name = "pictureBackBtn";
            this.pictureBackBtn.Size = new System.Drawing.Size(28, 28);
            this.pictureBackBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBackBtn.TabIndex = 152;
            this.pictureBackBtn.TabStop = false;
            this.pictureBackBtn.Click += new System.EventHandler(this.pictureBackBtn_Click);
            // 
            // ChangeButton
            // 
            this.ChangeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(218)))), ((int)(((byte)(216)))));
            this.ChangeButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(218)))), ((int)(((byte)(216)))));
            this.ChangeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeButton.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChangeButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.ChangeButton.Location = new System.Drawing.Point(529, 520);
            this.ChangeButton.Name = "ChangeButton";
            this.ChangeButton.Size = new System.Drawing.Size(135, 53);
            this.ChangeButton.TabIndex = 155;
            this.ChangeButton.Text = "Изменить";
            this.ChangeButton.UseVisualStyleBackColor = false;
            this.ChangeButton.Click += new System.EventHandler(this.ChangeButton_Click);
            // 
            // DelButton
            // 
            this.DelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(218)))), ((int)(((byte)(216)))));
            this.DelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(218)))), ((int)(((byte)(216)))));
            this.DelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DelButton.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DelButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.DelButton.Location = new System.Drawing.Point(388, 520);
            this.DelButton.Name = "DelButton";
            this.DelButton.Size = new System.Drawing.Size(135, 53);
            this.DelButton.TabIndex = 156;
            this.DelButton.Text = "Удалить";
            this.DelButton.UseVisualStyleBackColor = false;
            this.DelButton.Click += new System.EventHandler(this.DelButton_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(954, 611);
            this.Controls.Add(this.DelButton);
            this.Controls.Add(this.ChangeButton);
            this.Controls.Add(this.ChangeDataButton);
            this.Controls.Add(this.Users);
            this.Controls.Add(this.pictureBackBtn);
            this.Controls.Add(this.label2);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBackBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBackBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView Users;
        private System.Windows.Forms.ColumnHeader NameOfUser;
        private System.Windows.Forms.ColumnHeader Login;
        private System.Windows.Forms.ColumnHeader Password;
        private System.Windows.Forms.ColumnHeader Role;
        private System.Windows.Forms.ColumnHeader Depart;
        private System.Windows.Forms.Button ChangeDataButton;
        private System.Windows.Forms.Button ChangeButton;
        private System.Windows.Forms.Button DelButton;
    }
}