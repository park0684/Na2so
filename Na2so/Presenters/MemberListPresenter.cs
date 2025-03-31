using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Na2so.Views;
using Na2so.Models;
using Na2so.Repositories;
using Na2so.Helpers;
using System.Windows.Forms;

namespace Na2so.Presenters
{
    public class MemberListPresenter
    {
        private IMemberListView _view;
        private MemberListRepository _repository;
        

        public MemberListPresenter(IMemberListView view)
        {
            this._view = view;
            this._repository = new MemberListRepository();
            //뷰이벤트 핸들러 설정
            this._view.SearchEvent += SearchMember;
            this._view.AddMember += AddNewMember;
            this._view.LoadMember += LoadMember;

        }

        private void AddNewMember(object sender, EventArgs e)
        {
            IMemberDetailView view = new MemberDetailView();
            IMemebrDetailRepository repository = new MemberDetailRepository();
            new MemberDetailPresenter(view, repository);
            Form memberDetailView = (Form)view;
            memberDetailView.StartPosition = FormStartPosition.CenterParent;
            memberDetailView.ShowDialog();
        }

        private void LoadMember(object sender, EventArgs e)
        {
            int code = _view.SelectedCode.Value;
            IMemberDetailView view = new MemberDetailView();
            IMemebrDetailRepository repository = new MemberDetailRepository();
            //MemberDetailModel model = new MemberDetailModel { IsNew = false, Code = code };
            MemberDetailPresenter presenter = new MemberDetailPresenter(view, repository);
            presenter.LoadMemberInfo(code);

            Form memberDetailView = (Form)view;
            memberDetailView.StartPosition = FormStartPosition.CenterParent;
            memberDetailView.ShowDialog();
        }

        private void SearchMember(object sender, EventArgs e)
        {
            var model = new MemberListModel();
            model.Status = _view.Status;
            model.SearchWord = _view.SearchWord;
            model.AccessCheck = _view.AccessCheck;
            model.AccFromDate = _view.AccFromDate;
            model.AccToDate = _view.AccToDate;
            model.SecessCheck = _view.SecessCheck;
            model.SecFromDate = _view.SecFromDate;
            model.SecToDate = _view.SecToDate;
            model.GameCheck = _view.GameCheck;
            model.GameFromDate = _view.GameFromDate;
            model.GameTodate = _view.GameToDate;
            model.ExcludeMember = _view.ExcludeMember;
            model.ExcludeRegular = _view.ExcludeRegular;
            model.ExcludeIrregular = _view.ExcludeIrregular;
            model.ExcludeEvent = _view.ExcludeEvent;
            DataTable result = _repository.GetMemberList(model);
            if (result == null || result.Rows.Count == 0 )
                return;

            int i = 1;
            result.Columns.Add("No");
            result.Columns.Add("status");
            result.Columns.Add("position");
            result.Columns.Add("gender");
            result.Columns.Add("regularRate");
            result.Columns.Add("nonPayment");
            foreach (DataRow row in result.Rows)
            {
                row["No"] = i++; 
                row["status"] = MemberHelper.GetMemberStatus(Convert.ToInt32(row["mem_status"]));
                row["gender"] = MemberHelper.GetMemberGenger(Convert.ToInt32(row["mem_gender"]));
                row["position"] = MemberHelper.GetMemberPositon(Convert.ToInt32(row["mem_position"]));
                int nonPayment = Convert.ToInt32(row["mem_dues"]) - Convert.ToInt32(row["Payment"]);
                row["nonPayment"] = nonPayment < 0 ? 0 : nonPayment;
                decimal rate = DataConvertHelper.ConvertRate(row["game_count"], row["reglar_count"]);
                row["regularRate"] = rate;
            }
            result.Columns.Remove("mem_status");
            result.Columns.Remove("mem_gender");
            result.Columns.Remove("mem_position");
            result.Columns.Remove("game_count");
            result.Columns.Remove("mem_dues");
            result.AcceptChanges();

            BindingSource bindingSource = new BindingSource
            {
                DataSource = result
            };
            _view.SetMemberListBindingSource(bindingSource);
        }

    }
}
