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
    public partial class DepartmentForm : Form
    {
        ConnectBD sql = new ConnectBD();
        public DepartmentForm()
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
            try
            {
                sql.command.CommandText = "SELECT name FROM Department WHERE id ='" + DataClass.DepartID + "' AND del = '0' ";
                SQLiteDataReader read10 = sql.command.ExecuteReader();
                while(read10.Read())
                {
                    label2.Text = read10["name"].ToString();
                }
                read10.Close();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
            int top = 152; // Первая локация динамических кнопок
            int left1 = 140;
            int left2 = 294;
            int left3 = 448;
            try
            {
                sql.command.CommandText = "SELECT * FROM Case1 WHERE departID ='" + DataClass.DepartID + "' AND del = '0' ";
                SQLiteDataReader read0 = sql.command.ExecuteReader();
                int i = 1;
                int LastLeft = 0;
                while (read0.Read())
                {
                    Button button = new Button(); // Создание кнопок с делами
                    if (i == 1)
                    {
                        button.Left = left1;
                        LastLeft = left1;
                        button.Top = top;
                    }
                    if (i == 2)
                    {
                        button.Left = left2;
                        LastLeft = left2;
                        button.Top = top;
                    }
                    if (i == 3)
                    {
                        button.Left = left3;
                        LastLeft = left3;
                        button.Top = top;
                        top = top + 80;
                    }
                    i += 1;
                    if (i==4)
                    {
                        i = 1;
                    }
                    button.Name = read0["id"].ToString();
                    button.Click += ButtonOnClick;
                    button.Text = read0["name"].ToString();
                    button.Height = 70;
                    button.Width = 145;
                    button.Font = new System.Drawing.Font("Century Gothic", 13, FontStyle.Bold);  //Franklin Gothic Medium
                    button.FlatStyle = FlatStyle.Flat;
                    button.ForeColor = Color.White;
                    button.BackColor = Color.FromArgb(62, 218, 216);
                    button.FlatAppearance.BorderColor = Color.FromArgb(62, 218, 216);

                    this.Controls.Add(button);
                }
                read0.Close();
                Button buttonToAdd = new Button(); // Создание кнопки добавления дела
                if (LastLeft != left3)
                {
                    top = top + 80;
                }
                buttonToAdd.Left = left1;
                buttonToAdd.Top = top;
                buttonToAdd.Name = "144"; //add
                buttonToAdd.Click += ButtonOnClick;
                buttonToAdd.Text = "+";
                buttonToAdd.Height = 70;
                buttonToAdd.Width = 145;
                buttonToAdd.Font = new System.Drawing.Font("Century Gothic", 13, FontStyle.Bold);  //Franklin Gothic Medium
                buttonToAdd.FlatStyle = FlatStyle.Flat;
                buttonToAdd.ForeColor = Color.White;
                buttonToAdd.BackColor = Color.FromArgb(62, 218, 216);
                buttonToAdd.FlatAppearance.BorderColor = Color.FromArgb(62, 218, 216);

                this.Controls.Add(buttonToAdd);
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
                    AddCase addcase = new AddCase();
                    addcase.Show();
                    //MessageBox.Show("Прощай " + button.Name);
                }
                else //если нажаты кнопки дел
                {
                    DataClass.CaseID = Convert.ToInt32(button.Name); //Записываем номер дела к которому переходим
                    this.Hide();
                    CaseForm caseForm = new CaseForm();
                    caseForm.Show();
                }

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataClass.CaseID = 0;
            DataClass.DepartID = 0;
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e) //Кнопка назад к форме MainForm
        {
            DataClass.DepartID = 0;
            this.Hide();
            MainForm departForm = new MainForm();
            departForm.Show();
        }

        private void DepartmentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pictureSetBut_Click(object sender, EventArgs e)
        {
            DepSettings settings = new DepSettings();
            settings.Show();
            this.Hide();
        }
    }
}
