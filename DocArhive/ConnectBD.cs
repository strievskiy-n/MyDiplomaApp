using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Drawing;


namespace DocArhive
{
    public class ConnectBD
    {
        public String dbName;
        public SQLiteConnection connect;
        public SQLiteCommand command;
        public ConnectBD()
        {
            connect = new SQLiteConnection();
            command = new SQLiteCommand();

            dbName = "DockArchiveDB.sqlite";

            connect = new SQLiteConnection("Data Source=" + dbName + ";Version=3;");
            connect.Open();
            command.Connection = connect;

            if (!File.Exists(dbName))
                SQLiteConnection.CreateFile(dbName);

            try
            {

                command.CommandText = "CREATE TABLE IF NOT EXISTS Users (id INTEGER PRIMARY KEY AUTOINCREMENT, login TEXT,  name TEXT, password TEXT, role INTEGER DEFAULT 0, departID INTEGER DEFAULT 0, del BOOLEAN DEFAULT (0))"; //По умолчанию роль юзер (role 0) и никакого отдела (departID 0)
                command.ExecuteNonQuery();
                
                command.CommandText = "CREATE TABLE IF NOT EXISTS Department (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT, majorID INTEGER REFERENCES Users(id), del BOOLEAN DEFAULT (0))";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE IF NOT EXISTS Case1 (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT, departID INTEGER REFERENCES Department(id), number TEXT, majorID INTEGER REFERENCES Users(id), del BOOLEAN DEFAULT (0))";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE IF NOT EXISTS Document (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT," +
                    "number TEXT, majorID INTEGER REFERENCES Users(id), caseID INTEGER REFERENCES Case1(id), departID INTEGER REFERENCES Department(id) DEFAULT 0,"+
                    " thom INTEGER, thomPage INTEGER, type TEXT, date TEXT, author TEXT, executors TEXT, dateOfExecution TEXT, phaseOfExecution TEXT,"+
                    "resolution TEXT, NNPages TEXT, physicalLocation TEXT, synopsis TEXT, file INTEGER, savingTime INTEGER, isThisFileDel BOOLEAN DEFAULT (0), deleteDate TEXT, extraFiles BOOLEAN DEFAULT (0), fPas TEXT)";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE IF NOT EXISTS ActionHistory (id INTEGER PRIMARY KEY AUTOINCREMENT, nameOfUser TEXT, idOfUser INTEGER, dateAndTime TEXT, sqlRequest TEXT)";//создание таблицы с сохранением всех изменений, добавлений или удалений 
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE IF NOT EXISTS ExtraDoc (id INTEGER PRIMARY KEY AUTOINCREMENT, docID INTEGER REFERENCES Document(id), name TEXT, del BOOLEAN DEFAULT (0), fPas TEXT)";//создание таблицы для сохранения адресов дополнительных документов 
                command.ExecuteNonQuery();

            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }

    class Class1
    {
    }
}
