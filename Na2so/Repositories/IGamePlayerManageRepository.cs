using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Na2so.Models;

namespace Na2so.Repositories
{
    public interface IGamePlayerManageRepository
    {
        //플레이어로 등록 대상이 되는 회원 조회
        DataTable LoadMember(GamePlayerManageModel model);
        //게임에 기등록된 플레이어 
        DataTable LoadPlayer(int gameCode);
        //플레이어 리스트 등록 및 수정
        void GamePlayerUpdate(GamePlayerManageModel model);
    }
}
