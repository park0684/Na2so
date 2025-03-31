using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Na2so.Views
{
    public interface IMainView
    {
        event EventHandler ShowMemberListView;
        event EventHandler ShowGameListView;
        event EventHandler ShowDuesManageView;

        void btn_Click<T>(object sender, EventArgs e) where T : Form, new();
    }
}
