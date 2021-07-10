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
    public partial class Settings : Form
    {
        ConnectBD sql = new ConnectBD();
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                CountSize size = new CountSize();
                int Size = size.countsize("Department"); //Достаем число неудаленных департаментов
                int[] id = new int[Size];
                string[] name = new string[Size];
                sql.command.CommandText = "SELECT id, name FROM Department WHERE del = '0' ";
                SQLiteDataReader read1 = sql.command.ExecuteReader();
                int i = 0;
                while (read1.Read())
                {
                    id[i] = Convert.ToInt32(read1["id"]);
                    name[i] = read1["name"].ToString();
                    i += 1;
                }
                read1.Close();

                sql.command.CommandText = "SELECT * FROM Users WHERE del = '0'";
                SQLiteDataReader read = sql.command.ExecuteReader();
                while (read.Read())
                {
                    ListViewItem listViewItem = new ListViewItem(read["name"].ToString()); //id, login, name, password, role, depart
                    listViewItem.SubItems.Add(read["login"].ToString());
                    listViewItem.SubItems.Add(read["password"].ToString());
                    if (Convert.ToInt32(read["role"]) == 0)
                    {
                        listViewItem.SubItems.Add("Админ");
                    }
                    else
                    {
                        listViewItem.SubItems.Add("Пользователь");
                    }
                    int a = 0;
                    while (a <= i - 1)
                    {
                        if (Convert.ToInt32(read["departID"]) == id[a])
                        {
                            listViewItem.SubItems.Add(name[a]);
                        }
                        a += 1;
                    }
                    Users.Items.Add(listViewItem); //Добавляю запись в список пользователей
                }
                read.Close();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void ChangeDataButton_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.Show();
            this.Hide();
        }

        private void pictureBackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            if (Users.SelectedItems.Count != 0)
            {
                DataClass.ChangeUserName = Convert.ToString(Users.SelectedItems[0].SubItems[0].Text);
                ChangeUser chusr = new ChangeUser();
                chusr.Show();
                this.Hide();
            }
        }

        private void DelButton_Click(object sender, EventArgs e) //кнопка для удаления пользователя
        {
            if (Users.SelectedItems.Count != 0)
            {
                string UserName = Convert.ToString(Users.SelectedItems[0].SubItems[0].Text);
                DialogResult result = MessageBox.Show("Вы подтверждаете удаление пользователя " + UserName + " ?", "Подтверждение удаления", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        sql.command.CommandText = "UPDATE Users SET login = '', name = '', password = '', role = '', departID = '', del = '1' WHERE name LIKE '" + UserName + "' ";
                        sql.command.ExecuteNonQuery();
                        SQLHistory SqlH = new SQLHistory(); //Сохранение изменений в историю 
                        SqlH.SqlRequest(sql.command.CommandText);
                        MessageBox.Show("Пользователь '" + UserName + "' успешно удален!");
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show("Error:" + ex.Message);
                    }
                }
                Users.Items.Clear();
                LoadData();
            }
        }
    }
    public class CountSize
    {
        ConnectBD sql = new ConnectBD();
        public int countsize(string name)
        {
            int size = 0;
            try
            {
                sql.command.CommandText = "SELECT id FROM " + name + " WHERE del = '0'  ";
                SQLiteDataReader read0 = sql.command.ExecuteReader();
                while (read0.Read())
                {
                    size += 1;
                }
                read0.Close();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }

            return size;
        }
    }
}
