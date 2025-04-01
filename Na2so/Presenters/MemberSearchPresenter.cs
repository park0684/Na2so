using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Na2so.Models;
using Na2so.Repositories;
using Na2so.Views;

namespace Na2so.Presenters
{
    public class MemberSearchPresenter
    {
        private IMemberSearchView _view;
        private IMemberSearchRepository _repository;
        private MemberSearchModel _model;
        private IMemberSelectCallback _callback;
        public MemberSearchPresenter(IMemberSearchView view, IMemberSearchRepository repository,IMemberSelectCallback callback)
        {
            _view = view;
            _repository = repository;
            _callback = callback;

            _view.CloseFormEvent += CloseAction;
            _view.MemberSeachEvent += MemberSearch;
            _view.SelectMemberEvent += SelectMember;
            _model = new MemberSearchModel();
            MemberSearch(this, EventArgs.Empty);
        }

        private void SelectMember(object sender, EventArgs e)
        {
            int code = _view.MemberCode;
            string name = _view.MemberName;
            _callback?.OnMemberSelected(code, name);
            _view.CloseForm();
        }

        private void MemberSearch(object sender, EventArgs e)
        {
            _model.SearchWord = _view.SearchWord;
            _model.IsInclude = _view.IsInculde;
            DataTable resutl = _repository.LoadMember(_model);
            _model.MemberList = new List<(int code, string name)>();
            foreach(DataRow row in resutl.Rows)
            {
                int code = (int)row["mem_code"];
                string name = row["mem_name"].ToString();
                _model.MemberList.Add((code, name));
            }
            _view.SetMemberList(_model.MemberList);
        }

        private void CloseAction(object sender, EventArgs e)
        {
            _view.CloseForm();
        }
    }
}
