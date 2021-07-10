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
    public partial class Search : Form
    {
        string SearchQuery = "";
        ConnectBD sql = new ConnectBD();
        public Search()
        {
            InitializeComponent();
        }

        private void Search_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            string RoleQuery = " ";
            if(DataClass.Role != 0)
            {
                RoleQuery = "AND departID ='"+ DataClass.DepartUserID +"' "; //разница ролей пользователей
            }
            string FilterQuery = "";
            if (Convert.ToInt32(DataClass.FilterFields[18]) == 1) //поиск с фмльтрами
            {
                int con = 1;
                while(con!=18)
                {
                    if(DataClass.FilterFields[con] == "")
                    {

                    }
                    if (DataClass.FilterFields[con] != "")
                    {
                        if (con == 2 || con == 3 || con == 4)
                        {
                            try
                            { 
                                if (con == 2)
                                {
                                    sql.command.CommandText = "SELECT id FROM Users WHERE del = '0' AND name LIKE '"+ DataClass.FilterFields[con] + "' ";
                                    SQLiteDataReader read2 = sql.command.ExecuteReader();
                                    while(read2.Read())
                                    {
                                        FilterQuery += " AND " + DataClass.FilterNames[con] + " = '"+ read2["id"] +"' ";
                                    }
                                    read2.Close();
                                }
                                if (con == 3)
                                {
                                    sql.command.CommandText = "SELECT id FROM Case1 WHERE del = '0' AND name LIKE '" + DataClass.FilterFields[con] + "' ";
                                    SQLiteDataReader read3 = sql.command.ExecuteReader();
                                    while (read3.Read())
                                    {
                                        FilterQuery += " AND " + DataClass.FilterNames[con] + " = '" + read3["id"] + "' ";
                                    }
                                    read3.Close();
                                }
                                if (con == 4)
                                {
                                    sql.command.CommandText = "SELECT id FROM Department WHERE del = '0' AND name LIKE '" + DataClass.FilterFields[con] + "' ";
                                    SQLiteDataReader read4 = sql.command.ExecuteReader();
                                    while (read4.Read())
                                    {
                                        FilterQuery += " AND " + DataClass.FilterNames[con] + " = '" + read4["id"] + "' ";
                                    }
                                    read4.Close();
                                }
                            }
                            catch (SQLiteException ex)
                            {
                                MessageBox.Show("Error:" + ex.Message);
                            }
                        }
                        else
                        {
                            FilterQuery += " AND lower(" + DataClass.FilterNames[con] + ") LIKE '%" + DataClass.FilterFields[con].ToLower() + "%' ";
                        }
                    }
                    con += 1;
                }
            }
            QueryField.Text  = SearchQuery = DataClass.FilterFields[0]; //вставляю главный поисковый запрос в поисковую строку
            string MainQuery = "";
            if (DataClass.FilterFields[0] != "")
            {
                MainQuery = "AND lower(name) LIKE '%" + DataClass.FilterFields[0].ToLower() + "%' OR number LIKE '%" + DataClass.FilterFields[0].ToLower() + "%'";
            }
            try
            {
                sql.command.CommandText = "SELECT id, name, number, departID, caseID, date, isThisFileDel FROM Document WHERE isThisFileDel = '0' " + RoleQuery + " " + FilterQuery + " " + MainQuery + "  ";  //? какие еще поля нужны? TO DO lower(
                //MessageBox.Show(sql.command.CommandText);
                SQLiteDataReader read0 = sql.command.ExecuteReader();
                while (read0.Read())
                {
                    if (DataClass.Role == 0)
                    {
                        ListViewItem listViewItem = new ListViewItem(read0["name"].ToString()); //id, login, name, password, role, depart
                        listViewItem.SubItems.Add(read0["number"].ToString());
                        GetName getNameD = new GetName();
                        string nameD = getNameD.getName(Convert.ToInt32(read0["departID"]), "Department");
                        listViewItem.SubItems.Add(nameD);
                        GetName getNameC = new GetName();
                        string nameC = getNameC.getName(Convert.ToInt32(read0["caseID"]), "Case1");
                        listViewItem.SubItems.Add(nameC);
                        listViewItem.SubItems.Add(read0["date"].ToString());
                        Docs.Items.Add(listViewItem); //Добавляю запись в список найденных документов
                    }
                    else
                    {
                        if(Convert.ToInt32(read0["departID"]) == DataClass.DepartUserID && Convert.ToInt32(read0["isThisFileDel"]) == 0)
                        {
                            ListViewItem listViewItem = new ListViewItem(read0["name"].ToString()); //id, login, name, password, role, depart
                            listViewItem.SubItems.Add(read0["number"].ToString());
                            GetName getNameD = new GetName();
                            string nameD = getNameD.getName(Convert.ToInt32(read0["departID"]), "Department");
                            listViewItem.SubItems.Add(nameD);
                            GetName getNameC = new GetName();
                            string nameC = getNameC.getName(Convert.ToInt32(read0["caseID"]), "Case1");
                            listViewItem.SubItems.Add(nameC);
                            listViewItem.SubItems.Add(read0["date"].ToString());
                            Docs.Items.Add(listViewItem); //Добавляю запись в список найденных документов
                        }
                    }

                }
                read0.Close();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void pictureBackBtn_Click(object sender, EventArgs e)
        {
            DataClass.FilterFields[0] = QueryField.Text;
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataClass.FilterFields[0] = QueryField.Text;
            Docs.Items.Clear();
            LoadData();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Filters filters = new Filters();
            filters.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Docs.SelectedItems.Count != 0)
            {
                //MessageBox.Show(Docs.SelectedItems[0].SubItems[0].ToString());
                sql.command.CommandText = "SELECT id, caseID, departID FROM Document WHERE name LIKE '" + Docs.SelectedItems[0].SubItems[0].Text + "' ";
                SQLiteDataReader read5 = sql.command.ExecuteReader();
                while(read5.Read())
                {
                    DataClass.DocID = Convert.ToInt32(read5["id"]);
                    DataClass.CaseID = Convert.ToInt32(read5["caseID"]);
                    DataClass.DepartID = Convert.ToInt32(read5["departID"]);
                }
                read5.Close();
                DataClass.BackPage = "Search";
                DocForm docForm = new DocForm();
                docForm.Show();
                this.Hide();
            }
        }

        private void Search_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
    public class GetName
    {
        ConnectBD sql = new ConnectBD();
        public string getName(int id, string table)
        {
            string name = "";
            try
            {
                sql.command.CommandText = "SELECT name FROM " + table + " WHERE del = '0' AND id = '" + id + "' ";
                SQLiteDataReader read1 = sql.command.ExecuteReader();
                while (read1.Read())
                {
                    name = read1["name"].ToString();
                }
                read1.Close();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }

            return name;
        }
    }
}

