using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YEAR
{
    public class Class1
    {
        public enum YearFormat
        {
            C = 0,//民國
            W = 1//西元
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Age"></param>
        /// <param name="format"</param>
        /// <returns></returns>
        public int GetBirthYear(int Age, YearFormat format)
        {
            int WestYear = (DateTime.Now.Year - Age);

            if (format == YearFormat.C)
                return (WestYear - 1911);
            else if (format == YearFormat.W)
                return WestYear;

            return 0;
        }
    }
}
