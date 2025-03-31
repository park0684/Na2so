using Na2so.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Na2so.Controls;

namespace Na2so.Views
{
    public partial class GamePlayerManageView : Form, IGamePlayerManageView
    {
        public GamePlayerManageView()
        {
            InitializeComponent();
            ViewEvent();
        }
        private void ViewEvent()
        {
            btnSearch.Click += (s, e) => SearchMemberEvent?.Invoke(this, EventArgs.Empty);
            btnClose.Click += (s, e) => CloseEvent?.Invoke(this, EventArgs.Empty);
            btnSave.Click += (s, e) => SavePlayerListEvent?.Invoke(this, EventArgs.Empty);
            btnAddGuest.Click += (s, e) => AddGuestEvent?.Invoke(this, EventArgs.Empty);
            txtSearchWord.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchMemberEvent?.Invoke(this, EventArgs.Empty);
            };
        }
        public string SearchWord
        {
            get { return txtSearchWord.Text; }
            set { txtSearchWord.Text = value; }
        }

        public bool SecessMember
        {
            get { return chkSecessMember.Checked; }
            set { chkSecessMember.Checked = value; }
        }


        public event EventHandler SearchMemberEvent;
        public event EventHandler PlayerUpdateEvent;
        public event EventHandler<Button> PlayerAddEvent;
        public event EventHandler<Button> PlayerRemoveEvent;
        public event EventHandler SavePlayerListEvent;
        public event EventHandler CloseEvent;
        public event EventHandler AddGuestEvent;

        public void CloseForm()
        {
            this.Close();
        }

        public void SetMemberList(List<PlayerInfoModel> members)
        {
            flpMemberList.Controls.Clear();
            foreach (var member in members)
            {
                Button btn = new Button
                {
                    Size = new Size(90, 50),
                    FlatStyle = FlatStyle.Flat,
                    
                    Text = member.PalyerName, 
                    Tag = member.MemberCode, 
                    BackColor = member.IsSelected ? Color.FromArgb(65,100,223) : Color.FromArgb(54, 178, 221) 
                };
                btn.Click += (sender, e) =>  PlayerAddEvent?.Invoke(this, btn ); 
                flpMemberList.Controls.Add(btn);
            }
            
        }


        public void SetPlayerList(List<PlayerInfoModel> players)
        {
            flpPlayerList.Controls.Clear();
            //flpPlayerList.AutoScroll = true;
            foreach (var player in players)
            {
                Button btn = new Button
                {
                    Size = new Size(90, 50),
                    FlatStyle = FlatStyle.Flat,
                    Text = player.PalyerName, 
                    Tag = player.MemberCode,
                    BackColor = Color.FromArgb(54, 178, 221)
                };
                btn.Click += (sender, e) => PlayerRemoveEvent?.Invoke(this, btn);
                flpPlayerList.Controls.Add(btn);
            }
        }

        public void UpdateButtonColor(int memberCode, bool isAdded)
        {
            foreach (Control control in flpMemberList.Controls)
            {
                if (control is Button btn && (int)btn.Tag == memberCode)
                {
                    btn.BackColor = isAdded ? Color.FromArgb(65, 100, 223) : Color.FromArgb(54, 178, 221);
                    break; // 찾았으면 더 이상 반복할 필요 없음
                }
            }
        }
    }

    
}
