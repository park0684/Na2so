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
    class DuesManageRepository : BaseRepository, IDuesManageRepository
    {
        public DataRow LoadBalance(DuesManageModel model)
        {
            string query = $"SELECT ISNULL(SUM(CASE WHEN du_type = 1 THEN ISNULL(du_pay, 0) ELSE 0 END),0) AS deus, ISNULL(SUM(CASE WHEN du_type = 2 THEN ISNULL(du_pay, 0) ELSE 0 END),0) AS payment FROM dues WHERE du_date < '{model.FromDate.ToString("yyyy-MM-dd")}'";

            return SqlAdapterQuery(query).Rows[0];
        }

        public DataTable LoadDuesStatementList(DuesManageModel model)
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT du_code, du_date, du_type, du_name , du_apply, du_pay as deposit, 0 whthdrawal FROM dues");
            query.Append($" WHERE du_type = 1 AND du_date > '{model.FromDate.ToString("yyyy-MM-dd")}' AND du_date < '{model.ToDate.AddDays(1).ToString("yyyy-MM-dd")}'");
            if (model.MemberCode != 0)
                query.Append($" AND du_memcode = {model.MemberCode}");
            query.Append("\nUNION\nSELECT du_code, du_date, du_type, du_memo , 0, 0 as deposit, du_pay whthdrawal FROM dues");
            query.Append($" WHERE du_type = 2 AND du_date > '{model.FromDate.ToString("yyyy-MM-dd")}' AND du_date < '{model.ToDate.AddDays(1).ToString("yyyy-MM-dd")}'");
            if (model.MemberCode != 0)
                query.Append($" AND du_memcode = {model.MemberCode}");
            query.Append("ORDER BY du_date, du_code");
            return SqlAdapterQuery(query.ToString());
        }

        public DataTable LoadMemberList(DuesManageModel model)
        {
            StringBuilder query = new StringBuilder();
            List<string> whereCondition = new List<string>();
            query.Append("SELECT mem_code, mem_name, mem_birth, ISNULL(payment,0) payment, DATEDIFF(m,CASE WHEN mem_access < '2025-02-01' THEN '2025-02-01' ELSE mem_access END, GETDATE())+1 duecount  FROM member LEFT OUTER JOIN ");
            query.Append("(SELECT du_memcode , SUM(du_apply) payment FROM dues WHERE du_type = 1 GROUP BY du_memcode) as dues ON  mem_code = du_memcode");
            if(!string.IsNullOrEmpty(model.SearchWord))
            {
                whereCondition.Add($"mem_name LIKE '%{model.SearchWord}%'");
            }
            if(!model.SecessInclude)
            {
                whereCondition.Add($"mem_status != 2");
            }
            if(whereCondition.Count >0)
            {
                query.Append(" Where ");
                query.Append(string.Join(" and ", whereCondition));
            }
            return SqlAdapterQuery(query.ToString());
        }
    }
}
