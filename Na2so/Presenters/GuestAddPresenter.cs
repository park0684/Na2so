using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Na2so.Models;
using Na2so.Views;


namespace Na2so.Presenters
{
    public class GuestAddPresenter
    {
        IGeustAddView _view;
        GuestAddModel _model;

        public GuestAddPresenter(IGeustAddView view)
        {
            _view = view;
            _model = new GuestAddModel();
            _view.AddGuestEvent += AddGuest;
            _view.SaveGuestEvent += SaveGuest;
            _view.CloseFormEvevnt += CloseForm;
        }

        private void CloseForm(object sender, EventArgs e)
        {
            _view.CloseForm();
        }

        private void AddGuest(object sender, EventArgs e)
        {
            _view.AddGuestPanel();
            _view.GuestName = "";
        }

        private void SaveGuest(object sender, EventArgs e)
        {
            var guestList = _view.GusetDate();

            _model.GuestList = guestList.Select(g => new PlayerInfoModel
            {
                PalyerName = g.Name,
                Gender = g.Gedner,
                IsPro = g.IsPro,
                Handycap = g.Handi,
                IsSelected = true,
                MemberCode = 0
            }).ToList();
            _view.CloseForm();

        }
        public List<PlayerInfoModel> getGuestList()
        {

            return _model.GuestList;
        }
    }
}
