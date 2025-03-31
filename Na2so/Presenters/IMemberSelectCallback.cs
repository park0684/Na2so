using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Na2so.Presenters
{
    public interface IMemberSelectCallback
    {
        void OnMemberSelected(int memberCode, string memberName);
    }
}
