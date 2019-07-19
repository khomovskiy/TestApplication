using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TestApplication
{
    //Класс для управления данными
    class DataManager
    {
        public DBMySQLConnector Connector { get; set; }
        //Список полученных и выводимых данных
        public List<DataModel> ListDataModels { get; set; }
        DateTime Begin { get; set; }
        DateTime End { get; set; }
        TimeSpan Delay { get; set; }
        List<DataModel> ListImeies { get; set; }
        public DataManager()
        {
            Connector = new DBMySQLConnector();
            if (Connector.Connection is null) Environment.Exit(0);
        }
        //Получает дату последнего обновления координат каждого борта
        public void GetLatestUpdateTimes()
        {
            ListDataModels = ReadImeies();
            if (ListDataModels is null)
            {
                Connector.CloseConnection();
                return;
            }
            MySqlParameter boardIdParam = new MySqlParameter("@imeies_id", 1);
            MySqlDataReader readerUpdateDateTime;
            MySqlParameter[] parameters = new MySqlParameter[] { boardIdParam };
            string sqlSubQuery = "SELECT MAX(`dt`) FROM `coordinates` WHERE imei_id=@imeies_id";
            foreach (var board in ListDataModels)
            {
                boardIdParam.Value = board.Id;
                readerUpdateDateTime = Connector.ExecuteReader(sqlSubQuery, parameters);
                if (readerUpdateDateTime != null && readerUpdateDateTime.Read() && !readerUpdateDateTime.IsDBNull(0))
                {
                    board.LastUpdateDateTime = readerUpdateDateTime.GetDateTime(0);
                }
                if (!readerUpdateDateTime.IsClosed)
                {
                    readerUpdateDateTime.Close();
                }
            }
            Connector.CloseConnection();
        }
        //Получает список всех бортов
        List<DataModel> ReadImeies()
        {
            string sqlQuery = "SELECT `id`, `othername`, `gov_number` FROM `imeies`";
            MySqlDataReader readerBoards = Connector.ExecuteReader(sqlQuery);
            if (readerBoards is null)
            {
                Connector.CloseConnection();
                return null;
            }
            List<DataModel> list = new List<DataModel>();
            try
            {
                while (readerBoards.Read())
                {
                    list.Add(new DataModel
                    {
                        Id = readerBoards.IsDBNull(0) ? -1 : readerBoards.GetInt32(0),
                        BoardName = readerBoards.IsDBNull(1) ? "" : readerBoards.GetString(1),
                        GovernmentNumber = readerBoards.IsDBNull(2) ? "" : readerBoards.GetString(2),
                    });
                }
                readerBoards.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "SqlError", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        //Фильтрует данные, удаляя те борта которые обновлялись не позже hours:minutes
        public void GetBoardNotUpdatedMoreTime(double hours, double minutes)
        {
            this.GetLatestUpdateTimes();
            if (ListDataModels is null) return;
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
            Connector.CloseConnection();
        }

        public void GetBigUpdateDelayInTimeRange(DateTime begin, DateTime end, TimeSpan delaySize)
        {
            int id = 0;
            MySqlParameter idParam = new MySqlParameter("@id", id);
            if (begin == new DateTime())
            {
                if (ListDataModels.Count > 0)
                    idParam.Value = ListDataModels[ListDataModels.Count - 1].CoordId;
            }
            else
            {
                ListDataModels = new List<DataModel>();
                ListImeies = ReadImeies();
                Begin = begin;
                End = end;
                Delay = delaySize;
            }
            List<DataModel> buffer = null;
            MySqlParameter startDateParam = new MySqlParameter("@startDate", Begin);
            MySqlParameter endDateParam = new MySqlParameter("@endDate", End);
            MySqlParameter[] nextParameters = new MySqlParameter[] { startDateParam, endDateParam, idParam };
            MySqlParameter[] parameters = new MySqlParameter[] { startDateParam, endDateParam };
            if ((int)idParam.Value == 0)
            {
                int firstId = GetFirstRowId(parameters);
                if (firstId != -1) idParam.Value = firstId;
                else return;
            }
            buffer = GetRows(nextParameters);
            for (int i = 0; i < buffer.Count; i++)
            {
                if (i + 1 < buffer.Count && (buffer[i].StartDateTime - buffer[i + 1].StartDateTime).TotalMinutes > Delay.TotalMinutes)
                {
                    DataModel data = new DataModel
                    {
                        StartDateTime = buffer[i].StartDateTime,
                        EndDateTime = buffer[i + 1].StartDateTime,
                        CoordId = buffer[i].CoordId,
                        Id = buffer[i].Id,
                        BoardName = ListImeies.Find(b => b.Id == buffer[i].Id).BoardName,
                        GovernmentNumber = ListImeies.Find(b => b.Id == buffer[i].Id).GovernmentNumber
                    };
                    ListDataModels.Add(data);
                }
            }
        }
        int GetFirstRowId(MySqlParameter[] parameters)
        {
            string firstIdQuery = "SELECT `id` FROM `coordinates` WHERE `dt` BETWEEN @startDate AND @endDate ORDER BY `id` DESC, `dt` DESC LIMIT 1";
            MySqlDataReader reader = Connector.ExecuteReader(firstIdQuery, parameters);
            int firstRowId;
            if (reader != null && reader.HasRows && reader.Read())
            {
                firstRowId = reader.GetInt32(0);
            }
            else
            {
                MessageBox.Show("Данные не найдены", "ReadError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                firstRowId = -1;
            }
            if (reader != null) reader.Close();
            return firstRowId;
        }
        List<DataModel> GetRows(MySqlParameter[] parameters)
        {
            string firstDateQuery = "SELECT `id`, `dt`, `imei_id` FROM `coordinates` WHERE `id`<@id AND (`dt` BETWEEN @startDate AND @endDate) ORDER BY `id` DESC, `dt` DESC LIMIT 10000";
            MySqlDataReader reader = Connector.ExecuteReader(firstDateQuery, parameters);
            List<DataModel> buff = new List<DataModel>();
            while (reader != null && reader.Read())
            {
                if (reader.HasRows && !reader.IsDBNull(1))
                {
                    DataModel data = new DataModel
                    {
                        StartDateTime = reader.GetDateTime(1),
                        CoordId = reader.GetInt32(0),
                        Id = reader.GetInt32(2)
                    };
                    buff.Add(data);
                }
            }
            if (reader != null && !reader.IsClosed) reader.Close();
            return buff;
        }
    }
}
