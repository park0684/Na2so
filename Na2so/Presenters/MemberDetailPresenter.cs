using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using Na2so.Models;
using Na2so.Views;
using Na2so.Repositories;


namespace Na2so.Presenters
{
    public class MemberDetailPresenter
    {
        private IMemberDetailView _view;
        private IMemebrDetailRepository _repository;
        private MemberDetailModel _model;

        public MemberDetailPresenter(IMemberDetailView view, IMemebrDetailRepository repository)
        {
            this._view = view;
            this._repository = repository;
            this._model = new MemberDetailModel();
            view.SaveEvent += SaveMember;
            view.CancelEvent += CancelAction;
            _model.IsNew = true;
        }

        public void LoadMemberInfo(int code)
        {

            DataRow row = _repository.LoadMemberInfo(code);


            _model.Code = code;
            _model.IsNew = false;
            _model.MemberName = row["mem_name"].ToString().Trim();
            _model.Status = Convert.ToInt32(row["mem_status"]);
            _model.Gender = Convert.ToInt32(row["mem_gender"]);
            _model.Position = Convert.ToInt32(row["mem_position"]);
            _model.Birth = row["mem_birth"].ToString().Trim();
            _model.Memo = row["mem_memo"].ToString().Trim();
            _model.AccessDate = (DateTime)row["mem_access"];
            _model.SecessDate = row["mem_secess"] == DBNull.Value ? DateTime.Now : (DateTime)row["mem_secess"];

            _view.MemberName = _model.MemberName;
            _view.Status = _model.Status;
            _view.Gender = _model.Gender;
            _view.Position = _model.Position;
            _view.Birth = _model.Birth;
            _view.Memo = _model.Memo;
            _view.AccessDate = _model.AccessDate;
            _view.SecessDate = _model.SecessDate;
        }

        
        public void CancelAction(object sender, EventArgs e)
        {
            _view.CloseForm();
        }

        private void SaveMember(object sender, EventArgs e)
        {
            bool isError = ValidateInput();
            if (isError)
                return;

            _model.MemberName = _view.MemberName;
            _model.Status = _view.Status ?? 0;
            _model.Gender = _view.Gender ?? 0;
            _model.Position = _view.Position ?? 0;
            _model.Birth = _view.Birth;
            _model.AccessDate = (DateTime)_view.AccessDate;
            _model.SecessDate = (DateTime)_view.SecessDate;
            _model.Memo = _view.Memo;
            try
            {
                if (_model.IsNew)
                {
                    _repository.Insert(_model);
                }
                else
                {
                    _repository.UpdateMember(_model);
                }
                _view.CloseForm();
            }
            catch(Exception ex)
            {
                _view.ShowMessage(ex.Message);
            }
        }
        private bool ValidateInput()
        {
            if(string.IsNullOrEmpty(_view.MemberName))
            {
                MessageBox.Show("회원명을 입력하세요");
                return true;
            }
            if(string.IsNullOrEmpty(_view.Birth))
            {
                MessageBox.Show("생년을 입력하세요");
                return true;
            }
            return false;
        }
    }
}
