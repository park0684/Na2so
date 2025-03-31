using Na2so.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Na2so.Views
{
    public partial class MainView : Form,IMainView
    {
        public MainView()
        {
            InitializeComponent();
            new MainPresenter(this);
            btnMemberList.Click += (s,e) => ShowMemberListView?.Invoke(s, e);
            btnGameList.Click += (s, e) => ShowGameListView?.Invoke(s, e);
            btnDues.Click += (s, e) => ShowDuesManageView?.Invoke(s, e);
        }

        // 사이드 버튼 클릭 이벤트
        public void btn_Click<T>(object sender, EventArgs e) where T : Form, new()
        {
            if (activeForm is T) return;

            T formInstance = GetOrCreateForm<T>(sender);
            ShowChildForm(formInstance);
        }
        
        /// <summary>
        /// 실행하 메뉴의 폼이 이미 생성되었다면 기존폼을 반환
        /// 생성되지 않았다면 새로운 폼을 생성
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sender"></param>
        /// <returns></returns>
        private T GetOrCreateForm<T>(object sender) where T : Form, new()
        {
            string formName = typeof(T).Name;

            if (pnlView.Controls.ContainsKey(formName))
            {
                return (T)pnlView.Controls[formName];
            }

            T formInstance = new T
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
                Name = formName
            };

            pnlView.Controls.Add(formInstance);
            pnlView.Tag = ((Button)sender).Name;

            return formInstance;
        }

        /// <summary>
        /// 폼 전환
        /// 기존 폼 삭제 하지 않고 숨긴 후 이미 실행된 메뉴 재실행 시 폼 재사용
        /// </summary>
        /// <param name="childForm"></param>
        public void ShowChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Hide();
            }

            activeForm = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public Form activeForm; // 현재 활성화된 폼


        public event EventHandler ShowMemberListView;
        public event EventHandler ShowGameListView;
        public event EventHandler ShowDuesManageView;



    }
}
