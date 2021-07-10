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
    public partial class FileList : Form
    {
        bool ExtraFile = false;
        string FilePath1 = "";
        string FileName1 = "";
        string[] ExtraDoc = new string[9] { "", "", "", "", "", "", "", "", "" }; //массив для сохранения имен дополнительных файлов
        int[] ExtraDocID = new int[9] { 0 , 0, 0, 0, 0, 0, 0, 0, 0 }; //массив для ID дополнительных документов
        ConnectBD sql = new ConnectBD();
        public FileList()
        {
            InitializeComponent();
        }

        private void pictureBackBtn_Click(object sender, EventArgs e)
        {
            try
            {
                sql.command.CommandText = "SELECT file FROM Document WHERE id = '"+ DataClass.DocID +"' ";
                SQLiteDataReader read = sql.command.ExecuteReader();
                string file = "";
                while (read.Read())
                {
                    file = read["file"].ToString();
                }
                read.Close();
                if ( file == "" )
                {
                    MessageBox.Show("Не загружен ни один файл!");
                }
                else
                {
                    this.Hide();
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
            
        }

        private void FileList_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void AddButnCreate(int left, int top)
        {
            Button buttonToAdd = new Button(); //Создаем кнопку для добавления департамента
            buttonToAdd.Left = left;
            buttonToAdd.Top = top ;
            buttonToAdd.Name = "AddButton"; //add
            buttonToAdd.Click += ButtonOnClick;
            buttonToAdd.Text = "+";
            buttonToAdd.Height = 29;
            buttonToAdd.Width = 424;
            buttonToAdd.Font = new System.Drawing.Font("Century Gothic", 13, FontStyle.Bold);  //Franklin Gothic Medium
            buttonToAdd.FlatStyle = FlatStyle.Flat;
            buttonToAdd.ForeColor = Color.White;
            buttonToAdd.BackColor = Color.FromArgb(44, 146, 213);
            buttonToAdd.FlatAppearance.BorderColor = Color.FromArgb(44, 146, 213);
            this.Controls.Add(buttonToAdd);
        }
        private string PrintStartupPath()
        {
            string Path = Application.StartupPath;//нужно убрать 20 символов
            Path = Path.Remove(Path.LastIndexOf(@"DocArhive\bin"));
            string add = "Doc";
            Path = Path + add;
            //MessageBox.Show(Path);
            return Path;
        }
            private void ButtonOnClick(object sender, EventArgs eventArgs)
        {
            var button = (Button)sender;
            if (fileName1.Visible )//Добавляем файлы в ExtraDoc
            {
                string newLocation = "";
                string folderLocation = PrintStartupPath();
                var OFD = new System.Windows.Forms.OpenFileDialog();
                if (OFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string fileToCopy = OFD.FileName;
                    if (System.IO.File.Exists(fileToCopy))
                    {
                        var onlyFileName = System.IO.Path.GetFileName(OFD.FileName);
                        newLocation = folderLocation + @"\" + onlyFileName;
                        System.IO.File.Copy(fileToCopy, newLocation, true);
                        try
                        {
                            sql.command.CommandText = "INSERT INTO ExtraDoc (docID, name) VALUES('" + DataClass.DocID + "', '"+ 
                                newLocation + "')";
                            sql.command.ExecuteNonQuery();
                            SQLHistory SqlH = new SQLHistory(); //Сохранение изменений в историю
                            SqlH.SqlRequest(sql.command.CommandText);

                            sql.command.CommandText = "UPDATE Document SET extraFiles = '1' WHERE id = '" + DataClass.DocID + "' ";
                            sql.command.ExecuteNonQuery();
                            SqlH.SqlRequest(sql.command.CommandText);
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Error:" + ex.Message);
                        }
                        MessageBox.Show("Файл успешно добавлен!");
                    }
                    else
                    {
                        MessageBox.Show("Такого файла нет!");
                    }
                }
                else
                {
                    MessageBox.Show("Такой папки нет!");
                }

            }
            else //Добавляем файл в Documents
            {
                string newLocation = "";
                string folderLocation = PrintStartupPath();
                var OFD = new System.Windows.Forms.OpenFileDialog();
                if (OFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string fileToCopy = OFD.FileName;
                    if (System.IO.File.Exists(fileToCopy))
                    {
                        var onlyFileName = System.IO.Path.GetFileName(OFD.FileName);
                        newLocation = folderLocation + @"\" + onlyFileName;
                        System.IO.File.Copy(fileToCopy, newLocation, true);
                        try
                        {
                            sql.command.CommandText = "UPDATE Document SET file = '" + newLocation + "' WHERE id = '" + DataClass.DocID + "' ";
                            sql.command.ExecuteNonQuery();
                            SQLHistory SqlH = new SQLHistory(); //Сохранение изменений в историю
                            SqlH.SqlRequest(sql.command.CommandText);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error:" + ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Такого файла нет!");
                    }
                }
                else
                {
                    MessageBox.Show("Такой папки нет!");
                }
            }
            LoadData();
        }
        private void LoadData()
        {
            int y = 0;
            while(y<9)
            {
                ExtraDoc[y] = "";
                ExtraDocID[y] = 0;
                y += 1;
            }
            try
            {
                sql.command.CommandText = "SELECT name, file, extraFiles FROM Document WHERE id ='"+ DataClass.DocID + "' ";
                SQLiteDataReader read0 = sql.command.ExecuteReader();
                while(read0.Read())
                {
                    label2.Text = read0["name"].ToString();
                    FilePath1 = read0["file"].ToString();
                    FileName1 = Path.GetFileName(FilePath1);
                    fileName1.Text = FileName1;
                    ExtraFile = Convert.ToBoolean(read0["extraFiles"]);
                }
                read0.Close();
                int flg = 0;
                if(fileName1.Text =="")
                {
                    fileName1.Visible = false;
                    ToDel1.Visible = false;
                    ToSee1.Visible = false;
                    ToLoad1.Visible = false;
                    AddButnCreate(fileName1.Left, fileName1.Top);
                    flg = 1;
                }
                bool AddBtnFlag = true;
                if(ExtraFile)
                {
                    sql.command.CommandText = "SELECT * FROM ExtraDoc WHERE docID ='"+ DataClass.DocID +"' AND del = '0' ";
                    SQLiteDataReader read1 = sql.command.ExecuteReader();
                    int i = 0;
                    while(read1.Read())
                    {
                        ExtraDoc[i] = read1["name"].ToString();
                        ExtraDocID[i] = Convert.ToInt32(read1["id"]);
                        i += 1;
                    }
                    read1.Close();
                    if (ExtraDoc[0] != "") //2
                    {
                        fileName2.Visible = true;
                        ToDel2.Visible = true;
                        ToSee2.Visible = true;
                        ToLoad2.Visible = true;
                        fileName2.Text = Path.GetFileName(ExtraDoc[0]);

                        if (ExtraDoc[1] != "")//3
                        {
                            fileName3.Visible = true;
                            ToDel3.Visible = true;
                            ToSee3.Visible = true;
                            ToLoad3.Visible = true;
                            fileName3.Text = Path.GetFileName(ExtraDoc[1]);

                            if (ExtraDoc[2] != "")//4
                            {
                                fileName4.Visible = true;
                                ToDel4.Visible = true;
                                ToSee4.Visible = true;
                                ToLoad4.Visible = true;
                                fileName4.Text = Path.GetFileName(ExtraDoc[2]);

                                if (ExtraDoc[3] != "")//5
                                {
                                    fileName5.Visible = true;
                                    ToDel5.Visible = true;
                                    ToSee5.Visible = true;
                                    ToLoad5.Visible = true;
                                    fileName5.Text = Path.GetFileName(ExtraDoc[3]);

                                    if (ExtraDoc[4] != "")//6
                                    {
                                        fileName6.Visible = true;
                                        ToDel6.Visible = true;
                                        ToSee6.Visible = true;
                                        ToLoad6.Visible = true;
                                        fileName6.Text = Path.GetFileName(ExtraDoc[4]);

                                        if (ExtraDoc[5] != "")//7
                                        {
                                            fileName7.Visible = true;
                                            ToDel7.Visible = true;
                                            ToSee7.Visible = true;
                                            ToLoad7.Visible = true;
                                            fileName7.Text = Path.GetFileName(ExtraDoc[5]);

                                            if (ExtraDoc[6] != "")//8
                                            {
                                                fileName8.Visible = true;
                                                ToDel8.Visible = true;
                                                ToSee8.Visible = true;
                                                ToLoad8.Visible = true;
                                                fileName8.Text = Path.GetFileName(ExtraDoc[6]);

                                                if (ExtraDoc[7] != "")//9
                                                {
                                                    fileName9.Visible = true;
                                                    ToDel9.Visible = true;
                                                    ToSee9.Visible = true;
                                                    ToLoad9.Visible = true;
                                                    fileName9.Text = Path.GetFileName(ExtraDoc[7]);

                                                    if (ExtraDoc[8] != "")//10
                                                    {
                                                        fileName10.Visible = true;
                                                        ToDel10.Visible = true;
                                                        ToSee10.Visible = true;
                                                        ToLoad10.Visible = true;
                                                        fileName10.Text = Path.GetFileName(ExtraDoc[8]);
                                                    }
                                                    else
                                                    {
                                                        fileName10.Visible = false;
                                                        ToDel10.Visible = false;
                                                        ToSee10.Visible = false;
                                                        ToLoad10.Visible = false;
                                                        if (AddBtnFlag)
                                                        {
                                                            AddButnCreate(fileName10.Left, fileName10.Top);
                                                            AddBtnFlag = false;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    fileName9.Visible = false;
                                                    ToDel9.Visible = false;
                                                    ToSee9.Visible = false;
                                                    ToLoad9.Visible = false;
                                                    if (AddBtnFlag)
                                                    {
                                                        AddButnCreate(fileName9.Left, fileName9.Top);
                                                        AddBtnFlag = false;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                fileName8.Visible = false;
                                                ToDel8.Visible = false;
                                                ToSee8.Visible = false;
                                                ToLoad8.Visible = false;
                                                if (AddBtnFlag)
                                                {
                                                    AddButnCreate(fileName8.Left, fileName8.Top);
                                                    AddBtnFlag = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            fileName7.Visible = false;
                                            ToDel7.Visible = false;
                                            ToSee7.Visible = false;
                                            ToLoad7.Visible = false;
                                            if (AddBtnFlag)
                                            {
                                                AddButnCreate(fileName7.Left, fileName7.Top);
                                                AddBtnFlag = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        fileName6.Visible = false;
                                        ToDel6.Visible = false;
                                        ToSee6.Visible = false;
                                        ToLoad6.Visible = false;
                                        if (AddBtnFlag)
                                        {
                                            AddButnCreate(fileName6.Left, fileName6.Top);
                                            AddBtnFlag = false;
                                        }
                                    }
                                }
                                else
                                {
                                    fileName5.Visible = false;
                                    ToDel5.Visible = false;
                                    ToSee5.Visible = false;
                                    ToLoad5.Visible = false;
                                    if (AddBtnFlag)
                                    {
                                        AddButnCreate(fileName5.Left, fileName5.Top);
                                        AddBtnFlag = false;
                                    }
                                }
                            }
                            else
                            {
                                fileName4.Visible = false;
                                ToDel4.Visible = false;
                                ToSee4.Visible = false;
                                ToLoad4.Visible = false;
                                if (AddBtnFlag)
                                {
                                    AddButnCreate(fileName4.Left, fileName4.Top);
                                    AddBtnFlag = false;
                                }
                            }
                        }
                        else
                        {
                            fileName3.Visible = false;
                            ToDel3.Visible = false;
                            ToSee3.Visible = false;
                            ToLoad3.Visible = false;
                            if (AddBtnFlag)
                            {
                                AddButnCreate(fileName3.Left, fileName3.Top);
                                AddBtnFlag = false;
                            }
                        }
                    }
                    else
                    {
                        fileName2.Visible = false;
                        ToDel2.Visible = false;
                        ToSee2.Visible = false;
                        ToLoad2.Visible = false;
                        /*AddButnCreate(fileName2.Left, fileName2.Top);
                        AddBtnFlag = false;*/
                    }

                }
                else
                {
                    fileName2.Visible = false;
                    ToDel2.Visible = false;
                    ToSee2.Visible = false;
                    ToLoad2.Visible = false;
                    if (flg == 0)
                    {
                        AddButnCreate(fileName2.Left, fileName2.Top);
                        AddBtnFlag = false;
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void ToSee1_Click(object sender, EventArgs e)
        {
            //Stream logtxt = new FileStream(FilePath1, FileMode.Open);
            //using ( var stream = new FileStream(FilePath1, FileMode.Open, FileAccess.Read));
            //FileStream fa = new FileStream(@FilePath1, FileMode.Open, FileAccess.Read);
            See(@FilePath1);
        }
        private void See(string path)
        {
            try
            {
                System.Diagnostics.Process.Start(path);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
            catch (Win32Exception exe)
            {
                MessageBox.Show("Error:" + exe.Message);
            }
        }

        private void ToSee2_Click(object sender, EventArgs e)
        {
            See(ExtraDoc[0]);
        }

        private void ToDel1_Click(object sender, EventArgs e) //не работает извлечение адреса из экстра в докс при удалении основной записи
        {
            if (fileName1.Text == "")
            {
                MessageBox.Show("Файл для удаления не найден!");
            }
            else
            {
                DialogResult result = MessageBox.Show("Вы подтверждаете удаление файла " + FileName1 + " ?", "Подтверждение удаления", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try 
                    {
                        //удаление путя из бд
                        sql.command.CommandText = " UPDATE Document SET file = '', extraFiles = '0' WHERE id = '" + DataClass.DocID + "' ";
                        sql.command.ExecuteNonQuery();
                        SQLHistory SqlH = new SQLHistory(); //Сохранение изменений в историю
                        SqlH.SqlRequest(sql.command.CommandText);
                        MessageBox.Show("Файл '" + FileName1 + "' успешно удален!");

                        int q = 0;
                        while (q < 9)
                        {
                            if (ExtraDoc[q] != "")
                            {
                                sql.command.CommandText = "UPDATE Document SET file = '" + ExtraDoc[q] + "' WHERE id = '" + DataClass.DocID + "' ";
                                sql.command.ExecuteNonQuery();
                                SqlH.SqlRequest(sql.command.CommandText); //история

                                sql.command.CommandText = "UPDATE ExtraDoc SET docID = '', name = '', del = '1' WHERE id = '" + ExtraDocID[q] + "' ";
                                sql.command.ExecuteNonQuery();
                                SqlH.SqlRequest(sql.command.CommandText);//история
                                q = 9;
                            }
                            q += 1;
                        }
                        
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show("Error:" + ex.Message);
                    }
                    //непосредственно удаление файла
                    //System.Diagnostics.Process.Start(@FilePath1);
                    File.Delete(@FilePath1);
                    FileList fileList = new FileList();//костыль
                    this.Hide();
                    fileList.Show();
                }
                LoadData();
            }
        }
        private void FileDel(string PathToDel, int id) //TO DO 
        {
            try
            {
                sql.command.CommandText = "UPDATE ExtraDoc SET name = '', docID = '', del = '1' WHERE id = '" + id + "' ";
                sql.command.ExecuteNonQuery();
                SQLHistory SqlH = new SQLHistory(); //Сохранение изменений в историю
                SqlH.SqlRequest(sql.command.CommandText);
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }

            MessageBox.Show("Файл '" + Path.GetFileName(PathToDel) + "' успешно удален!");
            File.Delete(PathToDel);
            LoadData();
            /*this.Controls.Add(buttonToAdd);
            this.Controls.Remove(this.)
            this.Controls.Remove((buttonToAdd)sender);
            AddButton.Visible = false;*/ 
            FileList fileList = new FileList();//костыль
            this.Hide();
            fileList.Show();
        }

        private void ToDel2_Click(object sender, EventArgs e)
        {
            FileDel(ExtraDoc[0], ExtraDocID[0]);
            if (ExtraDoc[1]=="")
            {
                try
                {
                    sql.command.CommandText = "UPDATE Document SET extraFiles = '0' WHERE id = '" + DataClass.DocID + "' ";
                    sql.command.ExecuteNonQuery();
                    SQLHistory SqlH = new SQLHistory(); //Сохранение изменений в историю
                    SqlH.SqlRequest(sql.command.CommandText);
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                }
            }
        }

        private void ToDel3_Click(object sender, EventArgs e)
        {
            FileDel(ExtraDoc[1], ExtraDocID[1]);
        }

        private void ToDel4_Click(object sender, EventArgs e)
        {
            FileDel(ExtraDoc[2], ExtraDocID[2]);
        }

        private void ToDel5_Click(object sender, EventArgs e)
        {
            FileDel(ExtraDoc[3], ExtraDocID[3]);
        }

        private void ToDel6_Click(object sender, EventArgs e)
        {
            FileDel(ExtraDoc[4], ExtraDocID[4]);
        }

        private void ToDel7_Click(object sender, EventArgs e)
        {
            FileDel(ExtraDoc[5], ExtraDocID[5]);
        }

        private void ToDel8_Click(object sender, EventArgs e)
        {
            FileDel(ExtraDoc[6], ExtraDocID[6]);
        }

        private void ToDel9_Click(object sender, EventArgs e)
        {
            FileDel(ExtraDoc[7], ExtraDocID[7]);
        }

        private void ToDel10_Click(object sender, EventArgs e)
        {
            FileDel(ExtraDoc[8], ExtraDocID[8]);
        }

        private void ToSee3_Click(object sender, EventArgs e)
        {
            See(ExtraDoc[1]);
        }

        private void ToSee4_Click(object sender, EventArgs e)
        {
            See(ExtraDoc[2]);
        }

        private void ToSee5_Click(object sender, EventArgs e)
        {
            See(ExtraDoc[3]);
        }

        private void ToSee6_Click(object sender, EventArgs e)
        {
            See(ExtraDoc[4]);
        }

        private void ToSee7_Click(object sender, EventArgs e)
        {
            See(ExtraDoc[5]);
        }

        private void ToSee8_Click(object sender, EventArgs e)
        {
            See(ExtraDoc[6]);
        }

        private void ToSee9_Click(object sender, EventArgs e)
        {
            See(ExtraDoc[7]);
        }

        private void ToSee10_Click(object sender, EventArgs e)
        {
            See(ExtraDoc[8]);
        }

        private void ToLoad1_Click(object sender, EventArgs e)
        {
            //System.IO.File.Copy(fileToCopy, newLocation, true);
            var SFD = new System.Windows.Forms.SaveFileDialog();
            SFD.FileName = @FileName1;
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.Copy(FilePath1, SFD.FileName, true);
                //BinaryWriter bw = new BinaryWriter(File.Create(SFD.FileName));
            }
        }
        private void LoadFunction(string path)
        {
            var SFD = new System.Windows.Forms.SaveFileDialog();
            SFD.FileName = Path.GetFileName(path);
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.Copy(path, SFD.FileName, true);
            }
        }

        private void ToLoad2_Click(object sender, EventArgs e)
        {
            LoadFunction(ExtraDoc[0]);
        }

        private void ToLoad3_Click(object sender, EventArgs e)
        {
            LoadFunction(ExtraDoc[1]);
        }

        private void ToLoad4_Click(object sender, EventArgs e)
        {
            LoadFunction(ExtraDoc[2]);
        }

        private void ToLoad5_Click(object sender, EventArgs e)
        {
            LoadFunction(ExtraDoc[3]);
        }

        private void ToLoad6_Click(object sender, EventArgs e)
        {
            LoadFunction(ExtraDoc[4]);
        }

        private void ToLoad7_Click(object sender, EventArgs e)
        {
            LoadFunction(ExtraDoc[5]);
        }

        private void ToLoad8_Click(object sender, EventArgs e)
        {
            LoadFunction(ExtraDoc[6]);
        }

        private void ToLoad9_Click(object sender, EventArgs e)
        {
            LoadFunction(ExtraDoc[7]);
        }

        private void ToLoad10_Click(object sender, EventArgs e)
        {
            LoadFunction(ExtraDoc[8]);
        }
    }
}
