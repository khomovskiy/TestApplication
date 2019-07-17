using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TestApplication
{
    //Надстройка над MySqlConnection
    class DBMySQLConnector 
    {
        string ConnectionString { get; set; }
        MySqlConnection Connection { get; set; }
        public DBMySQLConnector()
        {
            try
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            }
            catch (ConfigurationErrorsException e)
            {
                MessageBox.Show(e.Message, "ConfigurationError", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Connection = new MySqlConnection(ConnectionString);

        }
        //Закрывает соединение с БД
        public void CloseConnection()
        {
            if(Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
            }
        }
        //Открывает соединение с БД
        public void OpenConnection()
        {
            if (Connection.State != System.Data.ConnectionState.Open)
            {
                Connection.Open();
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
            catch (SqlException e)
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
            MySqlCommand sqlCommand = new MySqlCommand(command, Connection);
            sqlCommand.CommandTimeout = 2000;
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
