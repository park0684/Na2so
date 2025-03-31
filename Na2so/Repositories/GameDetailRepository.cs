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
    class GameDetailRepository : BaseRepository, IGameDetailRepository
    {
        public void InsertGame(GameDetailModel model)
        {
            string query = "SELECT ISNULL(MAX(game_code),0) + 1 FROM game";
            int code = (int)ScalaQuery(query);

            query = "INSERT INTO game(game_code, game_title, game_host, game_date, game_type, game_memo) VALUES(@code, @title, @host, @date, @type, @memo)";
            SqlParameter[] parameters =
            {
                new SqlParameter ("@code",SqlDbType.Int){Value = code},
                new SqlParameter ("@title",SqlDbType.NVarChar){Value = model.GameTitle},
                new SqlParameter ("@host",SqlDbType.NVarChar){Value = model.GameHost},
                new SqlParameter ("@date",SqlDbType.Date){Value = model.GameDate.ToString("yyyy-MM-dd")},
                new SqlParameter ("@type",SqlDbType.Int){Value = model.GameType},
                new SqlParameter ("@memo",SqlDbType.NVarChar){Value = model.GameMemo},
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

        public DataRow LoadGameInfo(int code)
        {
            string query = $"SELECT game_title, game_host, game_date, game_type, game_memo FROM game WHERE game_code = {code}";
            DataTable result = SqlAdapterQuery(query);
            return result.Rows[0];
        }

        public void UPdateGame(GameDetailModel model)
        {
            string query = "UPDATE game SET game_title = @title, game_host = @code, game_date = @date, game_type = @type, game_memo = @memo WHERE game_code = @code ";
            SqlParameter[] parameters =
            {
                new SqlParameter ("@code",SqlDbType.Int){Value = model.GameCode},
                new SqlParameter ("@title",SqlDbType.NVarChar){Value = model.GameTitle},
                new SqlParameter ("@host",SqlDbType.NVarChar){Value = model.GameHost},
                new SqlParameter ("@date",SqlDbType.Date){Value = model.GameDate.ToString("yyyy-MM-dd")},
                new SqlParameter ("@type",SqlDbType.Int){Value = model.GameType},
                new SqlParameter ("@memo",SqlDbType.NVarChar){Value = model.GameMemo},
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
    }
}
