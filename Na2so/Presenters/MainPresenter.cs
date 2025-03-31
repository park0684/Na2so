using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Na2so.Views;
using Na2so.Repositories;
using Na2so.Models;
using System.Windows.Forms;

namespace Na2so.Presenters
{
    public class MainPresenter
    {
        
        private IMainView _view;

        public MainPresenter(IMainView view)
        {
            this._view = view;

            // 뷰의 이벤트를 핸들링하는 메서드 연결
            this._view.ShowMemberListView += (s, e) => view.btn_Click<MemberListView>(s, e);
            this._view.ShowGameListView += (s, e) => view.btn_Click<GameListView>(s, e);
            this._view.ShowDuesManageView += (s, e) => view.btn_Click<DuesManageView>(s, e);
        }
    }
}
