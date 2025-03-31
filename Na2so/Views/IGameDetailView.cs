using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Na2so.Views
{
    public interface IGameDetailView
    {
        string GameTitle { get; set; }
        string GameHost { get; set; }
        string GameMemo { get; set; }
        DateTime GameDate { get; set; }
        int GameType { get; set; }

        //
        event EventHandler SaveEvent;
        event EventHandler CloseEvenvt;

        void CloseForm();
    }
}
