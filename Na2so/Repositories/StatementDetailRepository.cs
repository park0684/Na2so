using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Na2so.Models;

namespace Na2so.Repositories
{
    class StatementDetailRepository : BaseRepository, IStatementDetailRepository
    {
        public void DeleteStatment(int statmentCode)
        {
            string query = "DELETE FROM dues WHERE du_code = @code";
            SqlParameter[] parameters = { new SqlParameter("@code", SqlDbType.Int) { Value = statmentCode } };
            using (SqlConnection connection = OpenSql())
            {
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    ExecuteNonQuery(query, connection, transaction, parameters);
                    transaction.Commit();
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        public void InsertStatment(StatementDetailModel model)
        {
            string query = "SELECT ISNULL(MAX(du_code),0) +1 FROM dues";
            int code = Convert.ToInt32(ScalaQuery(query));
            query = "INSERT INTO dues(du_code, du_date, du_type, du_pay, du_memcode, du_detail, du_memo, du_idate, du_udate) VALUES(@code, @date, @type, @amount, @memcode, @detail, @memo, GETDATE(), GETDATE())";
            SqlParameter[] parameters =
            {
                new SqlParameter("@code",SqlDbType.Int){Value = code },
                new SqlParameter("@date",SqlDbType.Date){Value = model.StatementDate},
                new SqlParameter("@type",SqlDbType.Int){Value = model.StatementType},
                new SqlParameter("@amount",SqlDbType.Int){Value = model.StatementAmount},
                new SqlParameter("@memcode",SqlDbType.Int){Value = model.MemberCode?? 0},
                new SqlParameter("@detail",SqlDbType.VarChar){Value = model.StatementDetail},
                new SqlParameter("@memo",SqlDbType.VarChar){Value = model.Memo}
            };
            using (SqlConnection connection = OpenSql())
            {
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    ExecuteNonQuery(query, connection, transaction, parameters);
                    transaction.Commit();
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public DataRow LoadStatmet(int statmentcode)
        {
            string query = $"SELECT du_date, du_apply, du_pay, du_memcode, du_type,  du_detail, du_memo FROM dues WHERE du_code = {statmentcode} ";
            
            return SqlAdapterQuery(query).Rows[0];
        }

        public void UpdateStatment(StatementDetailModel model)
        {
            string query = $"UPDATE dues SET du_date  = @date,  du_type  = @type, du_pay  = @amount, du_memcode = @memcode, du_detail = @detail, du_memo = @memo, du_udate = GETDATE() WHERE du_code ={model.StatementCode}";
            SqlParameter[] parameters =
            {
                new SqlParameter("@date",SqlDbType.Date){Value = model.StatementDate.ToString("yyyy-MM-dd")},
                new SqlParameter("@type", SqlDbType.Int) { Value = model.StatementType },
                new SqlParameter("@amount", SqlDbType.Int) { Value = model.StatementAmount },
                new SqlParameter("@memcode", SqlDbType.Int) { Value = model.MemberCode },
                new SqlParameter("@detail", SqlDbType.VarChar) { Value = model.StatementDetail },
                new SqlParameter("@memo", SqlDbType.VarChar) { Value = model.Memo }
            };
            using(SqlConnection connection = OpenSql())
            {
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    ExecuteNonQuery(query, connection, transaction, parameters);
                    transaction.Commit();
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
