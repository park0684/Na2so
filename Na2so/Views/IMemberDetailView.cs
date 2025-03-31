using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Na2so.Views
{
    public interface IMemberDetailView
    {
        string MemberName { get; set; }
        string Birth { get; set; }
        string Memo { get; set; }
        int? Status { get; set; }
        int? Position { get; set; }
        int? Gender { get; set; }
        DateTime? AccessDate { get; set; }
        DateTime? SecessDate { get; set; }



        //event
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;

        void CloseForm();
        void ShowMessage(string message);
    }
}
