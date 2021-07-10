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
    public partial class AddDepart : Form
    {
        ConnectBD sql = new ConnectBD();
        public AddDepart()
        {
            InitializeComponent();
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AddDepart_Load(object sender, EventArgs e)
        {
            try
            {
                sql.command.CommandText = "SELECT * FROM Users WHERE del = '0' ORDER BY name ";
                SQLiteDataReader read0 = sql.command.ExecuteReader();

                while (read0.Read())
                {
                    comboBox1.Items.Add(read0["name"]);
                }
                read0.Close();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnCheckLogin_Click(object sender, EventArgs e)
        {
            if (NameOfNewDep.Text== "") //tbCheckLogin.Text == "" && tbCheckPassword.Text == ""
            {
                MessageBox.Show("Введите название нового отдела!");
            }
            else
            {
                if (comboBox1.Text =="")
                {
                    MessageBox.Show("Выберите имя начальника отдела!");
                }
                else
                {
                    try
                    {
                        sql.command.CommandText = "SELECT id FROM Users WHERE name LIKE '"+ comboBox1.SelectedItem +"' AND del = '0' ";
                        SQLiteDataReader read1 = sql.command.ExecuteReader();
                        int ID=0;
                        while (read1.Read())
                        {
                            ID = Convert.ToInt32(read1["id"]);
                        }
                        read1.Close();
                        
                        sql.command.CommandText = "INSERT INTO Department (name, majorID) VALUES( '"+ NameOfNewDep.Text + "', '" + ID + "' )";
                        sql.command.ExecuteNonQuery();
                        SQLHistory SqlH = new SQLHistory(); //Сохранение изменений в историю 
                        SqlH.SqlRequest(sql.command.CommandText);
                        MessageBox.Show(NameOfNewDep.Text + " успешно добавлен!"); //Сообщение об успешном добавлении отдела
                        this.Hide();//Переход к окну отделов
                        MainForm departForm = new MainForm();
                        departForm.Show();


                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show("Error:" + ex.Message);
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm departForm = new MainForm();
            departForm.Show();
        }
        private void AddDepart_FormClosing(object sender, FormClosingEventArgs e) //Добавить к дочерней форме
        {
            Application.Exit();
        }
    }
}
