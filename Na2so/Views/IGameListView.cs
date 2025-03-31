using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Na2so.Views
{
    public interface IGameListView
    {
        DateTime GameFromDate { get; set; }
        DateTime GameToDate { get; set; }
        int? GameType { get; set; }
        bool ExcludeType { get; set; }
        int? GetGameCode { get; }
        string GameTile { get; }

        //이벤트
        event EventHandler SearchGameEvent;
        event EventHandler AddGameEvent;
        event EventHandler EditGameEvent;
        event EventHandler SearchPlayerEvent;
        event EventHandler EditPlayerEvent;

        //메소드
        void SetGameListBinding(BindingSource source);
        void SetPlayerListBinding(BindingSource source);
        void ShowMessage(string message);
    }
}
