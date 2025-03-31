using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Na2so.Views
{
    public interface IDuesManageView
    {
        string SearchWord { get; set; }
        DateTime FromDate { get; set; }
        DateTime ToDate { get; set; }
        bool SecessInclude { get; set; }
        int? GetMemberCode { get; }
        int? GetStateMentCode { get; }

        event EventHandler MemberSearchEvent;
        event EventHandler StatementSearchEvent;
        event EventHandler StatementAddEvent;
        event EventHandler StatementEditEvent;

        void SetMemberListBinding(BindingSource source);
        void SetStateListBinding(BindingSource source);
    }
}
