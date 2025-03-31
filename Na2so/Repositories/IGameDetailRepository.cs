using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Na2so.Models;

namespace Na2so.Repositories
{
    public interface IGameDetailRepository
    {
        DataRow LoadGameInfo(int code);
        void InsertGame(GameDetailModel model);
        void UPdateGame(GameDetailModel model);
    }
}
