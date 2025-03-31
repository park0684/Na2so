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

namespace Na2so.Presenters
{
    class GameDetailPresenter
    {
        private IGameDetailView _view;
        private IGameDetailRepository _repository;
        private GameDetailModel _model;
        

        public GameDetailPresenter(IGameDetailView view, IGameDetailRepository repository)
        {
            this._view = view;
            this._repository = repository;
            this._model = new GameDetailModel();
            this._view.CloseEvenvt += CloseAction;
            this._view.SaveEvent += SaveGame;
            _model.IsNew = true;
        }

        public void LoadGame(int code)
        {
            DataRow row = _repository.LoadGameInfo(code);
            
            _model.GameCode = code;
            _model.IsNew = false;
            _model.GameTitle = row["game_title"].ToString();
            _model.GameHost = row["game_host"].ToString();
            _model.GameMemo = row["game_memo"].ToString();
            _model.GameDate = (DateTime)row["game_date"];
            _model.GameType = (int)row["game_type"];

            _view.GameTitle = _model.GameTitle;
            _view.GameHost = _model.GameHost;
            _view.GameMemo = _model.GameMemo;
            _view.GameDate = _model.GameDate;
            _view.GameType = _model.GameType;
        }
        private void SaveGame(object sender, EventArgs e)
        {
            _model.GameTitle = _view.GameTitle;
            _model.GameHost = _view.GameHost;
            _model.GameDate = _view.GameDate;
            _model.GameType = _view.GameType;
            _model.GameMemo = _view.GameMemo;
            
            if(_model.IsNew)
            {
                _repository.InsertGame(_model);
            }
            else
            {
                _repository.UPdateGame(_model);
            }
            _view.CloseForm();
        }

        private void CloseAction(object sender, EventArgs e)
        {
            _view.CloseForm();
        }
    }
}
