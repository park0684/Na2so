using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Na2so.Views
{
    public interface IMemberListView
    {
        //Filed
        string SearchWord { get; set; }
        int? Status { get; set; }
        DateTime? AccFromDate { get; set; }
        DateTime? AccToDate { get; set; }
        DateTime? SecFromDate { get; set; }
        DateTime? SecToDate { get; set; }
        DateTime? GameFromDate { get; set; }
        DateTime? GameToDate { get; set; }
        bool ExcludeRegular { get; set; }
        bool ExcludeIrregular { get; set; }
        bool ExcludeEvent { get; set; }
        bool ExcludeMember { get; set; }
        bool AccessCheck { get; set; }
        bool SecessCheck { get; set; }
        bool GameCheck { get; set; }
        int? SelectedCode { get; }

        //
        event EventHandler SearchEvent;
        event EventHandler AddMember;
        event EventHandler LoadMember;

        //Method
        void SetMemberListBindingSource(BindingSource source);





    }
}
