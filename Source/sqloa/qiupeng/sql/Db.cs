namespace qiupeng.sql
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    public class Db
    {
        public static DataView Board;
        public static DataView Config;
        public static string strConn = "";

        public string DbPath()
        {
            strConn = "" + ConfigurationManager.AppSettings["connstr"].ToString() + "";
            return strConn;
        }

        public int ExeSql(string Sql)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(Sql, connection);
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
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(Sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
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

        public DataView GetGrid(string Sql, string Tb)
        {
            SqlConnection selectConnection = new SqlConnection(ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(Sql, selectConnection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, Tb);
            DataView defaultView = dataSet.Tables[Tb].DefaultView;
            adapter.Dispose();
            return defaultView;
        }

        public DataView GetGrid_Pages(string Sql, string Sort)
        {
            DataTable table = new DataTable();
            SqlConnection selectConnection = new SqlConnection(ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(Sql, selectConnection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "MyDt");
            table = dataSet.Tables["MyDt"];
            DataView view = new DataView(table);
            view.Sort = Sort + " Desc";
            adapter.Dispose();
            selectConnection.Close();
            return view;
        }

        public DataView GetGrid_Pages_not(string Sql)
        {
            DataTable table = new DataTable();
            SqlConnection selectConnection = new SqlConnection(ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(Sql, selectConnection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "MyDt");
            table = dataSet.Tables["MyDt"];
            DataView view = new DataView(table);
            adapter.Dispose();
            selectConnection.Close();
            return view;
        }

        public SqlDataReader GetList(string Sql)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(Sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
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

