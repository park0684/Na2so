using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Na2so.Helpers
{
    static public class DuesHelper
    {
        public readonly static Dictionary<int, string> DuesType = new Dictionary<int, string>()
        {
            {1,"회비" },
            {2,"지출" },
            {3,"면제" },
            {99, "기타" }
        };

        public static string GetDuesType(int keycode)
        {
            return CodeHelper.GetStatusString(DuesType, keycode);
        }

        public static int GetDuesTypeCode(string valueString)
        {
            return CodeHelper.GetStatusCode(DuesType, valueString);
        }

    }
}
