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
    class GameListRepository : BaseRepository, IGameListRepository
    {
        public DataTable LoadGameList(GameListModel model)
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT game_code, game_date, game_type, game_title, game_host, ");
            query.Append("COUNT(att_code) as totalplayer, COUNT(CASE WHEN att_memtype = 1 THEN 1 END) as member, COUNT( CASE WHEN att_memtype = 2 THEN 1 END) as guest ");
            query.Append("FROM game LEFT OUTER JOIN attend ON game_code =att_code WHERE");
            query.Append($" game_date > '{model.FromDate.ToString("yyyy-MM-dd")}' AND game_date < '{model.ToDate.AddDays(1).ToString("yyyy-MM-dd")}'");

            if(model.GameType != 0 )
            {
                if (model.ExcludeType)
                {
                    query.Append($" AND game_type != {model.GameType}");
                }
                else
                {
                    query.Append($" AND game_type = {model.GameType}");
                }
            }
            query.Append(" GROUP BY game_code, game_date, game_type, game_title, game_host ORDER BY game_date, game_code");
            try
            {
                return SqlAdapterQuery(query.ToString());
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }


        public DataTable LoadPlayerList(int code)
        {
            string query =($"SELECT att_name,  ISNULL(mem_birth,'') mem_birth, ISNULL(mem_gender,'') mem_gender, att_memtype FROM attend LEFT JOIN member ON att_memcode = mem_code  WHERE att_code = {code}");
            try
            {
                return SqlAdapterQuery(query);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
