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
    public partial class DocForm : Form
    {
        ConnectBD sql = new ConnectBD();
        string DockNameD = ""; //XxxxXxxD -реализация передачи данных для сравнения данных из бд с данными в форме
        string NumberD = "";
        string NumberOfThomD = "";
        string DockTypeD = "";
        string DateOfDocD = "";
        string AuthorD = "";
        string ExecutorsD = "";
        string DateOfExecutionD = "";
        string PhaseOfExecutionD = "";
        string ResolutionD = "";
        string NNPagesD = "";
        string PhysicalLocationD = "";
        string SynopsisD = "";
        string FileD = "";
        int MajorID = 0;
        string MajorIDS = "";
        string CaseIDS = "";
        string SavingTimeS = "";
        string DeleteDateS = "";
        

        public DocForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataClass.CaseID = 0;
            DataClass.DepartID = 0;
            DataClass.DocID = 0;
            DataClass.BackPage = "";
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataClass.CaseID = 0;
            DataClass.DocID = 0;
            DataClass.BackPage = "";
            this.Hide();
            DepartmentForm departForm = new DepartmentForm();
            departForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataClass.DocID = 0;
            DataClass.BackPage = "";
            this.Hide();
            CaseForm caseForm = new CaseForm();
            caseForm.Show();
        }

        private void DocForm_Load(object sender, EventArgs e)
        {
            if(DataClass.Role == 0)
            {
                DelBut.Visible = true;
            }
            try
            {
                sql.command.CommandText = "SELECT * FROM Document WHERE id = '" + DataClass.DocID + "' ";
                SQLiteDataReader read0 = sql.command.ExecuteReader();
                while (read0.Read())
                {
                    DockName.Text = read0["name"].ToString();
                    label2.Text = read0["name"].ToString();
                    DockNameD = read0["name"].ToString();
                    Number.Text = read0["number"].ToString();
                    NumberD = read0["number"].ToString();
                    MajorID = Convert.ToInt32(read0["majorID"]);
                    NumberOfThom.Text = read0["thom"].ToString();
                    NumberOfThomD = read0["thom"].ToString();
                    DockType.Text = read0["type"].ToString();
                    DockTypeD = read0["type"].ToString();
                    DateOfDoc.Text = read0["date"].ToString();
                    DateOfDocD = read0["date"].ToString();
                    Author.Text = read0["author"].ToString();
                    AuthorD = read0["author"].ToString();
                    Executors.Text = read0["executors"].ToString();
                    ExecutorsD = read0["executors"].ToString();
                    DateOfExecution.Text = read0["dateOfExecution"].ToString();
                    DateOfExecutionD = read0["dateOfExecution"].ToString();
                    PhaseOfExecution.Text = read0["PhaseOfExecution"].ToString();
                    PhaseOfExecutionD = read0["PhaseOfExecution"].ToString();
                    Resolution.Text = read0["resolution"].ToString();
                    ResolutionD = read0["resolution"].ToString();
                    NNPages.Text = read0["NNPages"].ToString();
                    NNPagesD = read0["NNPages"].ToString();
                    PhysicalLocation.Text = read0["physicalLocation"].ToString();
                    PhysicalLocationD = read0["physicalLocation"].ToString();
                    Synopsis.Text = read0["synopsis"].ToString();
                    SynopsisD = read0["synopsis"].ToString();
                    FileD = read0["file"].ToString();
                    SavingTime.Text = read0["savingTime"].ToString();
                    SavingTimeS = read0["savingTime"].ToString();
                    DeleteDate.Text = read0["deleteDate"].ToString();
                    DeleteDateS = read0["deleteDate"].ToString();
                }
                read0.Close();

                sql.command.CommandText = "SELECT id, name FROM Users WHERE departID = '"+ DataClass.DepartID + "' AND del = '0' "; //вывод нынешнего и возможных ответственных в Combobox
                SQLiteDataReader read1 = sql.command.ExecuteReader();
                int i = 0; // Создаю счетчик для последующего вывода конкретного человека
                int m = -1;
                while (read1.Read())
                {
                    NameOfMajor.Items.Add(read1["name"].ToString());
                    if (MajorID == Convert.ToInt32(read1["id"]))
                    {
                        MajorIDS = read1["name"].ToString();
                        m = i;
                    }
                    i += 1;
                }
                read1.Close();
                if (m>=0)
                {
                    NameOfMajor.SelectedIndex = m;
                }

                sql.command.CommandText = "SELECT id, name FROM Case1 Where departID = '" + DataClass.DepartID + "' AND del = '0'"; // Вывод названия нынешнего дела и возможных других дел из этого депортамента
                SQLiteDataReader read2 = sql.command.ExecuteReader();
                i = 0;
                while (read2.Read())
                {
                    NameOfCase.Items.Add(read2["name"].ToString());
                    if (DataClass.CaseID == Convert.ToInt32(read2["id"]))
                    {
                        m = i;
                        CaseIDS = read2["name"].ToString();
                    }
                    i += 1;
                }
                read2.Close();
                NameOfCase.SelectedIndex = m;

                sql.command.CommandText = "SELECT name FROM Department WHERE id ='" + DataClass.DepartID + "' AND del = '0'"; //вывод нынешнего имени депортамента
                SQLiteDataReader read3 = sql.command.ExecuteReader();
                while (read3.Read())
                {
                    NameOfDep.Text = read3["name"].ToString();
                }
                read3.Close();
                NameOfDep.Enabled = false;
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        private void ButtonOnClick(object sender, EventArgs eventArgs)
        {
            var button = (Button)sender;
            if (button != null)
            {
                if (button.Name == "ListFileBtn") //Если нажата кнопка "СПИСОК ФАЙЛОВ"
                {
                    FileList fileList = new FileList();
                    fileList.Show();
                }
            }
        }
        private void ChangeDataButton_Click(object sender, EventArgs e)
        {
            if (DockName.Text == "" || Number.Text == "" ||  NumberOfThom.Text == "" || NameOfMajor.SelectedItem == null || NameOfCase.SelectedItem == null || DockType.Text == "" || DateOfDoc.Text == "" || PhysicalLocation.Text == "" || DeleteDate.Text == "")
            {
                MessageBox.Show("Заполнены не все обязательные поля!");
            }
            else
            {
                bool a = Convert.ToBoolean(String.Compare(MajorIDS, NameOfMajor.SelectedItem.ToString()));
                bool b = Convert.ToBoolean(String.Compare(CaseIDS, NameOfCase.SelectedItem.ToString()));
                if (DockName.Text != DockNameD ||
                        Number.Text != NumberD ||
                        MajorIDS != NameOfCase.SelectedItem.ToString() ||
                        a || b ||
                        NumberOfThom.Text != NumberOfThomD ||
                        DockType.Text != DockTypeD ||
                        DateOfDoc.Text != DateOfDocD ||
                        Author.Text != AuthorD ||
                        Executors.Text != ExecutorsD ||
                        DateOfExecution.Text != DateOfExecutionD ||
                        PhaseOfExecution.Text != PhaseOfExecutionD ||
                        Resolution.Text != ResolutionD ||
                        NNPages.Text != NNPagesD ||
                        PhysicalLocation.Text != PhysicalLocationD ||
                        Synopsis.Text != SynopsisD ||
                        //File.Text != FileD ||
                        SavingTime.Text != SavingTimeS ||
                        DeleteDate.Text != DeleteDateS)
                {
                    try
                    {
                        sql.command.CommandText = "SELECT id FROM Users Where name LIKE '" + NameOfMajor.SelectedItem + "' AND del = '0'";
                        SQLiteDataReader read0 = sql.command.ExecuteReader();
                        int mID = 0;
                        while (read0.Read())
                        {
                            mID = Convert.ToInt32(read0["id"]);
                        }
                        read0.Close();

                        sql.command.CommandText = "SELECT id FROM Case1 Where name LIKE '" + NameOfCase.SelectedItem + "' AND del = '0'";
                        SQLiteDataReader read1 = sql.command.ExecuteReader();
                        int cID = 0;
                        while (read1.Read())
                        {
                            cID = Convert.ToInt32(read1["id"]);
                        }
                        read1.Close();

                        sql.command.CommandText = "UPDATE Document SET name = '" + DockName.Text.ToLower()
                            + "', number = '" + Number.Text.ToLower() +
                            "', majorID = '" + mID +
                            "', caseID = '" + cID +
                            "', thom = '" + NumberOfThom.Text.ToLower() +
                            "', type = '" + DockType.Text.ToLower() +
                            "', date = '" + DateOfDoc.Text.ToLower() +
                            "', author = '" + Author.Text.ToLower() +
                            "', executors = '" + Executors.Text.ToLower() +
                            "', dateOfExecution = '" + DateOfExecution.Text.ToLower() +
                            "', PhaseOfExecution = '" + PhaseOfExecution.Text.ToLower() +
                            "', resolution = '" + Resolution.Text.ToLower() +
                            "', NNPages = '" + NNPages.Text.ToLower() +
                            "', physicalLocation = '" + PhysicalLocation.Text.ToLower() +
                            "', synopsis = '" + Synopsis.Text.ToLower() +
                            //"', file = '" + File.Text.ToLower() +
                            "', savingTime = '" + SavingTime.Text.ToLower() +
                            "', deleteDate = '" + DeleteDate.Text.ToLower() + "' WHERE id = '" + DataClass.DocID + "' ";
                        sql.command.ExecuteNonQuery();
                        SQLHistory SqlH = new SQLHistory();
                        SqlH.SqlRequest(sql.command.CommandText); //Сохранение изменений в историю 
                        MessageBox.Show("Данные успешно изменены!");

                        if (b) // Если изменено дело документа, то нас перебрасывает в это дело 
                        {
                            DataClass.CaseID = cID;
                            DataClass.DocID = 0;
                            this.Hide();
                            CaseForm caseForm = new CaseForm();
                            caseForm.Show();
                        }
                        else
                        {
                            DataClass.DocID = 0;
                            CaseForm caseForm = new CaseForm();
                            this.Hide();
                            caseForm.Show();
                        }
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show("Error:" + ex.Message);
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void DockName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Number_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void NumberOfThom_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Author_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void DateOfDoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void DockType_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void PageOfThome_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void PhaseOfExecution_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void File_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void Synopsis_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void PhysicalLocation_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void Resolution_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void NNPages_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void DateOfExecution_TextChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void Executors_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void NameOfMajor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NameOfDep_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NameOfCase_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы подтверждаете удаление документа " + DockName.Text + " ?", "Подтверждение удаления", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (System.IO.File.Exists(FileD))
                {
                    System.IO.File.Delete(FileD);
                }
                else
                {
                    MessageBox.Show("Ошибка наличия файла!");
                }

                try
                {
                    sql.command.CommandText = "SELECT id, name FROM ExtraDoc WHERE DocID='" + DataClass.DocID + "' ";
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
                    SQLHistory SqlH = new SQLHistory(); //Сохранение изменений в историю
                    SqlH.SqlRequest(sql.command.CommandText);

                    sql.command.CommandText = "UPDATE ExtraDoc SET name = '', docID = '', del = '1' WHERE DocID='" + DataClass.DocID + "' ";
                    sql.command.ExecuteNonQuery();
                    SqlH.SqlRequest(sql.command.CommandText);

                    sql.command.CommandText = "UPDATE Document SET name = '', number = '', majorID = '', caseID = '', departID = '', thom = '', thomPage = '',type = '', date = '', author = '', executors = '', dateOfExecution = '',phaseOfExecution = '',resolution = '',NNPages = '',physicalLocation = '',synopsis = '',file = '',savingTime = '', isThisFileDel = '1', deleteDate = '', extraFiles = '0' WHERE id ='" + DataClass.DocID + "' ";
                    sql.command.ExecuteNonQuery();
                    SqlH.SqlRequest(sql.command.CommandText);

                    DataClass.DocID = 0;
                    this.Hide();
                    CaseForm caseForm = new CaseForm();
                    caseForm.Show();
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                }
            }
        }

        private void pictureBackBtn_Click(object sender, EventArgs e) //кнопка назад
        {
            if (DataClass.BackPage == "")
            {
                DataClass.DocID = 0;
                this.Hide();
                CaseForm caseForm = new CaseForm();
                caseForm.Show();
            }
            if (DataClass.BackPage != "")
            {
                DataClass.DocID = 0;
                DataClass.CaseID = 0;
                DataClass.DepartID = 0;
                DataClass.BackPage = "";
                Search search = new Search();
                search.Show();
                this.Hide();
            }
        }

        private void DocForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void AddFile_Click(object sender, EventArgs e)
        {
            
        }

        private void fileName_Click(object sender, EventArgs e)
        {
            FileList fileList = new FileList();
            fileList.Show();
        }
    }
}
