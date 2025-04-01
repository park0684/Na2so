using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Na2so.Models;

namespace Na2so.Repositories
{
    class MemberListRepository : BaseRepository
    {
        public string SetQuery(MemberListModel model)
        {
            //회원검색 query는 회원, 정기전 참석, 비정기전 참석, 이벤트전 참석, 회비납부 현황을 각각 FROM에서 구한 후 LEFT OUTER JOIN으로 연결
            //

            StringBuilder query = new StringBuilder();
            
            query.Append("SELECT mem_code, mem_name ,mem_birth, mem_gender,mem_position, ISNULL(game_regular.att_count,0) reglar_count, ");
            query.Append(" ISNULL(game_irregular.att_count, 0) irregular_count, ISNULL(game_event.att_count, 0) event_count,(SELECT COUNT(game_code) FROM game WHERE game_type = 1 AND game_date >= mem_access) game_count ,mem_access, mem_secess, mem_status, ");
            query.Append("ISNULL((SELECT MAX(game_date) FROM attend, game WHERE att_code = game_code AND att_name = mem_name),NULL) game_last,");
            query.Append("CAST(DATEDIFF(MONTH,CASE WHEN mem_access < '2025-02-01' THEN '2025-02-01'  ELSE mem_access END ,GETDATE()) as INT) + 1 mem_dues,ISNULL(payment, 0) payment, mem_memo FROM ");
            //회원 검색 구간
            query.Append("(SELECT mem_code, mem_name ,mem_birth, mem_gender, mem_position, mem_access, mem_secess, mem_status,");
            query.Append(" CAST(DATEDIFF(MONTH,CASE WHEN mem_access < '2025-02-01' THEN '2025-02-01'  ELSE mem_access END,");
            query.Append($"'{DateTime.Now.ToString("d")}') as INT) + 1 [mem_duse], mem_memo FROM member \n");

            List<string> whereCondition = new List<string>();
            if (!string.IsNullOrEmpty(model.SearchWord))
                whereCondition.Add($"mem_name LIKE '%{model.SearchWord}%'");
            if (model.Status != 0)
                if (model.ExcludeMember)
                {
                    whereCondition.Add($"mem_status != {model.Status}");
                }
                else 
                { whereCondition.Add($"mem_status = {model.Status}");}
            if (model.AccessCheck)
                whereCondition.Add($"mem_access >  '{ model.AccFromDate.Value.ToString("yyyy-MM-dd")}' AND mem_access < '{model.AccToDate.Value.AddDays(1).ToString("yyyy-MM-dd")}'");
            if (model.SecessCheck)
                whereCondition.Add($"mem_secess >  '{ model.SecFromDate.Value.ToString("yyyy-MM-dd")}' AND mem_secess < '{model.SecToDate.Value.AddDays(1).ToString("yyyy-MM-dd")}'");
            if (whereCondition.Count > 0)
            {
                query.Append(" WHERE ");
                query.Append(string.Join(" AND ", whereCondition));
            }
            query.Append(") as member LEFT OUTER JOIN \n");

            string gameDate = $"game_date > '2023-12-31' AND game_date < '{DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")}' AND ";
            if (model.GameCheck)
            {
                gameDate = $" game_date > '{model.GameFromDate.Value.ToString("yyyy-MM-dd")}' AND game_date < '{model.GameTodate.Value.AddDays(1).ToString("d")}' AND ";
                query.Replace("WHERE game_type = 1 AND game_date >= mem_access) gmae_count", $"WHERE {gameDate} game_type = 1 ) game_count");
            }

            // 정기전 참석 현황 집계
            if (!model.ExcludeRegular)
            {
                query.Append(GetGameQuery(1, gameDate));
                query.Append("as game_regular ON mem_code = game_regular.att_memcode LEFT OUTER JOIN \n");
            }
            else
            {
                query.Replace(" ISNULL(game_regular.att_count,0) reglar_count", " 0 reglar_count");
            }
            // 비정기전 참석 현황 집계
            if(!model.ExcludeIrregular)
            {
                query.Append(GetGameQuery(2, gameDate));
                query.Append("as game_irregular ON mem_code = game_irregular.att_memcode LEFT OUTER JOIN \n");
            }
            else
            {
                query.Replace(" ISNULL(game_irregular.att_count, 0) irregular_count", " 0 irreglar_count");
            }
            // 이벤트전 참석 현황 집계
            if (!model.ExcludeEvent)
            {
                query.Append(GetGameQuery(3, gameDate));
                query.Append("as game_event ON mem_code = game_event.att_memcode LEFT OUTER JOIN \n");
            }
            else
            {
                query.Replace(" ISNULL(game_event.att_count, 0) event_count", " 0 event_count");
            }
            
            //회비 납부 현황 집계
            query.Append("(select du_memcode, sum(du_apply) as payment FROM dues WHERE du_status = 1 GROUP BY du_memcode) as dues ON mem_code = du_memcode");

            //정렬 
            query.Append(" ORDER BY mem_position, mem_status, mem_code");

            return query.ToString();
        }
        public string GetGameQuery(int type, string gameDate )
        {
            string query = "(SELECT att_memcode, COUNT(att_name) att_count FROM attend, game WHERE ";
            if (!gameDate.Equals("N/A"))
            {
                query += gameDate;
            }
            query += $" game_type = {type} AND att_code = game_code GROUP BY att_memcode)";
            return query;

        }
        public DataTable GetMemberList(MemberListModel model)
        {
            List<string> whereCondition = new List<string>();
            DataTable result;
            using (SqlConnection connection = OpenSql())
            {
                string query = SetQuery(model);
                result = SqlAdapterQuery(query);
            }
            return result;
        }
    }
}
