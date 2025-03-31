using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Na2so.Models;
using Na2so.Repositories;
using Na2so.Views;
using Na2so.Helpers;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace Na2so.Presenters
{
    class GameListPresenter
    {
        private IGameListView _view;
        private GameListRepository _repository;
        private BindingSource gameBindingSource;
        private BindingSource playerBindingSource;

        public GameListPresenter(IGameListView view)
        {
            this._view = view;
            this._repository = new GameListRepository();
            this.gameBindingSource = new BindingSource();
            this.playerBindingSource = new BindingSource();
            //뷰이벤트 핸들러 설정
            this._view.EditGameEvent += EditGame;
            this._view.AddGameEvent += AddGame;
            this._view.SearchGameEvent += SearchGame;
            this._view.SearchPlayerEvent += SearchPlayerList;
            this._view.EditPlayerEvent += EidtPlayerList;
            this._view.SetGameListBinding(gameBindingSource);
            this._view.SetPlayerListBinding(playerBindingSource);
            LoadGameList();
        }

        

        private void LoadGameList()
        {
            try
            {
                GameListModel _model = new GameListModel();
                _model.FromDate = _view.GameFromDate;
                _model.ToDate = _view.GameToDate;
                _model.GameType = _view.GameType ?? 0;
                _model.ExcludeType = _view.ExcludeType;

                DataTable result = _repository.LoadGameList(_model);
                result.Columns.Add("No");
                int i = 1;
                foreach(DataRow row in result.Rows)
                {
                    row["No"] = i++;
                }

                gameBindingSource.DataSource = result;
                _view.SetGameListBinding(gameBindingSource);
            }
            catch (Exception ex)
            {
                _view.ShowMessage(ex.Message);
            }
        }
        private void LoadPlayerList(int code)
        {
            try
            {
                DataTable players = _repository.LoadPlayerList(code);
                players.Columns.Add("No");
                players.Columns.Add("gender");
                players.Columns.Add("memberType");
                int i = 1;
                foreach (DataRow row in players.Rows)
                {
                    row["No"] = i++;
                    row["gender"] = MemberHelper.GetMemberGenger(Convert.ToInt32(row["mem_gender"]));
                    row["memberType"] = GameHelper.GetPlayerType(Convert.ToInt32(row["att_memtype"]));
                }

                players.Columns.Remove("mem_gender");
                players.Columns.Remove("att_memtype");
                playerBindingSource.DataSource = players;
                _view.SetPlayerListBinding(playerBindingSource);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void SearchPlayerList(object sender, EventArgs e)
        {
            try
            {
                int code = _view.GetGameCode ?? 0;
                if(code <= 0)
                {
                    _view.ShowMessage("조회된 모임이 없습니다.");
                    return;
                }
                LoadPlayerList(code);
            }
            catch(Exception ex)
            {
                _view.ShowMessage(ex.Message);
            }
        }
        
        private void SearchGame(object sender, EventArgs e)
        {
            LoadGameList();
        }
        private void EidtPlayerList(object sender, EventArgs e)
        {
            int code = _view.GetGameCode.Value;
            IGamePlayerManageView view = new GamePlayerManageView();
            IGamePlayerManageRepository repository = new GamePlayerManageRepository();
            GamePlayerManagePresenter presenter = new GamePlayerManagePresenter(view, repository);
            presenter.PlayerManageCall(code);
            Form form = (Form)view;
            form.StartPosition = FormStartPosition.Manual;
            form.ShowDialog();
            LoadPlayerList(code);
        }

        private void AddGame(object sender, EventArgs e)
        {
            IGameDetailView view = new GameDetailView();
            IGameDetailRepository repository = new GameDetailRepository();
            new GameDetailPresenter(view, repository);
            Form form = (Form)view;
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
            LoadGameList();
        }

        private void EditGame(object sender, EventArgs e)
        {
            int code = _view.GetGameCode.Value;
            IGameDetailView view = new GameDetailView();
            IGameDetailRepository repository = new GameDetailRepository();
            GameDetailPresenter presenter = new GameDetailPresenter(view, repository);
            presenter.LoadGame(code);
            Form form = (Form)view;
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
            LoadGameList();

        }
    }
}
