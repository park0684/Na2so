using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Na2so.Views
{
    public interface IMemberSearchView
    {
        string SearchWord { get; set; }
        int MemberCode { get;}
        bool IsInculde { get; set; }
        string MemberName { get; }
        event EventHandler MemberSeachEvent;
        event EventHandler SelectMemberEvent;
        event EventHandler CloseFormEvent;

        void CloseForm();

        void SetMemberList(List<(int code, string name)> members);
        void ShowView();
        void ShowMessage(string message);
    }
}
