using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Na2so.Views
{
    public interface IGeustAddView
    {
        string GuestName { get; set; }
        List<(string Name, bool Gedner, bool IsPro, int Handi)> GusetDate();
        event EventHandler AddGuestEvent;
        event EventHandler SaveGuestEvent;
        event EventHandler CloseFormEvevnt;

        void CloseForm();
        void AddGuestPanel();
        void TextBoxClear();

    }
}
