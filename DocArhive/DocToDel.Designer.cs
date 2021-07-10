namespace DocArhive
{
    partial class DocToDel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocToDel));
            this.DelDocs = new System.Windows.Forms.ListView();
            this.NameOfUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.delDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBackBtn = new System.Windows.Forms.PictureBox();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBackBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // DelDocs
            // 
            this.DelDocs.CheckBoxes = true;
            this.DelDocs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameOfUser,
            this.date,
            this.delDate});
            this.DelDocs.GridLines = true;
            this.DelDocs.HideSelection = false;
            this.DelDocs.Location = new System.Drawing.Point(169, 56);
            this.DelDocs.Name = "DelDocs";
            this.DelDocs.Size = new System.Drawing.Size(425, 458);
            this.DelDocs.TabIndex = 156;
            this.DelDocs.UseCompatibleStateImageBehavior = false;
            this.DelDocs.View = System.Windows.Forms.View.Details;
            // 
            // NameOfUser
            // 
            this.NameOfUser.Text = "Имя";
            this.NameOfUser.Width = 204;
            // 
            // date
            // 
            this.date.Text = "Дата создания";
            this.date.Width = 110;
            // 
            // delDate
            // 
            this.delDate.Text = "Дата утилизации";
            this.delDate.Width = 107;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(128, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(777, 42);
            this.label2.TabIndex = 154;
            this.label2.Text = "Список документов с истекшим сроком хранения";
            // 
            // pictureBackBtn
            // 
            this.pictureBackBtn.Image = ((System.Drawing.Image)(resources.GetObject("pictureBackBtn.Image")));
            this.pictureBackBtn.Location = new System.Drawing.Point(135, 56);
            this.pictureBackBtn.Name = "pictureBackBtn";
            this.pictureBackBtn.Size = new System.Drawing.Size(28, 28);
            this.pictureBackBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBackBtn.TabIndex = 155;
            this.pictureBackBtn.TabStop = false;
            this.pictureBackBtn.Click += new System.EventHandler(this.pictureBackBtn_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(218)))), ((int)(((byte)(216)))));
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(218)))), ((int)(((byte)(216)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(351, 520);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(243, 51);
            this.button6.TabIndex = 157;
            this.button6.Text = "Сформировать акт об унечтожении и удалить ";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // DocToDel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 590);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.DelDocs);
            this.Controls.Add(this.pictureBackBtn);
            this.Controls.Add(this.label2);
            this.Name = "DocToDel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DocToDel";
            this.Load += new System.EventHandler(this.DocToDel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBackBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView DelDocs;
        private System.Windows.Forms.ColumnHeader NameOfUser;
        private System.Windows.Forms.ColumnHeader date;
        private System.Windows.Forms.ColumnHeader delDate;
        private System.Windows.Forms.PictureBox pictureBackBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button6;
    }
}