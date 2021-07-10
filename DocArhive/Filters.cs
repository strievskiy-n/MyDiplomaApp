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
    public partial class Filters : Form
    {
        string SNumber = "";
        string SMajor = "";
        string SCase = "";
        string SDep = "";
        string SThomnum = "";
        string SDoktype = "";
        string SDate = "";
        string SAuthor = "", SExecutors = "", SSvingTime = "", SDeletedate = "", SDateofexecution = "", SPhaseofexecution = "", SResolution = "", SNNPages = "", SPhisicallocation = "", SSynopsis = "";

        private void button1_Click(object sender, EventArgs e)
        {
            if (Number.Text == "" && NameOfMajor.SelectedItem == null && NameOfCase.SelectedItem == null && NameOfDep.SelectedItem == null && NumberOfThom.Text == "" && DockType.Text == "" && DateOfDoc.Text == "" && Author.Text == "" && Executors.Text == "" && DateOfExecution.Text == "" && PhaseOfExecution.Text == "" && Resolution.Text == "" && NNPages.Text == "" && PhysicalLocation.Text == "" && Synopsis.Text == "" && SavingTime.Text == "" && DeleteDate.Text == "")
            {
                MessageBox.Show("Введите поисковые данные!");
            }
            else
            {
                if (Number.Text != SNumber) //номер
                {
                    DataClass.FilterFields[1] = Number.Text;
                    DataClass.CheckFlag(1);
                }
                if (NameOfMajor.SelectedItem != null) //ответственный
                {
                    if (NameOfMajor.SelectedItem.ToString() != SMajor) 
                    {
                        DataClass.FilterFields[2] = NameOfMajor.SelectedItem.ToString();
                        DataClass.CheckFlag(2);
                    }
                }
                if (NameOfCase.SelectedItem != null) //дело
                {
                    if(NameOfCase.SelectedItem.ToString() != SCase)
                    {
                        DataClass.FilterFields[3] = NameOfCase.SelectedItem.ToString();
                        DataClass.CheckFlag(3);
                    }
                }
                if (DataClass.Role == 0) //департамент
                {
                    if (NameOfDep.SelectedItem != null)
                    {
                        if (NameOfDep.SelectedItem.ToString() != SDep)
                            {
                            DataClass.FilterFields[4] = NameOfDep.SelectedItem.ToString();
                            DataClass.CheckFlag(4);
                        }
                    }
                }
                if(NumberOfThom.Text != SThomnum) //номер тоиа
                {
                    DataClass.FilterFields[5] = NumberOfThom.Text;
                    DataClass.CheckFlag(5);
                }
                if (DockType.Text != SDoktype)// тип документа
                {
                    DataClass.FilterFields[6] = DockType.Text;
                    DataClass.CheckFlag(6);
                }
                if (DateOfDoc.Text != SDate) // дата
                {
                    DataClass.FilterFields[7] = DateOfDoc.Text;
                    DataClass.CheckFlag(7);
                }
                if (Author.Text != SAuthor) //автор
                {
                    DataClass.FilterFields[8] = Author.Text;
                    DataClass.CheckFlag(8);
                }
                if (Executors.Text != SExecutors) //исполнители
                {
                    DataClass.FilterFields[9] = Executors.Text;
                    DataClass.CheckFlag(9);
                }
                if (SavingTime.Text != SSvingTime) //срок хранения
                {
                    DataClass.FilterFields[10] = SavingTime.Text;
                    DataClass.CheckFlag(10);
                }
                if (DeleteDate.Text != SDeletedate) //дата утилизации
                {
                    DataClass.FilterFields[11] = DeleteDate.Text;
                    DataClass.CheckFlag(11);
                }
                if (DateOfExecution.Text != SDateofexecution) //дата исполнения
                {
                    DataClass.FilterFields[12] = DateOfExecution.Text;
                    DataClass.CheckFlag(12);
                }
                if (PhaseOfExecution.Text != SPhaseofexecution) //что сделано
                {
                    DataClass.FilterFields[13] = PhaseOfExecution.Text;
                    DataClass.CheckFlag(13);
                }
                if (Resolution.Text != SResolution) //резолюции
                {
                    DataClass.FilterFields[14] = Resolution.Text;
                    DataClass.CheckFlag(14);
                }
                if (NNPages.Text != SNNPages) //NN сраниц
                {
                    DataClass.FilterFields[15] = NNPages.Text;
                    DataClass.CheckFlag(15);
                }
                if (PhysicalLocation.Text != SPhisicallocation) //Физическое местоположение
                {
                    DataClass.FilterFields[16] = PhysicalLocation.Text;
                    DataClass.CheckFlag(16);
                }
                if (Synopsis.Text != SSynopsis) //Физическое местоположение
                {
                    DataClass.FilterFields[17] = Synopsis.Text;
                    DataClass.CheckFlag(17);
                }
                this.Hide();
            }
        }

        ConnectBD sql = new ConnectBD();
        public Filters()
        {
            InitializeComponent();
        }

        private void Filters_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            //загружаем данные, если они есть
            Number.Text = SNumber = DataClass.FilterFields[1];

            if (DataClass.Role == 0)//ответственный
            {
                try
                {
                    NameOfMajor.Items.Clear();
                    sql.command.CommandText = "SELECT name FROM Users WHERE  del = '0' "; //вывод нынешнего и возможных ответственных в Combobox
                    SQLiteDataReader read8 = sql.command.ExecuteReader();
                    int i = 0; // Создаю счетчик для последующего вывода конкретного человека
                    int m = -1;
                    while (read8.Read())
                    {
                        NameOfMajor.Items.Add(read8["name"].ToString());
                        if (DataClass.FilterFields[2] == read8["name"].ToString())
                        {
                            SMajor = read8["name"].ToString();
                            m = i;
                        }
                        i += 1;
                    }
                    read8.Close();
                    if (m >= 0)
                    {
                        NameOfMajor.SelectedIndex = m;
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                }
            }
            else
            {
                try
                {
                    NameOfMajor.Items.Clear();
                    sql.command.CommandText = "SELECT name FROM Users WHERE departID = '" + DataClass.DepartUserID + "' AND  del = '0' "; //вывод нынешнего и возможных ответственных в Combobox
                    SQLiteDataReader read8 = sql.command.ExecuteReader();
                    int i = 0; // Создаю счетчик для последующего вывода конкретного человека
                    int m = -1;
                    while (read8.Read())
                    {
                        NameOfMajor.Items.Add(read8["name"].ToString());
                        if (DataClass.FilterFields[2] == read8["name"].ToString())
                        {
                            SMajor = read8["name"].ToString();
                            m = i;
                        }
                        i += 1;
                    }
                    read8.Close();
                    if (m >= 0)
                    {
                        NameOfMajor.SelectedIndex = m;
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                }
            }

            NameOfCase.Items.Clear();
            if (DataClass.Role == 0) //дело
            {
                try
                {
                    sql.command.CommandText = "SELECT name FROM Case1 WHERE del = '0' ";
                    SQLiteDataReader read1 = sql.command.ExecuteReader();
                    int i = 0; // Создаю счетчик для последующего вывода конкретного человека
                    int m = -1;
                    while (read1.Read())
                    {
                        NameOfCase.Items.Add(read1["name"].ToString());
                        if (DataClass.FilterFields[3] == read1["name"].ToString())
                        {
                            SCase = read1["name"].ToString();
                            m = i;
                        }
                        i += 1;
                    }
                    read1.Close();
                    if (m >= 0)
                    {
                        NameOfCase.SelectedIndex = m;
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                }
            }
            else
            {
                try
                {
                    sql.command.CommandText = "SELECT name FROM Case1 WHERE del = '0' AND  departID = '" + DataClass.DepartUserID + "' ";
                    SQLiteDataReader read1 = sql.command.ExecuteReader();
                    int i = 0; // Создаю счетчик для последующего вывода конкретного человека
                    int m = -1;
                    while (read1.Read())
                    {
                        NameOfCase.Items.Add(read1["name"].ToString());
                        if (DataClass.FilterFields[3] == read1["name"].ToString())
                        {
                            SCase = read1["name"].ToString();
                            m = i;
                        }
                        i += 1;
                    }
                    read1.Close();
                    if (m >= 0)
                    {
                        NameOfCase.SelectedIndex = m;
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                }
            }

            NameOfDep.Items.Clear();
            if (DataClass.Role == 0) //отдел
            {
                try
                {
                    sql.command.CommandText = "SELECT name FROM Department WHERE del = '0' ";
                    SQLiteDataReader read2 = sql.command.ExecuteReader();
                    int i = 0; // Создаю счетчик для последующего вывода конкретного человека
                    int m = -1;
                    while (read2.Read())
                    {
                        NameOfDep.Items.Add(read2["name"].ToString());
                        if (DataClass.FilterFields[4] == read2["name"].ToString())
                        {
                            SDep = read2["name"].ToString();
                            m = i;
                        }
                        i += 1;
                    }
                    read2.Close();
                    if (m >= 0)
                    {
                        NameOfDep.SelectedIndex = m;
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                }
            }
            else
            {
                try
                {
                    sql.command.CommandText = "SELECT name FROM Department WHERE id = '" + DataClass.DepartUserID + "' ";
                    SQLiteDataReader read2 = sql.command.ExecuteReader();
                    while (read2.Read())
                    {
                        NameOfDep.Items.Add(read2["name"].ToString());
                    }
                    read2.Close();
                    NameOfDep.SelectedIndex = 0;
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                }
            }
            NumberOfThom.Text = SThomnum = DataClass.FilterFields[5];//номер тома

            DockType.Text = SDoktype = DataClass.FilterFields[6];//тип документа

            DateOfDoc.Text = SDate = DataClass.FilterFields[7]; //дата

            Author.Text = SAuthor = DataClass.FilterFields[8]; //автор

            Executors.Text = SExecutors = DataClass.FilterFields[9]; //исполнители
            
            SavingTime.Text = SSvingTime = DataClass.FilterFields[10];//срок хранения
            
            DeleteDate.Text = SDeletedate = DataClass.FilterFields[11]; //дата утилизации
            
            DateOfExecution.Text = SDateofexecution = DataClass.FilterFields[12];//дата исполнения

            PhaseOfExecution.Text = SPhaseofexecution = DataClass.FilterFields[13];//что сделано

            Resolution.Text = SResolution = DataClass.FilterFields[14];//резолюции

            NNPages.Text = SNNPages = DataClass.FilterFields[15];//NN сраниц

            PhysicalLocation.Text = SPhisicallocation = DataClass.FilterFields[16];//Физическое местоположение

            Synopsis.Text = SSynopsis = DataClass.FilterFields[17]; //Краткое содержание
            

            string SpecialQuery = " ";
            if (DataClass.Role != 0)
            {
                SpecialQuery = "AND departID ='" + DataClass.DepartUserID + "' ";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ChangeDataButton_Click(object sender, EventArgs e)
        {
            DataClass.KillFilters();//Удалили фильтры
            LoadData();
            NameOfMajor.SelectedItem = null; 
            NameOfCase.SelectedItem = null;
            NameOfDep.SelectedItem = null;
        }
    }
}
