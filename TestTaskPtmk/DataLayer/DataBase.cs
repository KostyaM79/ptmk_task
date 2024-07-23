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
