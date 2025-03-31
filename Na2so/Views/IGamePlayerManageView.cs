using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Na2so.Models;
namespace Na2so.Views
{
    public interface IGamePlayerManageView
    {
        string SearchWord { get; set; }
        bool SecessMember { get; set; }
        
        event EventHandler SearchMemberEvent;
        event EventHandler PlayerUpdateEvent;
        event EventHandler<Button> PlayerAddEvent;
        event EventHandler<Button> PlayerRemoveEvent;
        event EventHandler SavePlayerListEvent;
        event EventHandler CloseEvent;
        event EventHandler AddGuestEvent;
        void UpdateButtonColor(int memberCode, bool isAdded);

        void SetMemberList(List<PlayerInfoModel> members);
        void SetPlayerList(List<PlayerInfoModel> players);
        void CloseForm();
    }
}
