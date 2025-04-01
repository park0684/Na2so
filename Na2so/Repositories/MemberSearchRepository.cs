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
    class MemberSearchRepository : BaseRepository, IMemberSearchRepository
    {
        public DataTable LoadMember(MemberSearchModel model )
        {
            StringBuilder query = new StringBuilder();
            List<string> whereCondition = new List<string>();
            query.Append($"SELECT mem_code, mem_name FROM member ");
            if (!string.IsNullOrEmpty(model.SearchWord))
                whereCondition.Add($"mem_name LIKE '%{model.SearchWord}%'");
            if (!model.IsInclude)
                whereCondition.Add("mem_status != 2");
            if (whereCondition.Count > 0)
                query.Append(" WHERE ");
                query.Append(string.Join(" AND ", whereCondition));
            query.Append(" ORDER BY mem_name");

            return SqlAdapterQuery(query.ToString());
        }
    }
}
