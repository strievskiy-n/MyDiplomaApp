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
    public partial class AddCase : Form
    {
        ConnectBD sql = new ConnectBD();
        public AddCase()
        {
            InitializeComponent();
        }

        private void AddCase_Load(object sender, EventArgs e)
        {
            try
            {
                sql.command.CommandText = "SELECT * FROM Users WHERE del = '0' AND departID = '" + DataClass.DepartID + "' ORDER BY name";
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

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (NumberOfNewCase.Text == "") //tbCheckLogin.Text == "" && tbCheckPassword.Text == ""
            {
                MessageBox.Show("Введите название нового отдела!");
            }
            else
            {
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Выберите имя начальника отдела!");
                }
                else
                {
                    try
                    {
                        sql.command.CommandText = "SELECT id FROM Users WHERE name LIKE '" + comboBox1.SelectedItem + "' ";
                        SQLiteDataReader read1 = sql.command.ExecuteReader();
                        int ID = 0;
                        while (read1.Read())
                        {
                            ID = Convert.ToInt32(read1["id"]);
                        }
                        read1.Close();

                        sql.command.CommandText = "INSERT INTO Case1 (name, departID, number, majorID) VALUES( '" + NameOfNewCase.Text + "' , '" + DataClass.DepartID + "' , '" + NumberOfNewCase.Text + "', '" + ID + "' )";
                        sql.command.ExecuteNonQuery();
                        SQLHistory SqlH = new SQLHistory(); //Сохранение изменений в историю 
                        SqlH.SqlRequest(sql.command.CommandText);
                        MessageBox.Show("Дело "+ NameOfNewCase.Text + " успешно добавлено!"); //Сообщение об успешном добавлении отдела
                        this.Hide();//Переход к окну дел
                        DepartmentForm depForm = new DepartmentForm();
                        depForm.Show();
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show("Error:" + ex.Message);
                    }
                }
            }
        }

        private void pictureBackBtn_Click(object sender, EventArgs e) //Переход назад к выбору дел в форму Отдела (DepartmentForm)
        {
            DepartmentForm depForm = new DepartmentForm();
            depForm.Show();
            this.Hide();
        }

        private void AddCase_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
