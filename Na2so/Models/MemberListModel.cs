using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Na2so.Models
{
    public class MemberListModel
    {

        private string searchWord;
        private int? status;
        private DateTime? accFromDate;
        private DateTime? accToDate;
        private DateTime? secFromDate;
        private DateTime? secTodDate;
        private DateTime? gameFromDate;
        private DateTime? gameToDate;
        private bool excludRegular;
        private bool excludIrregular;
        private bool excludEvent;
        private bool execudMember;
        private bool accessCheck;
        private bool secessCheck;
        private bool gameCheck;

        public string SearchWord { get { return searchWord; } set { searchWord = value; } }
        public int? Status { get { return status; } set { status = value; } }
        public DateTime? AccFromDate { get { return accFromDate; } set { accFromDate = value; } }
        public DateTime? AccToDate { get { return accToDate; } set { accToDate = value; } }
        public DateTime? SecFromDate { get { return secFromDate; } set { secFromDate = value; } }
        public DateTime? SecToDate { get { return secTodDate; } set { secTodDate = value; } }
        public DateTime? GameFromDate { get { return gameFromDate; } set { gameFromDate = value; } }
        public DateTime? GameTodate { get { return gameToDate; } set { gameToDate = value; } }
        public bool ExcludeRegular { get { return excludRegular; } set { excludRegular = value; } }
        public bool ExcludeIrregular { get { return excludIrregular; } set { excludIrregular = value; } }
        public bool ExcludeEvent { get { return excludEvent; } set { excludEvent = value; } }
        public bool ExcludeMember { get { return execudMember; } set { execudMember = value; } }
        public bool AccessCheck { get { return accessCheck; } set { accessCheck = value; } }
        public bool SecessCheck { get { return secessCheck; } set { secessCheck = value; } }
        public bool GameCheck { get { return gameCheck; } set { gameCheck = value; } }
    }
}
