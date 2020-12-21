using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MorseMaster
{
    public class element
    {
        public string litera;
        public string[] znak;
        public Color kolor = Color.Black;
        public element(string litera, string[] znak)
        {
            this.litera = litera;
            this.znak = znak;
        }
    }
}
