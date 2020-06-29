using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace task_up
{
    class DBCommands
    {
        public static SQLiteConnection con = new SQLiteConnection("Data Source=taskup.db;Version=3;");

        public static void dbCreate()
        {
            if (!File.Exists("taskup.db"))
            {
                SQLiteConnection.CreateFile("taskup.db");
                dbConnect();
                using (con)
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(con))
                    {
                        cmd.CommandText = @"Create table if not exists Lists (
                        ListNo INTEGER PRIMARY KEY, 
                        ListName nvarchar(15))";
                        cmd.ExecuteNonQuery();
                        dbDisconnect();
                    }
                }
                dbConnect();
                using (con)
                {
                    using (SQLiteCommand cmd2 = new SQLiteCommand(con))
                    {
                        cmd2.CommandText = @"Create table if not exists Tasks (
                        TaskNo INTEGER PRIMARY KEY AUTOINCREMENT, 
                        ListNo INTEGER,
                        Date DATE,
                        Title nvarchar(20),
                        Text TEXT,
                        Priority nvarchar(10),
                        Info nvarchar(15))";
                        cmd2.ExecuteNonQuery();
                        dbDisconnect();
                    }
                }
                dbConnect();
                using (con)
                {
                    using (SQLiteCommand cmd3 = new SQLiteCommand(con))
                    {
                        cmd3.CommandText = @"Create table if not exists History (
                        ProcessNo INTEGER PRIMARY KEY AUTOINCREMENT, 
                        Text TEXT)";
                        cmd3.ExecuteNonQuery();
                        dbDisconnect();
                    }
                }
                dbConnect();
                using (con)
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(con))
                    {
                        cmd.CommandText = "insert into Lists (ListNo,ListName) values ('1','Liste 1')";                
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "insert into Lists (ListNo,ListName) values ('2','Liste 2')";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "insert into Lists (ListNo,ListName) values ('3','Liste 3')";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "insert into Lists (ListNo,ListName) values ('4','Liste 4')";
                        cmd.ExecuteNonQuery();
                        dbDisconnect();
                    }
                }
            }         
        }
        
        public static int getCount(string a)
        {
            int c;
            dbConnect();
            using (con)
            {
                using (SQLiteCommand cmd = new SQLiteCommand(con))
                {
                    cmd.CommandText = "select count(*) from " + a;
                    c = Convert.ToInt32(cmd.ExecuteScalar());
                    dbDisconnect();
                }
            }
            return c;
        }

        public static void historyWrite(int a)
        {
            dbConnect();
            using (con)
            {
                using (SQLiteCommand cmd = new SQLiteCommand(con))
                {
                    cmd.CommandText = "select Title from Tasks where TaskNo="+a;
                    string title = cmd.ExecuteScalar().ToString();
                    cmd.CommandText = "insert into History (Text) values ('"+title+" başlıklı görevinizi tamamladınız.')";
                    cmd.ExecuteNonQuery();
                    
                    dbDisconnect();
                }
            }
        }
        public static DataSet getList(string a)
        {
            con = new SQLiteConnection("Data Source=taskup.db;Version=3;");
            SQLiteDataAdapter da = new SQLiteDataAdapter("Select *From "+a, con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds, "Lists");
            con.Close();
            return ds;
        }
        public static DataSet getList(string a, string b, string c)
        {
            con = new SQLiteConnection("Data Source=taskup.db;Version=3;");
            SQLiteDataAdapter da = new SQLiteDataAdapter("Select TaskNo,Date,Title,Text,Priority,Info From " + a + " Where " + b + "=" + c, con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds, "Lists");
            con.Close();
            return ds;
        }

        public static string getListNames(int a)
        {
            dbConnect();
            using (con)
            {
                using (SQLiteCommand cmd = new SQLiteCommand(con))
                {
                    cmd.CommandText = "select ListName from lists where ListNo=1";
                    string n1 = cmd.ExecuteScalar().ToString();
                    cmd.CommandText = "select ListName from lists where ListNo=2";
                    string n2 = cmd.ExecuteScalar().ToString();
                    cmd.CommandText = "select ListName from lists where ListNo=3";
                    string n3 = cmd.ExecuteScalar().ToString();
                    cmd.CommandText = "select ListName from lists where ListNo=4";
                    string n4 = cmd.ExecuteScalar().ToString();
                    dbDisconnect();
                    if (a == 1) return n1;
                    if (a == 2) return n2;
                    if (a == 3) return n3;
                    if (a == 4) return n4;
                    return "ERROR";
                }
            }
        }

        public static string getData(string a, int b)
        {
            dbConnect();
            using (con)
            {
                using (SQLiteCommand cmd = new SQLiteCommand(con))
                {
                    cmd.CommandText = "select "+a+" from Tasks where TaskNo="+b.ToString();
                    string c = cmd.ExecuteScalar().ToString();
                    dbDisconnect();
                    return c;
                }
            }
        }

        public static void compTask(string a)
        {
            dbConnect();
            using (con)
            {
                using (SQLiteCommand cmd = new SQLiteCommand(con))
                {
                    cmd.CommandText = "update Tasks set Info='Tamamlandı' Where TaskNo=" + a;
                    cmd.ExecuteNonQuery();
                    dbDisconnect();
                }
            }
        }

        public static void updateTask(String p1, string p2, string p3, string p4, int p5)
        {
            dbConnect();
            using (con)
            {
                using (SQLiteCommand cmd = new SQLiteCommand(con))
                {
                    cmd.CommandText = "update Tasks set Date='"+p1+"', Title='"+p2+"', Text='"+p3+"', Priority='"+p4+"' where TaskNo=" + p5.ToString();
                    cmd.ExecuteNonQuery();
                    dbDisconnect();
                }
            }
        }

        public static void deleteTask(string a)
        {
            dbConnect();
            using (con)
            {
                using (SQLiteCommand cmd = new SQLiteCommand(con))
                {
                    cmd.CommandText = "delete from Tasks Where TaskNo=" + a;
                    cmd.ExecuteNonQuery();
                    dbDisconnect();
                }
            }
        }   

        public static void insertTask(string p1, DateTime p2, string p3, string p4, string p5, string p6)
        {
            dbConnect();
            using (con)
            {
                using (SQLiteCommand cmd = new SQLiteCommand(con))
                {
                    string date = p2.ToString("yyyy-MM-dd");
                    cmd.CommandText = "insert into Tasks (ListNo,Date,Title,Text,Priority,Info) values (@p1,@p2,@p3,@p4,@p5,@p6)";
                    cmd.Parameters.AddWithValue("@p1", p1);
                    cmd.Parameters.AddWithValue("@p2", date);
                    cmd.Parameters.AddWithValue("@p3", p3);
                    cmd.Parameters.AddWithValue("@p4", p4);
                    cmd.Parameters.AddWithValue("@p5", p5);
                    cmd.Parameters.AddWithValue("@p6", p6);
                    cmd.ExecuteNonQuery();
                    dbDisconnect();
                }
            }
        }

        
        public static void dbConnect()
        {
            con = new SQLiteConnection("Data Source=taskup.db;Version=3;");
            con.Open();
        }

        public static void dbDisconnect()
        {
            con.Close();
        }
    }
}
