using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Na2so.Models
{
    public class MemberDetailModel
    {
        private string _name;
        private string _birth;
        private string _memo;
        private int? _code;
        private int? _status;
        private int? _position;
        private int? _gendr;
        private DateTime? _accessDate;
        private DateTime? _secessDate;
        private bool _isNew;

        public string MemberName
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Birth
        { 
            get { return _birth; } 
            set { _birth = value; } 
        }

        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }
        public int Code
        {
            get { return (int)_code; }
            set { _code = value; }
        }
        public int Status
        {
            get { return (int)_status; }
            set { _status = value; }
        }
        public int Position
        {
            get { return (int)_position; }
            set { _position = value; }
        }
        public int Gender
        {
            get { return (int)_gendr; }
            set { _gendr = value; }
        }

        public DateTime AccessDate
        {
            get { return (DateTime)_accessDate; }
            set { _accessDate = value; }
        }
        public DateTime SecessDate
        {
            get { return (DateTime)_secessDate; } 
            set { _secessDate = value; }
        }
        public bool IsNew
        {
            get { return _isNew; }
            set { _isNew = value; }
        }
    }
}
