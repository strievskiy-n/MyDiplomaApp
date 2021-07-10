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
    class DataClass
    {
        public static int ID;
        public static string NameOfUser;
        public static int Role; // роль 0 - админ, 1 - юзер
        public static int DepartUserID; // номер департамента юзера
        public static int DepartID; // номер департамента с которым мы сейчас работаем
        public static int CaseID; // номер дела с которым мы сейчас работаем
        public static int DocID; // номер документа с которым мы сейчас работаем
        public static string ChangeUserName;// id изменяемого или удаляемого юзера
        public static string BackPage = ""; //предыдущая страница (поиска)
        public static string[] FilterFields = new string[19]{ "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "0"}; //[18] = 0 это флаг о том, что фильтров нет, [18] = 1 значит фильтры есть
        public static string[] FilterNames = new string[17] { "name", "number", "majorID", "caseID", "departID", "thom", "type", "date", "author", "executors", "savingTime", "dateOfExecution", "phaseOfExecution", "resolution", "NNPages", "physicalLocation", "synopsis" };
        public static void KillFilters()
        {
            int q = 0;
            while (q != 19)
            {
                FilterFields[q] = "";
                if(q==18)
                {
                    FilterFields[q] = "0";
                }
                q += 1;
            }
        }
        public static void CheckFlag(int i)
        {
            if(FilterFields[i]=="")
            {
                int flag = 0;
                int a = 1;
                while(a != 17)
                {
                    if(FilterFields[i] != "")
                    {
                        flag += 1;
                    }
                    a += 1;
                }
                if(flag==0)
                {
                    FilterFields[18] = "0";
                }
                else
                {
                    FilterFields[18] = "1"; //фильтры есть
                }
            }
            if (FilterFields[i] != "")
            {
                FilterFields[18] = "1";
            }
        }
        public void i(int o)
        {
            o += 1;
        }
    }
    public class SQLHistory
    {
        ConnectBD sql = new ConnectBD();
        public void SqlRequest( string SQLreq)
        {
            string date = DateTime.Now.ToString();
            try
            {
                SQLreq = SQLreq.Replace("'", "");
                sql.command.CommandText = "INSERT INTO ActionHistory (nameOfUser, idOfUser, dateAndTime, sqlRequest) VALUES('" + DataClass.NameOfUser + "', '" + DataClass.ID + "', '" + date + "','" + SQLreq + "' ) ";
                sql.command.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }


}
