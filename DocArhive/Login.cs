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
    public partial class Login : Form
    {
        ConnectBD sql = new ConnectBD();
        public String userLogin { get; set; } //??
        public String userPassword { get; set; }
        public int CheckLog { get; set; }
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnCheckLogin_Click(object sender, EventArgs e)
        {

            CheckLog = 0;
            try
            {
                if (tbCheckLogin.Text == "" || tbCheckPassword.Text == "")
                {
                    MessageBox.Show("Введите данные");

                }
                else
                {
                    userLogin = tbCheckLogin.Text;
                    userPassword = tbCheckPassword.Text;
                    int flag = 0;
                    sql.command.CommandText = "SELECT * FROM Users WHERE login ='" + userLogin + "' ";

                    SQLiteDataReader read = sql.command.ExecuteReader();

                    while (read.Read())
                    {
                        if (Convert.ToInt32(read["del"]) == 0)
                        {
                            flag = 1;
                            if (String.Compare(read["password"].ToString(), userPassword) == 0) //read["pasword"].ToString() == userPassword)
                            {
                                CheckLog = 1; // Ставим флаг для перехода в форму DepartForm
                                DataClass.ID = Convert.ToInt32(read["id"]);
                                DataClass.Role = Convert.ToInt32(read["role"]);
                                DataClass.DepartUserID = Convert.ToInt32(read["departID"]);
                                DataClass.NameOfUser = read["name"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Пароль неверный");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Логин неверный");
                        }
                    }
                    read.Close();
                    
                    if (CheckLog == 0)
                    {
                        if(flag == 0)
                        {
                            MessageBox.Show("Логин неверный");
                        }
                    }
                    if (CheckLog ==1 )
                    {
                        this.Hide();
                        MainForm departForm = new MainForm();
                        departForm.Show();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
