using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace TestApplication
{
    //Надстройка над MySqlConnection
    class DBMySQLConnector
    {
        string ConnectionString { get; set; }
        public MySqlConnection Connection { get; set; }
        public string Server { get; set; }
        public string DataBase { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }

        public DBMySQLConnector(string server = null, string dataBase = null, string user = null, string password = null, int port = 3306)
        {
            try
            {
                //var factory = DbProviderFactories.GetFactory("MySql.Data");
                //var builder = factory.CreateConnectionStringBuilder();
                ConnectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
                //Server = server is null ? builder["Server"] as string : server;
                //DataBase = dataBase is null ? builder["Database"] as string : dataBase;
                //if (int.TryParse(builder["Port"] as string, out int csPort))
                //    Port = csPort;
                //else
                //    Port = port;
                //User = user is null ? builder["Uid"] as string : user;
                //Password = password is null ? builder["Password"] as string : password;
                //StringBuilder str = new StringBuilder();
                //DbConnectionStringBuilder.AppendKeyValuePair(str, "Server", Server);
                //DbConnectionStringBuilder.AppendKeyValuePair(str, "Port", Port.ToString());
                //DbConnectionStringBuilder.AppendKeyValuePair(str, "Database", DataBase);
                //DbConnectionStringBuilder.AppendKeyValuePair(str, "Uid", User);
                //DbConnectionStringBuilder.AppendKeyValuePair(str, "Password", Password);
                //ConnectionString = str.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка конфигурации подключения", "ConfigurationError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Connection = new MySqlConnection(ConnectionString);

        }
        //Закрывает соединение с БД
        public void CloseConnection()
        {
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    Connection.Close();
                }
                catch (MySqlException e)
                {
                    throw new Exception(e.Message, e);
                }
            }
        }
        //Открывает соединение с БД
        public void OpenConnection()
        {
            if (Connection.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    Connection.Open();
                }
                catch (MySqlException e)
                {
                    throw new Exception(e.Message, e);
                }
            }
        }
        //Выполнение запросов без возращаемых данных
        public int ExecuteNonQuery(string command)
        {
            MySqlCommand sqlCommand = new MySqlCommand(command, Connection);
            try
            {
                int rows = sqlCommand.ExecuteNonQuery();
                CloseConnection();
                return rows;
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message, "SqlError", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "CommandExecuteError", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return -1;
        }
        //Выполнение запросов с возращаемыми данными с возвратом MySqlReader
        public MySqlDataReader ExecuteReader(string command, MySqlParameter[] parameterCollection = null)
        {
            MySqlDataReader reader = null;
            MySqlCommand sqlCommand = new MySqlCommand(command, Connection)
            {
                CommandTimeout = 2000
            };
            if (parameterCollection != null)
            {
                sqlCommand.Parameters.AddRange(parameterCollection);
            }
            try
            {
                OpenConnection();
                reader = sqlCommand.ExecuteReader();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "SqlError", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "CommandExecuteError", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return reader;
        }
    }
}
