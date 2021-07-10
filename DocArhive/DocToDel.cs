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
    public partial class DocToDel : Form
    {
        ConnectBD sql = new ConnectBD();
        public DocToDel()
        {
            InitializeComponent();
        }
        private bool CountTerm(string delDate) //Вопрос: Пришло время удалять документ? True -да, False - нет.
        {
            string date = DateTime.Now.ToString();
            int Daytd = Convert.ToInt32(date.Substring(0, 2));
            date = DateTime.Now.ToString();
            int Mounthtd = Convert.ToInt32(date.Substring(3, 2));
            date = DateTime.Now.ToString();
            int Yeartd = Convert.ToInt32(date.Substring(6, 4));

            string delD = delDate;
            int Day = Convert.ToInt32(delDate.Substring(0, 2));
            delDate = delD;
            int Mounth = Convert.ToInt32(delDate.Substring(3, 2));ToString();
            delDate = delD;
            int Year = Convert.ToInt32(delDate.Substring(6, 4));

            //MessageBox.Show(Day.ToString() + " " + Mounth.ToString() + " " + Year.ToString() + " " + Daytd.ToString() + " " + Mounthtd.ToString() + " " + Yeartd.ToString());

            int res = Year - Yeartd;
            
            if(res>0)
            {
                return false;
            }
            if (res<0)
            {
                return true;
            }
            else
            {
                int res2 = Mounth - Mounthtd;
                if(res2>0)
                {
                    return false;
                }
                if (res2<0)
                {
                    return true;
                }
                else
                {
                    int res3 = Day - Daytd;
                    if (res3>0)
                    {
                        return false;
                    }
                    if (res3 < 0)
                    {
                        return true;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }
        private void DocToDel_Load(object sender, EventArgs e)
        {
            LoadDataToDel();
        }
        private void LoadDataToDel()
        {
            try
            {
                sql.command.CommandText = "SELECT id, deleteDate FROM Document WHERE isThisFileDel = '0'";
                SQLiteDataReader read0 = sql.command.ExecuteReader();
                int allSize = 0;
                while (read0.Read())
                {
                    bool res = CountTerm(read0["deleteDate"].ToString());
                    if (res)
                    {
                        allSize += 1;
                    }
                }
                read0.Close();

                /*int[] delID = new int[allSize];
                string[] delName = new string[allSize]; 
                string[] date = new string[allSize];
                string[] delDate = new string[allSize]; 
                int i = 0;*/
                sql.command.CommandText = "SELECT id, name, date, deleteDate  FROM Document WHERE isThisFileDel = '0'";
                SQLiteDataReader read1 = sql.command.ExecuteReader();
                while (read1.Read())
                {
                    bool res = CountTerm(read1["deleteDate"].ToString());
                    if (res)
                    {
                        ListViewItem listViewItem = new ListViewItem(read1["name"].ToString()); //name, date, deleteDate
                        listViewItem.SubItems.Add(read1["date"].ToString());
                        listViewItem.SubItems.Add(read1["deleteDate"].ToString());
                        DelDocs.Items.Add(listViewItem);
                        /*delID[i] = Convert.ToInt32(read1["id"]);
                        delName[i] = read1["name"].ToString();
                        date[i] = read1["date"].ToString();
                        delDate[i] = read1["deleteDate"].ToString();*/
                    }

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
            this.Hide();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string DToDel="";
            for (int i = 0; i < DelDocs.CheckedItems.Count; i++)
            {
                //int id = Convert.ToInt32(DelDocs.CheckedItems[i].Tag);

                /*sql.command.CommandText = "UPDATE Photos SET ifEx = '0' WHERE id = '" + id + "'  ";
                sql.command.ExecuteNonQuery();*/


                DToDel = DelDocs.CheckedItems[i].Text.ToString();

                DialogResult result = MessageBox.Show("Вы подтверждаете удаление документа " + DToDel + " ?", "Подтверждение удаления", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int id = 0;
                    bool Efile = false;
                    string file = "";
                    try
                    {
                        sql.command.CommandText = "SELECT id, file, extraFiles FROM Document WHERE name LIKE '" + DToDel + "'";
                        SQLiteDataReader read3 = sql.command.ExecuteReader();
                        while(read3.Read())
                        {
                            id = Convert.ToInt32(read3["id"]);
                            Efile = Convert.ToBoolean(read3["extraFiles"]);
                            file = Convert.ToString(read3["file"]);
                        }
                        read3.Close();
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show("Error:" + ex.Message);
                    }

                    if (System.IO.File.Exists(file))
                    {
                        System.IO.File.Delete(file);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка наличия файла!");
                    }

                    try
                    {
                        if (Efile)
                        {
                            sql.command.CommandText = "SELECT id, name FROM ExtraDoc WHERE DocID='" + id + "' ";
                            SQLiteDataReader read01 = sql.command.ExecuteReader();
                            while (read01.Read())
                            {
                                if (System.IO.File.Exists(read01["name"].ToString()))
                                {
                                    System.IO.File.Delete(read01["name"].ToString());
                                }
                                else
                                {
                                    MessageBox.Show("Ошибка наличия файла!");
                                }
                            }
                            read01.Close();
                            SQLHistory Sql = new SQLHistory(); //Сохранение изменений в историю
                            Sql.SqlRequest(sql.command.CommandText);
                        }

                        sql.command.CommandText = "UPDATE ExtraDoc SET name = '', docID = '', del = '1' WHERE DocID='" + id + "' ";
                        sql.command.ExecuteNonQuery();
                        SQLHistory SqlH = new SQLHistory(); //Сохранение изменений в историю
                        SqlH.SqlRequest(sql.command.CommandText);

                        sql.command.CommandText = "UPDATE Document SET name = '', number = '', majorID = '', caseID = '', departID = '', thom = '', thomPage = '',type = '', date = '', author = '', executors = '', dateOfExecution = '',phaseOfExecution = '',resolution = '',NNPages = '',physicalLocation = '',synopsis = '',file = '',savingTime = '', isThisFileDel = '1', deleteDate = '', extraFiles = '0' WHERE id ='" + id + "' ";
                        sql.command.ExecuteNonQuery();
                        SqlH.SqlRequest(sql.command.CommandText);

                       
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show("Error:" + ex.Message);
                    }
                }

            }
            MessageBox.Show("Удаление прошло успешно!");
            DelDocs.Items.Clear();
            LoadDataToDel();
        }
    }
}
