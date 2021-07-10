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
    public partial class DepSettings : Form
    {
        int selectedIndexOfMajor;
        int selectedIDOfMajor;
        string DepName;
        ConnectBD sql = new ConnectBD();
        public DepSettings()
        {
            InitializeComponent();
        }

        private void DepSettings_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                sql.command.CommandText = "SELECT name, majorID FROM Department WHERE id ='" + DataClass.DepartID + "' AND del = '0' ";
                SQLiteDataReader read0 = sql.command.ExecuteReader();
                while (read0.Read())
                {
                    NameOfDep.Text = read0["name"].ToString();
                    DepName = read0["name"].ToString();
                    selectedIDOfMajor = Convert.ToInt32(read0["majorID"]);
                }
                read0.Close();

                sql.command.CommandText = "SELECT id, name FROM Users WHERE del = '0'";
                SQLiteDataReader read1 = sql.command.ExecuteReader();
                int i = 0;
                while (read1.Read())
                {
                    DepartMajor.Items.Add(read1["name"].ToString());
                    if (Convert.ToInt32(read1["id"]) == selectedIDOfMajor)
                    {
                        selectedIndexOfMajor = i;
                        DepartMajor.SelectedIndex = selectedIndexOfMajor;
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

        private void pictureBackBtn_Click(object sender, EventArgs e)
        {
            DepartmentForm departmentForm = new DepartmentForm();
            departmentForm.Show();
            this.Hide();
        }

        private void DepSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if(DepName != NameOfDep.Text || selectedIndexOfMajor != DepartMajor.SelectedIndex)
            {
                try
                {
                    if (selectedIndexOfMajor != DepartMajor.SelectedIndex)
                    {
                        sql.command.CommandText = "SELECT id FROM Users WHERE del = '0' AND name LIKE '" + DepartMajor.SelectedItem + "' ";
                        SQLiteDataReader read2 = sql.command.ExecuteReader();
                        while (read2.Read())
                        {
                            selectedIDOfMajor = Convert.ToInt32(read2["id"]);
                        }
                        read2.Close();
                    }
                    sql.command.CommandText = "UPDATE Department SET name ='" + NameOfDep.Text + "', majorID = '" + selectedIDOfMajor + "' WHERE id = '"+ DataClass.DepartID +"' ";
                    sql.command.ExecuteNonQuery();
                    SQLHistory SqlH = new SQLHistory(); //Сохранение изменений в историю 
                    SqlH.SqlRequest(sql.command.CommandText);
                    MessageBox.Show("Данные отдела '" + NameOfDep.Text + "' успешно изменен!");
                    DepartmentForm departmentForm = new DepartmentForm();
                    departmentForm.Show();
                    this.Hide();
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Данные не изменялись!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы подтверждаете удаление отдела '" + DepName + "' ?", "Подтверждение удаления", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    sql.command.CommandText = "UPDATE Department SET  name = '', majorID = '', del = '1' WHERE id = '" + DataClass.DepartID + "' ";
                    sql.command.ExecuteNonQuery();
                    SQLHistory SqlH = new SQLHistory(); //Сохранение изменений в историю 
                    SqlH.SqlRequest(sql.command.CommandText);
                    MessageBox.Show("Отдел '" + DepName + "' успешно удален!");
                    DataClass.DepartID = 0;
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                }
            }
        }
    }
}
