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
    public partial class ChangeUser : Form
    {
        ConnectBD sql = new ConnectBD();

        string SName = "";
        string SLog = "";
        string SPas = "";
        int SDepartID = 0;
        int SRole ;
        int SID ;
        int DepIndex;
        public ChangeUser()
        {
            InitializeComponent();
        }

        private void pictureBackBtn_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
            this.Hide();
        }

        private void ChangeUser_Load(object sender, EventArgs e)
        {
            try
            {
                sql.command.CommandText = "SELECT * FROM Users WHERE name LIKE '"+ DataClass.ChangeUserName + "' AND del = '0' ";
                SQLiteDataReader read0 = sql.command.ExecuteReader();
                while(read0.Read())
                {
                    SID = Convert.ToInt32(read0["id"]);
                    NameOfUser.Text = read0["name"].ToString();
                    SName = read0["name"].ToString();
                    LogOfUser.Text = read0["login"].ToString();
                    SLog = read0["login"].ToString();
                    PasswordOfUser.Text = read0["password"].ToString();
                    SPas = read0["password"].ToString();
                    SRole = Convert.ToInt32(read0["role"]);
                    SDepartID = Convert.ToInt32(read0["departID"]);
                }
                read0.Close();
                if (SRole == 0)
                {
                    Role.Items.Add("Администратор");
                    Role.Items.Add("Пользователь");
                    Role.SelectedIndex = 0;
                }
                if (SRole == 1)
                {
                    Role.Items.Add("Администратор");
                    Role.Items.Add("Пользователь");
                    Role.SelectedIndex = 1;
                }
                
                sql.command.CommandText = "SELECT name, id FROM Department WHERE del = '0'";
                SQLiteDataReader read1 = sql.command.ExecuteReader();
                int i = 0;
                while (read1.Read())
                {
                    DepartChoose.Items.Add(read1["name"].ToString());
                    if (Convert.ToInt32(read1["id"]) == SDepartID)
                    {
                        DepartChoose.SelectedIndex = i;
                        DepIndex = i;
                    }
                    i += 1;
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
            int NewDepID = 0;
            try //Если поменяли отдел, то юзер больше ни за что не ответственный в своем старом отделе
            {
                sql.command.CommandText = "SELECT id FROM Department WHERE name LIKE '" + DepartChoose.SelectedItem + "' ";
                SQLiteDataReader read2 = sql.command.ExecuteReader();
                while (read2.Read())
                {
                    NewDepID = Convert.ToInt32(read2["id"]); //Записываю в старую переменную от departID новый departID
                }
                read2.Close();
                if(SDepartID != NewDepID) //Если отдел поменялся, то снимаем пользователя с ответственных мест в других отделах
                {
                    sql.command.CommandText = "UPDATE Case1 SET majorID = 'NULL' WHERE majorID = '"+ SID + "' ";
                    sql.command.ExecuteNonQuery();
                    SQLHistory SqlH = new SQLHistory(); //Сохранение изменений в историю 
                    SqlH.SqlRequest(sql.command.CommandText);
                    sql.command.CommandText = "UPDATE Document SET majorID = 'NULL' WHERE majorID = '" + SID + "' ";
                    sql.command.ExecuteNonQuery();
                    SqlH.SqlRequest(sql.command.CommandText);
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }

            if (SName != NameOfUser.Text || SLog != LogOfUser.Text || SPas != PasswordOfUser.Text || Role.SelectedIndex != SRole || DepIndex != DepartChoose.SelectedIndex ) 
            {
                try
                {
                    sql.command.CommandText = "UPDATE Users SET login = '"+ LogOfUser.Text 
                        + "', name = '" + NameOfUser.Text 
                        + "', password = '" + PasswordOfUser.Text 
                        + "', role = '"+ Role.SelectedIndex 
                        + "', departID = '"+ NewDepID
                        + "' WHERE del = '0' AND id ='" + SID +"'";
                    sql.command.ExecuteNonQuery();
                    SQLHistory SqlH = new SQLHistory(); //Сохранение изменений в историю 
                    SqlH.SqlRequest(sql.command.CommandText);
                    MessageBox.Show("Данные пользователя '" + DataClass.ChangeUserName + "' успешно изменены!");
                    DataClass.ChangeUserName = "";
                    this.Hide();
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Данные не изменялись.");
            }
            Settings settings = new Settings();
            settings.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
