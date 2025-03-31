using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Na2so.Controls
{
    public class PlayerButton : Button
    {
        public PlayerButton()
        {
            this.BackColor = Color.LightBlue;
            this.ForeColor = Color.Black;
            this.Font = new Font("맑은 고딕", 10, FontStyle.Regular);
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 1;
            this.Size = new Size(90, 50);
        }        
    }
}
