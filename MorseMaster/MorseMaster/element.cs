using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseMaster
{
    public class element
    {
        public string litera;
        public string[] znak;
        public string kolor = "czarny";
        public element(string litera, string[] znak)
        {
            this.litera = litera;
            this.znak = znak;
        }
    }
}
