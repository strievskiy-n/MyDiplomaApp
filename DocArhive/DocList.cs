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
    public partial class DocList : Form
    {
        ConnectBD sql = new ConnectBD();
        public DocList()
        {
            InitializeComponent();
        }

        private void pictureBackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void DocList_Load(object sender, EventArgs e)
        {
            try
            {
                sql.command.CommandText = "SELECT number, name, date, savingTime, NNPages FROM Document WHERE departID = '" + DataClass.DepartID + "' AND caseID = '" + DataClass.CaseID + "' AND isThisFileDel = 0 ";
                SQLiteDataReader read = sql.command.ExecuteReader();
                while (read.Read())
                {
                    ListViewItem listViewItem = new ListViewItem(read["number"].ToString());
                    listViewItem.SubItems.Add(read["name"].ToString());
                    listViewItem.SubItems.Add(read["date"].ToString());
                    listViewItem.SubItems.Add(read["savingTime"].ToString());
                    listViewItem.SubItems.Add(read["NNPages"].ToString());
                    listView1.Items.Add(listViewItem);
                }
                read.Close();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}
