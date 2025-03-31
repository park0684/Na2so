using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Na2so.Models
{
    public class MemberSearchModel
    {
        public int? MemberCode { get; set; }
        public string SearchWord { get; set; }
        public List<(int code, string name)> MemberList { get; set; }
    }
}
