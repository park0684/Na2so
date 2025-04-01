using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Na2so.Repositories;
using Na2so.Presenters;
namespace Na2so.Views
{
    public partial class MemberSearchView : Form, IMemberSearchView
    {
        public MemberSearchView()
        {
            InitializeComponent();
            ViewEvent();
            
        }
   
        private void ViewEvent()
        {
            btnSearch.Click += (s, e) => MemberSeachEvent?.Invoke(this, EventArgs.Empty);
            btnClose.Click += (s, e) => CloseFormEvent?.Invoke(this, EventArgs.Empty);
            txtSearchWord.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    MemberSeachEvent?.Invoke(this, EventArgs.Empty);
            };
        }
        public string SearchWord
        {
            get { return txtSearchWord.Text; }
            set { txtSearchWord.Text = value; }
        }

        public int MemberCode
        {
            get; private set;
        }

        public string MemberName
        { get; private set; }
        public bool IsInculde { get => chkSecetInculde.Checked; set => chkSecetInculde.Checked = value; }

        public event EventHandler MemberSeachEvent;
        public event EventHandler SelectMemberEvent;
        public event EventHandler CloseFormEvent;

        public void CloseForm()
        {
            Close();
        }

        public void SetMemberList(List<(int code, string name)> members)
        {
            flpMemberList.Controls.Clear();
            foreach (var member in members)
            {
                Button btn = new Button
                {
                    Size = new Size(90, 35),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(126, 112, 247),
                    ForeColor = Color.White,
                    Text = member.name,
                    Tag = member.code,
                };
                btn.FlatAppearance.BorderSize = 0;
                btn.Click += (sender, e) =>
                {
                    MemberCode = (int)((Button)sender).Tag; 
                    MemberName = ((Button)sender).Text;
                    SelectMemberEvent?.Invoke(this, EventArgs.Empty);
                };
                flpMemberList.Controls.Add(btn);
            }
            flpMemberList.AutoScroll = true;
        }

        public void ShowView()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowDialog();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "알림");
        }
    }

}
