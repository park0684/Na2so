using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Na2so.Models
{
    public class GameListModel
    {
        private DateTime _fromDate;
        private DateTime _toDate;
        private int _gameCode;
        private int _gameType;
        private bool _exculdeType;
        public DateTime FromDate
        {
            get { return _fromDate; }
            set { _fromDate = value; }
        }
        public DateTime ToDate
        {
            get { return _toDate; }
            set { _toDate = value; }
        }
        public int GameType
        {
            get { return _gameType; }
            set { _gameType = value; }
        }
        public int GameCode
        {
            get { return _gameCode; }
            set { _gameCode = value; }
        }
        public bool ExcludeType
        {
            get { return _exculdeType; }
            set { _exculdeType = value; }
        }
    }
}
