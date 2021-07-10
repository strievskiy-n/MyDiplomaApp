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
using System.Windows.Documents;
using Word = Microsoft.Office.Interop.Word;
using System.Security.Cryptography;
using System.Web.Security;


namespace DocArhive
{
    public partial class AddDoc : Form
    {
        static string sKey;
        int NumOfDoc = 0; //Счетчик количества файлов, который недолжен превышать 9
        string[] ExtraDoc = new string[9] { "", "", "", "", "", "", "", "", "" }; //массив для сохранения имен
        string Adress = "";
        string BackAdress = "";
        ConnectBD sql = new ConnectBD();
        public AddDoc()
        {
            InitializeComponent();
        }

        private void ChangeDataButton_Click(object sender, EventArgs e)
        {
            if (DockName.Text == "" || Number.Text == "" || NameOfMajor.SelectedItem == null || NameOfCase.SelectedItem == null || NumberOfThom.Text == "" || DockType.Text == "" || DateOfDoc.Text == "" || PhysicalLocation.Text == "" || DeleteDate.Text == "" || Adress == "")
            {
                MessageBox.Show("Заполнены не все обязательные поля!");
            }
            else
            {
                try //Добавление нового документа
                { //TO DO добавление ответственного, дела и отдела!!!!!!!
                    sql.command.CommandText = "SELECT id FROM Users Where name LIKE '" + NameOfMajor.SelectedItem + "' ";
                    SQLiteDataReader read0 = sql.command.ExecuteReader();
                    int mID = 0;
                    while (read0.Read())
                    {
                        mID = Convert.ToInt32(read0["id"]);
                    }
                    read0.Close();

                    sql.command.CommandText = "SELECT id FROM Case1 WHERE name LIKE '" + NameOfCase.SelectedItem + "' ";
                    SQLiteDataReader read1 = sql.command.ExecuteReader();
                    int cID = 0;
                    while (read1.Read())
                    {
                        cID = Convert.ToInt32(read1["id"]);
                    }
                    read1.Close();

                    int extrFil = 0; 
                    if (ExtraDoc[0] != "")//проверка на наличие дополнительных файлов
                    {
                        extrFil = 1;
                    }

                    sql.command.CommandText = "INSERT INTO Document (name, number, majorID, caseID, departID, thom, type, date, author, executors, dateOfExecution, PhaseOfExecution, resolution, NNPages, physicalLocation, synopsis, file, savingTime, deleteDate, extraFiles) VALUES( '"
                        + DockName.Text.ToLower()
                        + "','" + Number.Text.ToLower() +
                        "','" + mID + 
                        "','" + cID +
                        "','" + DataClass.DepartID +
                        "','" + NumberOfThom.Text.ToLower() +
                        "','" + DockType.Text.ToLower() +
                        "','" + DateOfDoc.Text.ToLower() +
                        "','" + Author.Text.ToLower() +
                        "','" + Executors.Text.ToLower() +
                        "','" + DateOfExecution.Text.ToLower() +
                        "','" + PhaseOfExecution.Text.ToLower() +
                        "','" + Resolution.Text.ToLower() +
                        "','" + NNPages.Text.ToLower() +
                        "','" + PhysicalLocation.Text.ToLower() +
                        "','" + Synopsis.Text.ToLower() +
                        "','" + Adress +
                        "','" + SavingTime.Text.ToLower() +
                        "','" + DeleteDate.Text.ToLower() +
                        "','" + extrFil + "' )";
                    sql.command.ExecuteNonQuery();
                    SQLHistory SqlH = new SQLHistory(); //Сохранение изменений в историю 
                    SqlH.SqlRequest(sql.command.CommandText);

                    if (extrFil ==1) //добавление в бд адресов дополнительных файлов, при наличии таковых
                    {
                        int DocID = 0;
                        sql.command.CommandText = "SELECT id FROM Document WHERE name LIKE '" + DockName.Text.ToLower() + "' ";
                        SQLiteDataReader read2 = sql.command.ExecuteReader();
                        while(read2.Read())
                        {
                            DocID = Convert.ToInt32(read2["id"]);
                        }
                        read2.Close();
                        int counter = 0;
                        while(counter<9)
                        {
                            if(ExtraDoc[counter]!="")
                            {
                                sql.command.CommandText = "INSERT INTO ExtraDoc (docID, name) VALUES('"+
                                    DocID + "' , '"+ 
                                    ExtraDoc[counter] + "' )";
                                sql.command.ExecuteNonQuery();
                                SqlH.SqlRequest(sql.command.CommandText);
                            }
                            counter += 1;
                        }
                    }

                    MessageBox.Show("Документ '"+ DockName.Text + "' успешно добавлен!");
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
        public void DocForWork()
        {
            string Path = Application.StartupPath;//нужно убрать 20 символов
            Path = Path.Remove(Path.LastIndexOf(@"DocArhive\bin"));
            string add = @"Doc\";
            string name = "Name";
            Path = Path + add + name;
            Word.Application app = new Word.Application();
            Word.Document doc = app.Documents.Add(Visible: true);
            Word.Range wordrange = doc.Range();
            wordrange.Text = "Текст который мы выводим в выделенный участок ";

            Object fileName = Path;
            Object fileFormat = Word.WdSaveFormat.wdFormatDocumentDefault;
            Object lockComments = false;
            Object password = "1";
            doc.SaveAs(Path, fileFormat, lockComments, password);

            try
            {
                doc.Close();
                Object saveChanges = Word.WdSaveOptions.wdPromptToSaveChanges;
                app.Quit(saveChanges);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AddDoc_Load(object sender, EventArgs e)
        {
            //DocForWork();
            try
            {
                sql.command.CommandText = "SELECT name FROM Users WHERE del = '0' AND departID ='"+ DataClass.DepartID +"' ";
                SQLiteDataReader read0 = sql.command.ExecuteReader();
                while(read0.Read())
                {
                    NameOfMajor.Items.Add(read0["name"].ToString());
                }
                read0.Close();

                sql.command.CommandText = "SELECT name FROM Case1 WHERE departID = '" + DataClass.DepartID + "' AND del = '0' ";
                SQLiteDataReader read1 = sql.command.ExecuteReader();
                while (read1.Read())
                {
                    NameOfCase.Items.Add(read1["name"].ToString());
                }
                read1.Close();

                sql.command.CommandText = "SELECT name FROM Department WHERE id = '" + DataClass.DepartID + "' AND del = '0' ";
                SQLiteDataReader read2 = sql.command.ExecuteReader();
                while (read2.Read())
                {
                    NameOfDep.Text = read2["name"].ToString();
                }
                read2.Close();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void pictureBackBtn_Click(object sender, EventArgs e) //кнопка назад
        {
            this.Hide();
            CaseForm caseForm = new CaseForm();
            caseForm.Show();
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
        private void button1_Click(object sender, EventArgs e) //Кнопка добавления документов
        {
            if(NumOfDoc >= 10)
            {
                MessageBox.Show("Количество файлов не должно превышать 10 шт.!");
            }
            if (NumOfDoc > 0 && NumOfDoc < 10)
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
                        ExtraDoc[NumOfDoc - 1] = newLocation;
                        System.IO.File.Copy(fileToCopy, newLocation, true);
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
                NumOfDoc += 1;
            }
            if (NumOfDoc == 0)
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
                        Adress = newLocation;
                        System.IO.File.Copy(fileToCopy, newLocation, true);

                        /*
                        sKey = Membership.GeneratePassword(8, 1); //создание пароля
                        string destination = Adress;
                        string source = OFD.FileName;
                        BackAdress = OFD.FileName;
                        EncryptFile(source, destination, sKey); // шифрование документа

                        */    
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
                NumOfDoc += 1;
            }
            if (NumOfDoc == 1)
            {
                p1.Visible = true;
            }
            if (NumOfDoc == 2)
            {
                p2.Visible = true;
            }
            if (NumOfDoc == 3)
            {
                p3.Visible = true;
            }
            if (NumOfDoc == 4)
            {
                p4.Visible = true;
            }
            if (NumOfDoc == 5)
            {
                p5.Visible = true;
            }
            if (NumOfDoc == 6)
            {
                p6.Visible = true;
            }
            if (NumOfDoc == 6)
            {
                p6.Visible = true;
            }
            if (NumOfDoc == 7)
            {
                p7.Visible = true;
            }
            if (NumOfDoc == 7)
            {
                p7.Visible = true;
            }
            if (NumOfDoc == 8)
            {
                p8.Visible = true;
            }
            if (NumOfDoc == 9)
            {
                p9.Visible = true;
            }
            if (NumOfDoc == 10)
            {
                p10.Visible = true;
            }

            /*OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.DOCX;*.DOC)|*.DOCX;*.DOC|All Files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //pictureBoxAva.Image = new Bitmap(ofd.FileName);
                    //Word.Application app = new Word.Application();
                    /*Word.Application app = new Word.Application();
                    Word.Document doc = app.Documents.Add(Visible: true);*/
            /*string NameDock = ofd.FileName.ToString();
            //MessageBox.Show(NameDock);
            string Path = PrintStartupPath();

            Word.Application word = new Word.Application();
            word.Visible = true;
            Word.Document d1 = word.Documents.Add();
            Word.Document d2 = word.Documents.Open(NameDock);
            Word.Range oRange = d2.Content;
            oRange.Copy();
            d1.Content.PasteSpecial(DataType: Word.WdPasteOptions.wdKeepSourceFormatting);
            try
            {
                d1.Close();
                Object saveChanges = Word.WdSaveOptions.wdPromptToSaveChanges;
                word.Quit(saveChanges);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        catch
        {
            MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        }*/
        }
        private void EncryptFile(string source, string destination, string sKey)
        {
            FileStream fsInput = new FileStream(source, FileMode.Open, FileAccess.Read);
            FileStream fsEncrypted = new FileStream(destination, FileMode.Create, FileAccess.Write);
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            try
            {
                DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                ICryptoTransform desencrypt = DES.CreateEncryptor();
                CryptoStream cryptoStream = new CryptoStream(fsEncrypted, desencrypt, CryptoStreamMode.Write);
                byte[] bytearrayinput = new byte[fsInput.Length - 0];
                fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
                cryptoStream.Write(bytearrayinput, 0, bytearrayinput.Length);
                cryptoStream.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка!");
                return;
            }
            fsInput.Close();
            fsEncrypted.Close();
        }
        private void DecryptFile(string source, string destination, string sKey)
        {
            FileStream fsInput = new FileStream(source, FileMode.Open, FileAccess.Read);
            FileStream fsEncrypted = new FileStream(destination, FileMode.Create, FileAccess.Write);
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            try
            {
                DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                ICryptoTransform desencrypt = DES.CreateDecryptor();
                CryptoStream cryptoStream = new CryptoStream(fsEncrypted, desencrypt, CryptoStreamMode.Write);
                byte[] bytearrayinput = new byte[fsInput.Length - 0];
                fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
                cryptoStream.Write(bytearrayinput, 0, bytearrayinput.Length);
                cryptoStream.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка!");
                return;
            }
            fsInput.Close();
            fsEncrypted.Close();
        }
        private void Synopsis_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddCase_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sKey = "qwertyui"; //TO DO создание ключа
            string destination = BackAdress; //OFD.FileName;
            string source = Adress;
            DecryptFile(source, destination, sKey);

        }
    }
}
