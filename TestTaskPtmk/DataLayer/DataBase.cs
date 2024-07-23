using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataLayer
{
    public class DataBase : IDataBase
    {
        public bool CreateWorkersTable()
        {
            SqlCommand cmd = Get_CreateTableCmd();

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            return (int)cmd.Parameters["@res"].Value == 1;
        }

        public void CreateOneRecord(IWorker worker)
        {
            SqlCommand cmd = Get_CreateRecordCmd();
            cmd.Parameters["@FullName"].Value = worker.FullName;
            cmd.Parameters["@DateOfBirth"].Value = worker.DateOfBirth;
            cmd.Parameters["@Sex"].Value = worker.Sex;

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public void GetWorkers(IWorkersCollection workers)
        {
            SqlCommand cmd = Get_SelectUniqueWorkersCmd();
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                workers.Create($"{reader["FullName"]}", (DateTime)reader["DateOfBirth"], $"{reader["Sex"]}");
            }

            cmd.Connection.Close();
        }

        public void GetWorkers(IWorkersCollection workers, string nameExpression, string sex)
        {
            SqlCommand cmd = Get_SelectWorkersCmd();
            cmd.Parameters["@expr"].Value = nameExpression;
            cmd.Parameters["@sex"].Value = sex;

            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                workers.Create($"{reader["FullName"]}", (DateTime)reader["DateOfBirth"], $"{reader["Sex"]}");
            }
        }

        public void CreateRecordsSet(IWorker[] workers)
        {
            int dataPartSize = 100000;
            int partsCount = workers.Length / dataPartSize;

            for (int i = 0; i < partsCount; i++)
            {
                IWorker[] _workers = new IWorker[dataPartSize];
                Array.Copy(workers, i * dataPartSize, _workers, 0, dataPartSize);
                GetAndExecuteCmd(_workers);

                Console.WriteLine($" {i} часть данных отправлена.");
            }

            int remains = workers.Length % dataPartSize;
            if (remains > 0)
            {
                IWorker[] _workers = new IWorker[remains];
                Array.Copy(workers, partsCount * dataPartSize, _workers, 0, remains);
                GetAndExecuteCmd(_workers);
            }

            Console.WriteLine("Все данные успешно отправлены!");
        }

        private void GetAndExecuteCmd(IWorker[] workers)
        {
            SqlCommand cmd = Get_CreateRecordsCmd(workers);

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        private SqlCommand Get_CreateRecordCmd()
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Workers(FullName, DateOfBirth, Sex) VALUES(@FullName, @DateOfBirth, @Sex)");
            cmd.Parameters.Add(new SqlParameter("@FullName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "FullName", DataRowVersion.Current, null));
            cmd.Parameters.Add(new SqlParameter("@DateOfBirth", SqlDbType.Date, 0, ParameterDirection.Input, false, 0, 0, "DateOfBirth", DataRowVersion.Current, null));
            cmd.Parameters.Add(new SqlParameter("@Sex", SqlDbType.NVarChar, 6, ParameterDirection.Input, false, 0, 0, "Sex", DataRowVersion.Current, null));
            cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ptmkDb"].ConnectionString);
            return cmd;
        }

        private SqlCommand Get_CreateTableCmd()
        {
            SqlCommand cmd = new SqlCommand("IF OBJECT_ID('Workers', 'U') IS NULL " +
                "BEGIN CREATE TABLE Workers (FullName NVarChar(100) NOT NULL, DateOfBirth DATE NOT NULL, Sex NVarChar(6) NOT NULL) SET @res=1 END " +
                "ELSE BEGIN SET @res=-1 END");
            cmd.Parameters.Add(new SqlParameter("@res", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, null, DataRowVersion.Current, null));
            cmd.CommandType = CommandType.Text;
            cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ptmkDb"].ConnectionString);
            return cmd;
        }

        private SqlCommand Get_SelectUniqueWorkersCmd()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Workers WHERE " +
                "(FullName IN (SELECT FullName FROM Workers GROUP BY FullName, DateOfBirth HAVING COUNT(*)=1) AND " +
                "DateOfBirth IN (SELECT DateOfBirth FROM Workers GROUP BY FullName, DateOfBirth HAVING COUNT(*)=1))");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ptmkDb"].ConnectionString);
            return cmd;
        }

        private SqlCommand Get_SelectWorkersCmd()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Workers WHERE(FullName LIKE(@expr) AND Sex=@sex)");
            cmd.Parameters.Add(new SqlParameter("@expr", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, null));
            cmd.Parameters.Add(new SqlParameter("@sex", SqlDbType.NVarChar, 6, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, null));
            
            cmd.CommandType = CommandType.Text;
            cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ptmkDb"].ConnectionString);
            return cmd;
        }

        private SqlCommand Get_CreateRecordsCmd(IWorker[]workers)
        {
            int index = 0;
            int dataPartSize = 1000;
            int commandsCount = workers.Length / dataPartSize;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < commandsCount; i++)
            {
                sb.Append("INSERT INTO Workers(FullName, DateOfBirth, Sex) VALUES");
                for (int j = 0; j < dataPartSize; j++)
                {
                    IWorker w = workers[index];
                    sb.Append($"('{w.FullName}', '{w.DateOfBirth:O}', '{w.Sex}')");

                    if (j < dataPartSize - 1)
                        sb.Append(",");

                    index++;
                }

                sb.Append(";\r\n");
            }

            SqlCommand cmd = new SqlCommand(sb.ToString());
            cmd.CommandType = CommandType.Text;
            cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ptmkDb"].ConnectionString);
            cmd.CommandTimeout = 90;
            return cmd;
        }

    }
}
