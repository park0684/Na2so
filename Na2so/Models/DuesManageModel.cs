using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Na2so.Models
{
    public class DuesManageModel
    {
        public int? DuesCode { get; set; }
        public string SearchWord { get; set; }
        public int? MemberCode { get; set; } 
        public bool SecessInclude { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public BindingList<MemberDueListModel> MemberList { get; set; } = new BindingList<MemberDueListModel>();
        public List<StatementListModel> StatementList { get; set; } = new List<StatementListModel>();

    }

    public class MemberDueListModel
    {
        public int No { get; set; }
        public int Code { get; set; }          
        public string Name { get; set; }       
        public int Payment { get; set; }       
        public int NonPayment { get; set; }    
    }

   
    public class StatementListModel
    {
        public int Code { get; set; }          // 회비 코드
        public DateTime Date { get; set; }     // 날짜
        public string Type { get; set; }       // 타입 (예: 회비, 기부금 등)
        public string Statement { get; set; }  // 명세
        public int Apply { get; set; }         // 적용 금액
        public int Deposit { get; set; }       // 입금 금액
        public int Withdrawal { get; set; }    // 출금 금액
        public int Balance { get; set; }       // 잔액
    }
}
