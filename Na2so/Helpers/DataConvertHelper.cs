﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Na2so.Helpers
{
    public static class DataConvertHelper
    {
        public static decimal ConvertRate(object denominator, object numerator)
        {
            if(!decimal.TryParse(Convert.ToString(denominator), out decimal _denominator))
                _denominator = 0;

            if (!decimal.TryParse(Convert.ToString(numerator), out decimal _numerator))
                _numerator = 0;

            if (_denominator == 0)
                return _numerator > 0 ? 100 : 0;


            return Math.Round((_numerator / _denominator) * 100, 2);
        }
    }
}
