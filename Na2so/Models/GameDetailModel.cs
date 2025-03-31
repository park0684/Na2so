using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Na2so.Models
{
    public class GameDetailModel
    {
        private int _gameCode;
        private int _gameType;
        private string _gameTilte;
        private string _gameHost;
        private string _gameMemo;
        private DateTime _gameDate;
        private bool _isNew;

        public int GameCode
        {
            get { return _gameCode; }
            set { _gameCode = value; }
        }
        public int GameType
        {
            get { return _gameType; }
            set { _gameType = value; }
        }
        public string GameTitle
        {
            get { return _gameTilte; }
            set { _gameTilte = value; }
        }
        public string GameHost
        {
            get { return _gameHost; }
            set { _gameHost = value; }
        }

        public string GameMemo
        {
            get { return _gameMemo; }
            set { _gameMemo = value; }
        }

        public DateTime GameDate
        {
            get { return _gameDate; }
            set { _gameDate = value; }
        }

        public bool IsNew
        {
            get { return _isNew; }
            set {_isNew = value; }
        }
    }
}
