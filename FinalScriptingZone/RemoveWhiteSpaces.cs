using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scripting_Zone
{
    class RemoveWhiteSpaces
    {
        public string Remove_White_Spaces(string TEXT)
        {
            List<string> finaltxtarr = new List<string>();
            Array textchararr = TEXT.ToCharArray();

            foreach (Char t in textchararr)
            {
                if (t.ToString() != " ")
                {
                    finaltxtarr.Add(t.ToString());
                }
            }

            string FinalTEXT = string.Join("", finaltxtarr.ToArray());

            return FinalTEXT;
        }
    }
}
