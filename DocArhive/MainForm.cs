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
    public partial class MainForm : Form
    {
        ConnectBD sql = new ConnectBD();
        public MainForm()
        {
            InitializeComponent();
        }

        private void DepartForm_Load(object sender, EventArgs e)
        {
            QueryField.Text = DataClass.FilterFields[0];
            if (DataClass.Role == 1) //кнопка для перехода к настройкам, если вы админ
            {
                pictureSetBut.Enabled = false;
                pictureSetBut.Visible = false;
            }
            int top = 151; // Первая локация динамических кнопок
            int left1 = 139;
            try
            {
                button1.Visible = true;
                if (DataClass.Role == 0)// Если это админ, то выдаем все департаменты(отделы)
                {
                    sql.command.CommandText = "SELECT * FROM Department WHERE del = '0'";
                    SQLiteDataReader read0 = sql.command.ExecuteReader();
                    int left2 = 372;
                    int i = 0;
                    while (read0.Read())
                    {
                        Button button = new Button();
                        if (i % 2 == 0)
                        {
                            button.Left = left1;
                        }
                        else
                        {
                            button.Left = left2;
                        }
                        button.Top = top;
                        button.Name = read0["id"].ToString();
                        button.Click += ButtonOnClick;
                        button.Text = read0["name"].ToString().ToUpper();
                        button.Height = 70;
                        button.Width = 220;
                        button.Font = new System.Drawing.Font("Century Gothic", 13, FontStyle.Bold);  //Franklin Gothic Medium
                        button.FlatStyle =FlatStyle.Flat;
                        button.ForeColor = Color.White;
                        button.BackColor = Color.FromArgb(62, 218, 216);
                        button.FlatAppearance.BorderColor = Color.FromArgb(62, 218, 216);

                        this.Controls.Add(button);
                        if (i % 2 != 0)
                        {
                            top += 80;
                        }
                        i += 1;
                    }
                    read0.Close();
                    if (DataClass.Role == 0) //если админ
                    {
                        Button buttonToAdd = new Button(); //Создаем кнопку для добавления департамента
                        buttonToAdd.Left = left1;
                        if (i % 2 != 0)
                        {
                            buttonToAdd.Top = top + 80;
                        }
                        else
                        {
                            buttonToAdd.Top = top;
                        }
                        buttonToAdd.Name = "144"; //add
                        buttonToAdd.Click += ButtonOnClick;
                        buttonToAdd.Text = "+";
                        buttonToAdd.Height = 70;
                        buttonToAdd.Width = 220;
                        buttonToAdd.Font = new System.Drawing.Font("Century Gothic", 13, FontStyle.Bold);  //Franklin Gothic Medium
                        buttonToAdd.FlatStyle = FlatStyle.Flat;
                        buttonToAdd.ForeColor = Color.White;
                        buttonToAdd.BackColor = Color.FromArgb(62, 218, 216);
                        buttonToAdd.FlatAppearance.BorderColor = Color.FromArgb(62, 218, 216);
                        this.Controls.Add(buttonToAdd);
                    }
                }
                else // Если это юзер, то выдаем ему его департамент
                {
                    sql.command.CommandText = "SELECT name FROM Department WHERE id ='" + DataClass.DepartUserID + "' AND del = '0' ";
                    SQLiteDataReader read1 = sql.command.ExecuteReader();

                    while (read1.Read())
                    {
                        Button buttonUs = new Button();
                        buttonUs.Left = left1;
                        buttonUs.Top = top;
                        buttonUs.Name = DataClass.DepartUserID.ToString();
                        buttonUs.Click += ButtonOnClick;
                        buttonUs.Text = read1["name"].ToString();
                        buttonUs.Height = 70;
                        buttonUs.Width = 220;
                        buttonUs.Font = new System.Drawing.Font("Century Gothic", 13, FontStyle.Bold);  //Franklin Gothic Medium
                        buttonUs.FlatStyle = FlatStyle.Flat;
                        buttonUs.ForeColor = Color.White;
                        buttonUs.BackColor = Color.FromArgb(62, 218, 216);
                        buttonUs.FlatAppearance.BorderColor = Color.FromArgb(62, 218, 216);

                        this.Controls.Add(buttonUs);
                    }
                    read1.Close();
                }
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
                    AddDepart addDepart = new AddDepart();
                    addDepart.Show();
                    DataClass.KillFilters();//Удалили фильтры
                }
                else
                {
                    DataClass.DepartID = Convert.ToInt32(button.Name); //Записываем номер депортамента к которому переходим
                    this.Hide();
                    DepartmentForm caseForm = new DepartmentForm();
                    caseForm.Show();
                    DataClass.KillFilters();//Удалили фильтры
                }
            }
        }

        private void pictureSetBut_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            DataClass.KillFilters();//Удалили фильтры
            settings.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ChangeDataButton_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DocToDel docToDel = new DocToDel();
            docToDel.Show();
        }
        private void button2_MouseMove(object sender, EventArgs e)
        {
            button2.BackColor = Color.Red;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (QueryField.Text == "")
            {
                if (DataClass.FilterFields[0] == "" && DataClass.FilterFields[1] == "" && DataClass.FilterFields[2] == "" && DataClass.FilterFields[3] == "" && DataClass.FilterFields[4] == "" && DataClass.FilterFields[5] == "" && DataClass.FilterFields[6] == "" && DataClass.FilterFields[7] == "" && DataClass.FilterFields[8] == "" && DataClass.FilterFields[9] == "" && DataClass.FilterFields[10] == "" && DataClass.FilterFields[11] == "" && DataClass.FilterFields[12] == "" && DataClass.FilterFields[13] == "" && DataClass.FilterFields[14] == "" && DataClass.FilterFields[15] == "" && DataClass.FilterFields[16] == "" )
                {
                    MessageBox.Show("Введите запрос!");
                }
                else
                {
                    Search search = new Search();
                    search.Show();
                    this.Hide();
                }
            }
            else
            {
                DataClass.FilterFields[0] = QueryField.Text;
                Search search = new Search();
                search.Show();
                this.Hide();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (QueryField.Text != "")
            {
                DataClass.FilterFields[0] = QueryField.Text;
            }
            Filters filters = new Filters();
            filters.Show();
        }
    }
}
