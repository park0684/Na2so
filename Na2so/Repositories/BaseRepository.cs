using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Na2so.Repositories
{
    class BaseRepository
    {
        private string _sqlConnectionstring;
        
        public SqlConnection OpenSql()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "127.0.0.1,49492";
            builder.UserID = "sa";
            builder.Password = "!gksmftkfkd1";
            builder.InitialCatalog = "na2so";
            _sqlConnectionstring = builder.ConnectionString;
            SqlConnection connectionDatabase = new SqlConnection(_sqlConnectionstring);
            connectionDatabase.Open();
            return connectionDatabase;
                
        }

        public DataTable SqlAdapterQuery(string query)
        {
            try
            {
                using (SqlConnection connection = OpenSql())
                {
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = new SqlCommand(query, connection);
                    dataAdapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void ExecuteNonQuery(string query, SqlConnection connection, SqlTransaction transaction, SqlParameter[] parameters)
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (transaction != null)
                {
                    command.Transaction = transaction;
                }
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                command.ExecuteNonQuery();
            }
        }

        public object ScalaQuery(string query)
        {
            try
            {
                using(SqlConnection connection = OpenSql())
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    return  command.ExecuteScalar();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
