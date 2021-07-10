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
    public partial class CaseSettings : Form
    {
        int IDOfMajor;
        int selectedIndexOfMajor;
        string CaseName;
        string CaseNumber;
        ConnectBD sql = new ConnectBD();
        public CaseSettings()
        {
            InitializeComponent();
        }

        private void pictureBackBtn_Click(object sender, EventArgs e)
        {
            CaseForm caseForm = new CaseForm();
            caseForm.Show();
            this.Hide();
        }

        private void CaseSettings_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                sql.command.CommandText = "SELECT * FROM Case1 WHERE del ='0' AND id ='" + DataClass.CaseID +"' ";
                SQLiteDataReader read0 = sql.command.ExecuteReader();
                while (read0.Read())
                {
                    NameOfCase.Text = CaseName = read0["name"].ToString();
                    NumberOfCase.Text = CaseNumber = read0["number"].ToString();
                    IDOfMajor = Convert.ToInt32(read0["majorID"]);
                    DepOfCase.Text = Convert.ToString(read0["departID"]);
                }
                read0.Close();

                sql.command.CommandText = "SELECT id, name FROM Users WHERE del = '0' AND departID = '" + DataClass.DepartID + "' ";
                SQLiteDataReader read1 = sql.command.ExecuteReader();
                int i = 0;
                while (read1.Read())
                {
                    DepartMajor.Items.Add(read1["name"].ToString());
                    if (Convert.ToInt32(read1["id"]) == IDOfMajor)
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

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if(NameOfCase.Text != CaseName || NumberOfCase.Text != CaseNumber || selectedIndexOfMajor != DepartMajor.SelectedIndex)
            {
                sql.command.CommandText = "SELECT id FROM Users WHERE del = '0' AND name LIKE '" + DepartMajor.SelectedItem + "' ";
                SQLiteDataReader read2 = sql.command.ExecuteReader();
                while (read2.Read())
                {
                    IDOfMajor = Convert.ToInt32(read2["id"]);
                }
                read2.Close();
                sql.command.CommandText = "UPDATE Case1 SET name ='" + NameOfCase.Text + "', number ='" + NumberOfCase.Text + "', majorID = '" + IDOfMajor + "' WHERE id = '" + DataClass.CaseID + "' ";
                sql.command.ExecuteNonQuery();
                SQLHistory SqlH = new SQLHistory(); //Сохранение изменений в историю 
                SqlH.SqlRequest(sql.command.CommandText);
                MessageBox.Show("Данные дела '" + NameOfCase.Text + "' успешно изменены!");
                CaseForm caseForm = new CaseForm();
                caseForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Данные не изменялись!");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы подтверждаете удаление дела '" + CaseName + "' ?", "Подтверждение удаления", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    sql.command.CommandText = "UPDATE Case1 SET  name = '', departID = '', number = '', majorID = '', del = '1' WHERE id = '" + DataClass.CaseID + "' ";
                    sql.command.ExecuteNonQuery();
                    SQLHistory SqlH = new SQLHistory(); //Сохранение изменений в историю 
                    SqlH.SqlRequest(sql.command.CommandText);
                    MessageBox.Show("Дело '" + CaseName + "' успешно удалено!");
                    DataClass.CaseID = 0;
                    DepartmentForm departmentForm = new DepartmentForm();
                    departmentForm.Show();
                    this.Hide();
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                }
            }
        }

        private void CaseSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
