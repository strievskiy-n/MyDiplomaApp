using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Data.SQLite;

namespace DocArhive
{
    public partial class CaseForm : Form
    {
        ConnectBD sql = new ConnectBD();
        public CaseForm()
        {
            InitializeComponent();
        }

        private void CaseForm_Load(object sender, EventArgs e)
        {
            if (DataClass.Role == 1) //кнопка для перехода к настройкам, если вы админ
            {
                pictureSetBut.Enabled = false;
                pictureSetBut.Visible = false;
            }
            try //Вывод имени дела
            {
                sql.command.CommandText = "SELECT name FROM Case1 WHERE id ='" + DataClass.CaseID + "' AND del = '0' ";
                SQLiteDataReader read10 = sql.command.ExecuteReader();
                while (read10.Read())
                {
                    label2.Text = read10["name"].ToString();
                }
                read10.Close();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }

            try// вывод документов дела
            {
                int top = pictureBox1.Top;
                top += pictureBox1.Height + 10;
                int left = pictureBox1.Left;
                
                sql.command.CommandText = "SELECT  id, name, caseID FROM Document WHERE DepartID ='" + DataClass.DepartID + "' AND isThisFileDel ='0' ";
                SQLiteDataReader read0 = sql.command.ExecuteReader();
                while (read0.Read())
                {
                    if (Convert.ToInt32(read0["caseID"]) == DataClass.CaseID)
                    {
                        Button button = new Button(); // Создание кнопок с доками

                        button.Left = left;
                        button.Top = top;
                        top = top + 37;
                        button.Name = read0["id"].ToString();
                        button.Click += ButtonOnClick;
                        button.Text = read0["name"].ToString();
                        button.Height = 35;
                        button.Width = pictureBox1.Width;
                        button.Font = new System.Drawing.Font("Century Gothic", 13, FontStyle.Bold);  //Franklin Gothic Medium
                        button.FlatStyle = FlatStyle.Flat;
                        button.ForeColor = Color.White;
                        button.BackColor = Color.FromArgb(62, 218, 216);
                        button.FlatAppearance.BorderColor = Color.FromArgb(62, 218, 216);

                        this.Controls.Add(button);
                    }
                }
                read0.Close();

                Button AddButton = new Button(); // Создаю кнопку добавления документа
                AddButton.Left = left;
                AddButton.Top = top;
                AddButton.Name = "144";
                AddButton.Click += ButtonOnClick;
                AddButton.Text = "+";
                AddButton.Height = 35;
                AddButton.Width = pictureBox1.Width;
                AddButton.Font = new System.Drawing.Font("Century Gothic", 13, FontStyle.Bold);  //Franklin Gothic Medium
                AddButton.FlatStyle = FlatStyle.Flat;
                AddButton.ForeColor = Color.White;
                AddButton.BackColor = Color.FromArgb(62, 218, 216);
                AddButton.FlatAppearance.BorderColor = Color.FromArgb(62, 218, 216);
                this.Controls.Add(AddButton);
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void ButtonOnClick(object sender, EventArgs eventArgs)
        {
            var button = (Button)sender;
            if (button != null)
            {
                if (Convert.ToInt32(button.Name) == 144) //Если нажата кнопка "+" 
                {
                    this.Hide();
                    AddDoc adddoc = new AddDoc();
                    adddoc.Show();
                }
                else //если нажаты кнопки дел
                {
                    DataClass.DocID = Convert.ToInt32(button.Name); //Записываем номер документа к которому переходим
                    this.Hide();
                    DocForm docForm = new DocForm();
                    docForm.Show();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataClass.CaseID = 0;
            this.Hide();
            DepartmentForm departForm = new DepartmentForm();
            departForm.Show();
        }

        private void pictureBackBtn_Click(object sender, EventArgs e)
        {
            DataClass.CaseID = 0;
            this.Hide();
            DepartmentForm departForm = new DepartmentForm();
            departForm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DataClass.CaseID = 0;
            DataClass.DepartID = 0;
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void ListDocBtn_Click(object sender, EventArgs e)
        {
            DocList docList = new DocList();
            docList.Show();
        }

        private void CaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pictureSetBut_Click(object sender, EventArgs e)
        {
            CaseSettings caseSettings = new CaseSettings();
            caseSettings.Show();
            this.Hide();
        }
    }
}
