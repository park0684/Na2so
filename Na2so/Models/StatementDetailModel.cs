﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Na2so.Models
{
    public class StatementDetailModel
    {
        public DateTime StatementDate { get; set; }
        public int? StatementType { get; set; }
        public int? MemberCode { get; set; }
        public int? StatementCode { get; set; }
        public int? StatementAmount { get; set; }
        public int? DueCount { get; set; }
        public string StatementDetail { get; set; }
        public string MemberName { get; set; }
        public string Memo { get; set; }
        public bool IsNew { get; set; }
        public bool IsWithdrawal { get; set; }
    }
}
