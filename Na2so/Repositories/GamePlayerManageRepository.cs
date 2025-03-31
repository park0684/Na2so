using Na2so.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Na2so.Repositories
{
    class GamePlayerManageRepository : BaseRepository, IGamePlayerManageRepository
    {
        public void GamePlayerUpdate(GamePlayerManageModel model)
        {
            int gameCode = (int)model.GameCode;
            string detetequery = "DELETE FROM attend WHERE att_code = @code";
            SqlParameter[] deleteParam = { new SqlParameter("@code", SqlDbType.Int) { Value = gameCode } };
            string insertQuery = "INSERT INTO attend (att_code, att_name, att_memcode, att_memtype) VALUES (@code, @name, @memCode, @memType)";
            
            using(SqlConnection connection = OpenSql())
            {
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    ExecuteNonQuery(detetequery, connection, transaction, deleteParam);
                    foreach (var player in model.PlayerList) 
                    {
                        SqlParameter[] insertParams =
                        {
                            new SqlParameter("@code", SqlDbType.Int) { Value = gameCode },
                            new SqlParameter("@name", SqlDbType.NVarChar) { Value = player.PalyerName },
                            new SqlParameter("@memCode", SqlDbType.Int) { Value = player.MemberCode },
                            new SqlParameter("@memType", SqlDbType.Int) { Value = player.MemberCode == 0 ? 2 : 1 }
                        };
                        ExecuteNonQuery(insertQuery, connection, transaction, insertParams);
                        
                    }
                    transaction.Commit();
                }

                catch(Exception ex)
                {

                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }

        }

        public DataTable LoadMember(GamePlayerManageModel model)
        {
            StringBuilder query = new StringBuilder();
            List<string> whereCondition = new List<string>();
            query.Append("SELECT mem_code, mem_name FROM member ");
            if(!string.IsNullOrEmpty(model.SearchWord))
            {
                whereCondition.Add($"mem_name LIKE '%{model.SearchWord}%'");
            }
            if(!model.SecessMember)
            {
                whereCondition.Add($"mem_status != 2");
            }

            if(whereCondition.Count > 0)
            {
                query.Append(" WHERE ");
                query.Append(string.Join(" AND ", whereCondition));
            }
            query.Append(" ORDER BY mem_name ");

            return SqlAdapterQuery(query.ToString());

        }

        public DataTable LoadPlayer(int gameCode)
        {
            string query = $"SELECT att_name, ISNULL(att_memcode,0) att_memcode FROM attend WHERE att_code = {gameCode} ";
            return SqlAdapterQuery(query);
        }
    }
}
