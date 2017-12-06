namespace qiupeng.sql
{
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.Windows.Forms;

    public class Db
    {
        public static DataView Board;
        public static DataView Config;
        public static string strConn = "";

        public string DbPath()
        {
            return ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + @"\oahelp.dll;Persist Security Info=False;Jet OLEDB:Database Password=qiupeng;");
        }

        public int ExeSql(string Sql)
        {
            OleDbConnection connection = new OleDbConnection(ConnectionString);
            OleDbCommand command = new OleDbCommand(Sql, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                return 1;
            }
            catch
            {
                command.Dispose();
                connection.Close();
                return 0;
            }
        }

        public int GetCount(string Sql)
        {
            OleDbConnection connection = new OleDbConnection(ConnectionString);
            OleDbCommand command = new OleDbCommand(Sql, connection);
            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();
            int num = 0;
            while (reader.Read())
            {
                num = reader.GetInt32(0);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return num;
        }

        public string GetFormatStr(string AStr)
        {
            if ("" == AStr)
            {
                return "";
            }
            AStr = AStr.Replace("<", "〈");
            AStr = AStr.Replace(">", "〉");
            AStr = AStr.Replace("'", "’");
            return AStr;
        }

        public DataView GetGrid(string Sql, string Tb)
        {
            OleDbConnection selectConnection = new OleDbConnection(ConnectionString);
            OleDbDataAdapter adapter = new OleDbDataAdapter(Sql, selectConnection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, Tb);
            DataView defaultView = dataSet.Tables[Tb].DefaultView;
            adapter.Dispose();
            return defaultView;
        }

        public OleDbDataReader GetList(string Sql)
        {
            OleDbConnection connection = new OleDbConnection(ConnectionString);
            OleDbCommand command = new OleDbCommand(Sql, connection);
            connection.Open();
            OleDbDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            command.Dispose();
            return reader;
        }

        public static string ConnectionString
        {
            get
            {
                Db db = new Db();
                return db.DbPath();
            }
        }
    }
}

