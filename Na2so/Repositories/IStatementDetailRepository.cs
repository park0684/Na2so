using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Na2so.Models;

namespace Na2so.Repositories
{
    public interface IStatementDetailRepository
    {
        void InsertStatment(StatementDetailModel model);
        void UpdateStatment(StatementDetailModel model);
        void DeleteStatment(int statmentCode);
        DataRow LoadStatmet(int statmentcode);
    }
}
