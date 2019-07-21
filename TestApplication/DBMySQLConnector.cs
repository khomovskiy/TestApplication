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
        DbConnectionStringBuilder Builder { get; set; }
        public MySqlConnection Connection { get; set; }
        public string Server { get; set; }
        public string DataBase { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        //Инициализация строки подключения из config файла
        public DBMySQLConnector()
        {
            Builder = new DbConnectionStringBuilder();
            try
            {
                Builder.ConnectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
                InitializeFields();
                ConnectionString = Builder.ConnectionString;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Ошибка конфигурации подключения", "ConfigurationError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Connection = new MySqlConnection(ConnectionString);
        }
        //Инициализация строки подключения из кода
        public DBMySQLConnector(string server, string dataBase, string user, string password = null, int port = 3306)
        {
            Builder = new DbConnectionStringBuilder();
            try
            {
                StringBuilder str = new StringBuilder();
                DbConnectionStringBuilder.AppendKeyValuePair(str, "Server", server);
                DbConnectionStringBuilder.AppendKeyValuePair(str, "Port", port.ToString());
                DbConnectionStringBuilder.AppendKeyValuePair(str, "Database", dataBase);
                DbConnectionStringBuilder.AppendKeyValuePair(str, "Uid", user);
                DbConnectionStringBuilder.AppendKeyValuePair(str, "Pwd", password);
                Builder.ConnectionString = str.ToString();
                InitializeFields();
                ConnectionString = Builder.ConnectionString;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка конфигурации подключения", "ConfigurationError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Connection = new MySqlConnection(ConnectionString);

        }
        void InitializeFields()
        {
            Server = Builder["Server"] as string;
            DataBase = Builder["Database"] as string;
            try
            {
                Password = Builder["Pwd"] as string;
            }
            catch (ArgumentException)
            {
                Password = "";
                Builder.Add("pwd", Password);
            }
            if (int.TryParse(Builder["Port"] as string, out int csPort))
                Port = csPort;
            else
                Port = 3306;
            User = Builder["Uid"] as string;
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
                    throw new Exception("Ошибка подключения к базе данных", e);
                }
            }
        }
        //Выполнение запросов без возращаемых данных
        public int ExecuteNonQuery(string command)
        {
            MySqlCommand sqlCommand = new MySqlCommand(command, Connection);
            try
            {
                OpenConnection();
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
