using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace MorseMaster
{
    //! Klasa odpowiadająca za obsługę dźwięku.
    public class dzwiek
    {
        //! Sygnał kodu morse'a.
        private SoundPlayer syg;
        //! Konstruktor przypisujący sygnał kodu morse'a.
        public dzwiek()
        {
            syg = new SoundPlayer(MorseMaster.Properties.Resources.T_morse_code2);
        }
        //! Metoda włączająca odgrywanie sygnału.
        internal void Play()
        {
            syg.Play();
        }
        //! Metoda wyłączająca odgrywanie sygnału.
        internal void Stop()
        {
            syg.Stop();
        }
        //! Metoda odgrywa sygnał kropki o zadanej szykbkości transmisji.
        internal async void kropD(int mn)
        {
            Play();
            await Task.Delay(mn * 5);
            Stop();
        }
        //! Metoda odgrywa sygnał kreski o zadanej szykbkości transmisji.
        internal async void kresD(int mn)
        {
            Play();
            await Task.Delay(3 * mn * 5);
            Stop();
        }
    }
}
