using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Validation
    {
        public static bool IfCorrectURL(string URL)
        {
            return URL.StartsWith("https://") || URL.StartsWith("http://") ? true : false;
        }
    }
}
