using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM_VIII.Control
{
    public class Utils
    {
        public static DateTime GetDateByStrDate(string data)
        {
            try
            {
                string[] strDt = data.Split('-');
                return new DateTime(int.Parse(strDt[0]), int.Parse(strDt[1]), int.Parse(strDt[2]));
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
            
        }
    }
}
