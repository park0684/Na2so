using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Na2so.Models;

namespace Na2so.Repositories
{
    public interface IDuesManageRepository
    {
        DataTable LoadDuesStatementList(DuesManageModel model);
        DataTable LoadMemberList(DuesManageModel model);
        DataRow LoadBalance(DuesManageModel model);
        


    }
}
