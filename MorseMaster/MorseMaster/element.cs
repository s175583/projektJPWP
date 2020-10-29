using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseMaster
{
    class element
    {
        public string litera;
        public string[] znak;
        public int dl;
        public element(string litera, int dl, string[] znak)
        {
            this.litera = litera;
            this.dl = dl;
            this.znak = znak;
        }
    }
}
