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
    public partial class AddUser : Form
    {
        ConnectBD sql = new ConnectBD();

        public AddUser()
        {
            InitializeComponent();
        }

        private void pictureBackBtn_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
            this.Hide();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            try
            {
                sql.command.CommandText = "SELECT name FROM Department WHERE del = '0' ";
                SQLiteDataReader read1 = sql.command.ExecuteReader();
                while (read1.Read())
                {
                    DepartChoose.Items.Add(read1["name"].ToString());
                }
                read1.Close();

            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (NameOfNewUser.Text == "" || LogOfNewUser.Text == "" || PasswordOfNewUser.Text == "" || Role.SelectedItem == null || DepartChoose.SelectedItem == null )
            {
                MessageBox.Show("Заполнены не все обязательные поля!");
            }
            else
            {
                try
                {
                    int DepID = 0;
                    sql.command.CommandText = "SELECT id FROM Department WHERE name LIKE '" + DepartChoose.SelectedItem + "' ";
                    SQLiteDataReader read2 = sql.command.ExecuteReader();
                    while(read2.Read())
                    {
                        DepID = Convert.ToInt32(read2["id"]);
                    }
                    read2.Close();
                    int Rol = 3;
                    if (Role.SelectedItem.ToString() == "Администратор")
                    {
                        Rol = 0;
                    }
                    else
                    {
                        Rol = 1;
                    }
                    sql.command.CommandText = "INSERT INTO Users (login, name, password, role, departID) VALUES( '"
                    + LogOfNewUser.Text+
                    "','" + NameOfNewUser.Text +
                    "','" + PasswordOfNewUser.Text +
                    "','" + Rol +
                    "','" + DepID + "') ";
                    sql.command.ExecuteNonQuery();
                    SQLHistory SqlH = new SQLHistory(); //Сохранение изменений в историю 
                    SqlH.SqlRequest(sql.command.CommandText);
                    MessageBox.Show("Пользователь '" + NameOfNewUser.Text + "' успешно добавлен!");
                    Settings settings = new Settings();
                    settings.Show();
                    this.Hide();

                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
