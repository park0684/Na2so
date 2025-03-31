using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Na2so.Models
{
    public class GuestAddModel
    {
        public List<PlayerInfoModel> GuestList { get; set; } = new List<PlayerInfoModel>();
        public string _guestName;
        public int? _handicap;
        private bool _gender;
        public bool _isPro;

        private string GuestName
        {
            get { return _guestName; }
            set { _guestName = value; }
        }
        private int? Handycap
        {
            get { return _handicap; }
            set { _handicap = value; }
        }

        public bool Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        
        public bool IsPro
        {
            get { return _isPro; }
            set { _isPro = value; }
        }
    }
}
