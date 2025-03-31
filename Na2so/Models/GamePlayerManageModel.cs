using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Na2so.Models
{
    public class GamePlayerManageModel
    {
        private string _searchWord;
        private bool _secessMember;
        private int? _gameCode;
        

        public string SearchWord
        {
            get { return _searchWord; }
            set { _searchWord = value; }
        }

        public bool SecessMember
        {
            get { return _secessMember; }
            set { _secessMember = value; }
        }

        public int? GameCode
        {
            get { return _gameCode; }
            set { _gameCode = value; }
        }

        public List<PlayerInfoModel> PlayerList { get; set; } = new List<PlayerInfoModel>();
        public List<PlayerInfoModel> MemberList { get; set; } = new List<PlayerInfoModel>();
    }
}
