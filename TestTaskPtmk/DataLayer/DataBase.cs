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
    }
}
