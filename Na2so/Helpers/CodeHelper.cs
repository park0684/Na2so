using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Na2so.Helpers
{
    public static class CodeHelper
    {
        public static string GetStatusString(Dictionary<int, string> statusDictionary, int code)
        {
            if (statusDictionary.TryGetValue(code, out string valueText))
            {
                return valueText;
            }
            return "알 수 없는 코드";
        }

        public static int GetStatusCode(Dictionary<int, string> statusDictionary, string statusName)
        {
            foreach (var kvp in statusDictionary)
            {
                if (kvp.Value == statusName)
                {
                    return kvp.Key;
                }
            }
            return -1;
        }
    }
}
