using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Na2so.Helpers;
using Na2so.Models;
using Na2so.Repositories;
using Na2so.Views;
using System.Windows.Forms;

namespace Na2so.Presenters
{
    public class GamePlayerManagePresenter
    {
        IGamePlayerManageView _view;
        IGamePlayerManageRepository _repository;
        GamePlayerManageModel _model;

        public GamePlayerManagePresenter(IGamePlayerManageView view, IGamePlayerManageRepository repository)
        {
            this._view = view;
            this._repository = repository;
            this._model = new GamePlayerManageModel();
            this._view.SearchMemberEvent += SearchMember;
            this._view.PlayerUpdateEvent += PlayerUpdate;
            this._view.PlayerAddEvent += PlayerAdd;
            this._view.PlayerRemoveEvent += PlayerRemove;
            this._view.SavePlayerListEvent += PlayerUpdate;
            this._view.CloseEvent += CloseForm;
            this._view.AddGuestEvent += GuestAdd;
            
            //LoadPlayer();
        }

        private void GuestAdd(object sender, EventArgs e)
        {
            IGeustAddView view = new GuestAddView();
            GuestAddPresenter presenter = new GuestAddPresenter(view);
            Form form = (Form)view;
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
            _model.PlayerList.AddRange(presenter.getGuestList());
            _view.SetPlayerList(_model.PlayerList);
        }

        private void CloseForm(object sender, EventArgs e)
        {
            _view.CloseForm();
        }

        private void PlayerRemove(object sender, Button clickedButton)
        {
            string memberName = clickedButton.Text;
            int memberCode = (int)clickedButton.Tag;

            var playerToRemove = _model.PlayerList.FirstOrDefault(p => p.MemberCode == memberCode && p.PalyerName == memberName);
            if(playerToRemove != null)
            {
                _model.PlayerList.Remove(playerToRemove);
                if (memberCode != 0)
                    _view.UpdateButtonColor(memberCode, false);
                _view.SetPlayerList(_model.PlayerList);
            }
        }

        private void PlayerAdd(object sender, Button clickedButton)
        {
            var memName = clickedButton.Text;
            int memCode = (int)clickedButton.Tag;
            if (_model.PlayerList.Any(p => p.MemberCode == memCode))
            {
                return;        
            }

            _model.PlayerList.Add(new PlayerInfoModel
            {
                MemberCode = memCode,
                PalyerName = memName
            });
            _view.UpdateButtonColor(memCode, true);
            _view.SetPlayerList(_model.PlayerList);
        }
        public void PlayerManageCall(int gamecode)
        {
            _model.GameCode = gamecode;
            LoadPlayer(gamecode);
            LoadMember();
        }

        private void PlayerUpdate(object sender, EventArgs e)
        {
         
            _repository.GamePlayerUpdate(_model);
            _view.CloseForm();
        }

        private void SearchMember(object sender, EventArgs e)
        {
            _model.SearchWord = _view.SearchWord;
            _model.SecessMember = _view.SecessMember;
            LoadMember();
        }

        private void LoadMember()
        {
            DataTable resutl =  _repository.LoadMember(_model);
            List<PlayerInfoModel> memberList = resutl.AsEnumerable().Select(row => new PlayerInfoModel
            {
                MemberCode = row.Field<int>("mem_code"),
                PalyerName = row.Field<string>("mem_name"),
                IsSelected = _model.PlayerList.Any(p => p.MemberCode == row.Field<int>("mem_code"))
            }).ToList();
            _model.MemberList = memberList;
            _view.SetMemberList(_model.MemberList);
        }
        public void LoadPlayer(int code)
        {
            DataTable result = _repository.LoadPlayer(code);
            List<PlayerInfoModel> playerList = result.AsEnumerable().Select(row => new PlayerInfoModel    
            {
                MemberCode = row.Field<int>("att_memcode"),
                PalyerName = row.Field<string>("att_name"),
                IsSelected = true
            }).ToList();
            _model.PlayerList = playerList;
            _view.SetPlayerList(_model.PlayerList);
        }
    }
}
