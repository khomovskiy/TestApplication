using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TestApplication
{
    //Класс для управления данными
    class DataManager
    {
        public DBMySQLConnector connector { get; set; }
        string createIndexQuery;
        //Список полученных и вывоимых данных
        public List<DataModel> ListDataModels { get; set; }
        public DataManager()
        {
            connector = new DBMySQLConnector();
            //Проверка наличия и создание индекса таблицы `coordinates` в БД
            if (!HasIndex())
            {
                createIndexQuery = "CREATE INDEX `coord_index` ON `coordinates`(`imei_id`, `dt`)";
                connector.ExecuteNonQuery(createIndexQuery);
            }
        }
        bool HasIndex()
        {
            string checkQuery = "SHOW index FROM `coordinates` WHERE `Key_name`='coord_index' AND (`Column_name`='imei_id' OR `Column_name`='dt')";
            MySqlDataReader reader = connector.ExecuteReader(checkQuery);
            if (reader.HasRows)
            {
                reader.Close();
                return true;
            }
            reader.Close();
            return false;
        }
        //Получает список всех бортов с датой последнего обновления координат
        public void GetLatestUpdateTimes()
        {
            List<DataModel> list = ReadImeies();
            if (list == null)
            {
                connector.CloseConnection();
                return;
            }
            MySqlParameter boardIdParam = new MySqlParameter("@imeies_id", 1);
            MySqlDataReader readerUpdateDateTime;
            MySqlParameter[] parameters = new MySqlParameter[] { boardIdParam };
            string sqlSubQuery = "SELECT MAX(`dt`) FROM `coordinates` WHERE imei_id=@imeies_id";
            foreach (var board in list)
            {
                boardIdParam.Value = board.Id;
                readerUpdateDateTime = connector.ExecuteReader(sqlSubQuery, parameters);
                if (readerUpdateDateTime != null && readerUpdateDateTime.Read() && !readerUpdateDateTime.IsDBNull(0))
                {
                    board.LastUpdateDateTime = readerUpdateDateTime.GetDateTime(0);
                }
                if (!readerUpdateDateTime.IsClosed)
                {
                    readerUpdateDateTime.Close();
                }
            }
            connector.CloseConnection();
        }
        //Получает список всех бортов
        List<DataModel> ReadImeies()
        {
            string sqlQuery = "SELECT `id`, `othername`, `gov_number` FROM `imeies`";
            MySqlDataReader readerBoards = connector.ExecuteReader(sqlQuery);
            if (readerBoards == null)
            {
                readerBoards.Close();
                connector.CloseConnection();
                return null;
            }
            ListDataModels = new List<DataModel>();
            try
            {
                while (readerBoards.Read())
                {
                    ListDataModels.Add(new DataModel
                    {
                        Id = readerBoards.GetInt32(0),
                        BoardName = readerBoards.GetString(1),
                        GovernmentNumber = readerBoards.GetString(2),
                    });

                }
                readerBoards.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "SqlError", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ListDataModels;
        }
        //Фильтрует данные, удаляя те борта которые обновлялись не позже hours:minutes
        public void GetBoardNotUpdatedMoreTime(double hours, double minutes)
        {
            this.GetLatestUpdateTimes();
            for (int i = 0; i < ListDataModels.Count; i++)
            {
                double span = (DateTime.Now - ListDataModels[i].LastUpdateDateTime).TotalMinutes;
                double span2 = (TimeSpan.FromHours(hours) + TimeSpan.FromMinutes(minutes)).TotalMinutes;
                if (span <= span2)
                {
                    ListDataModels.Remove(ListDataModels[i]);
                    i--;
                }
            }
            connector.CloseConnection();
        }

    }
}
