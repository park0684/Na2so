using Na2so.Models;
using System;
using System.Data;
using System.Data.SqlClient;


namespace Na2so.Repositories
{
    class MemberDetailRepository : BaseRepository, IMemebrDetailRepository
    {
        public void Insert(MemberDetailModel model)
        {
            string query = "SELECT max(mem_code)+1 FROM member";
            DataTable result = SqlAdapterQuery(query);
            DataRow row = result.Rows[0];
            var code = row[0];
            query = "INSERT INTO MEMBER (mem_code, mem_name, mem_status, mem_birth, mem_gender, mem_position, mem_memo, mem_access)" +
                $"VALUES (@code, @name, @status, @birth, @gender, @position, @memo, @access)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@code",SqlDbType.Int){Value = code },
                new SqlParameter("@name",SqlDbType.NVarChar){Value = model.MemberName},
                new SqlParameter("@status",SqlDbType.Int){Value=model.Status },
                new SqlParameter("@birth",SqlDbType.NVarChar){Value=model.Birth },
                new SqlParameter("@gender",SqlDbType.Int){Value = model.Gender},
                new SqlParameter("@position", SqlDbType.Int){ Value = model.Position },
                new SqlParameter("@memo", SqlDbType.NVarChar){ Value = model.Memo },
                new SqlParameter("@access", SqlDbType.Date){Value = model.AccessDate.ToString("yyyy-MM-dd")}
            };
            using (SqlConnection connection = OpenSql())
            {
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    ExecuteNonQuery(query, connection, transaction, parameters);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
        public DataRow LoadMemberInfo(int value)
        {
            string query = $"SELECT mem_name, mem_birth, mem_gender, mem_status, mem_position, mem_access, mem_secess, mem_memo FROM member WHERE mem_code = {value}";
            DataTable result = SqlAdapterQuery(query);
            
            return result.Rows[0];
        }

        public void UpdateMember(MemberDetailModel model)
        {
            string query = $"UPDATE member SET mem_name = @name, mem_birth=@birth, mem_status = @status, mem_gender = @gender, mem_position = @position, mem_access = @access, mem_secess = @secess, mem_memo = @memo WHERE mem_code = @code";
            SqlParameter[] parameters =
            {
                new SqlParameter("@code",SqlDbType.Int){Value = model.Code },
                new SqlParameter("@name",SqlDbType.NVarChar){Value = model.MemberName},
                new SqlParameter("@status",SqlDbType.Int){Value=model.Status },
                new SqlParameter("@birth",SqlDbType.NVarChar){Value=model.Birth },
                new SqlParameter("@gender",SqlDbType.Int){Value = model.Gender},
                new SqlParameter("@position", SqlDbType.Int){ Value = model.Position },
                new SqlParameter("@memo", SqlDbType.NVarChar){ Value = model.Memo },
                new SqlParameter("@access", SqlDbType.Date){Value = model.AccessDate.ToString("yyyy-MM-dd")},
                new SqlParameter("@secess", SqlDbType.Date){Value = model.SecessDate.ToString("yyyy-MM-dd")}
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
            }

        }
    }
}
