using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MorseMaster
{
    //! Klasa zaiwerająca model poejdynczej litery i odpowiadającego jej kodu Morse'a.
    public class element
    {
        //! Litera
        internal string litera;
        //! Kod morse'a litery
        internal string[] znak;
        //! Kod morse'a litery użyty do wyświetlania
        internal Color kolor = Color.Black;
        //! Konstruktor przypisujący litere oraz odpowiadającego jej kod Morse'a.
        public element(string litera, string[] znak)
        {
            this.litera = litera;
            this.znak = znak;
        }
    }
}
