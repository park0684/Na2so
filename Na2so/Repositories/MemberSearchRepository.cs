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
            string query = $"SELECT mem_code, mem_name FROM member WHERE mem_name LIKE '%{model.SearchWord}%'";
            return SqlAdapterQuery(query);
        }
    }
}
