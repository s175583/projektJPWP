using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace MorseMaster
{
    //! Klasa odpowiadająca za obsługę grafiki.
    public class grafika
    {
        //! Panel graficzny wyświetlający ciągi znaków. 
        private Graphics g;
        //! Panel graficzny wyświetlający mrugające światło. 
        private Graphics o;
        //! Panel graficzny wyświetlający pierwszy zestaw kontrolek. 
        private Graphics h;
        //! Panel graficzny wyświetlający drugi zestaw kontrolek.
        private Graphics hh;
        //! Narzędzie do rysowania.
        private Pen pen;
        //! Czcionka wyświetlanych znaków na panelu graficznym g.
        private System.Drawing.Font drawFont;
        //! Kolor wyświetlanych znaków na panelu graficznym g.
        internal System.Drawing.SolidBrush drawBrush;
        //! Grafika tła.
        private Bitmap mybitmap = new Bitmap(global::MorseMaster.Properties.Resources.abstracts_background);
        //! Konsruktor przypisujący pola graficzne z klasy Gra.cs
        public grafika(Graphics g, Graphics o, Graphics h, Graphics hh)
        {
            this.g = g;
            this.o = o;
            this.h = h;
            this.hh = hh;
            this.drawBrush = new SolidBrush(System.Drawing.Color.Black);
            this.drawFont = new Font("Arial", 48);
            this.pen = new Pen(Color.Brown, 30);
        }
        //! Wyświetlanie znaków na polu graficznym g.
        internal void RysN1(float x, float y, string znaki, Color kolor, bool tekst)
        {
            if (tekst)
            {
                drawBrush.Color = kolor;
                g.DrawString(znaki, drawFont, drawBrush, x, y);
            }
        }
        //! Wyświetlanie kontrolek.
        internal void kontrolki1(bool sw, bool dz, bool czas, int fa, bool tekst)
        {
            if (sw)
            {
                drawBrush.Color = Color.Green;
            }
            else drawBrush.Color = Color.Red;
            h.FillEllipse(drawBrush, 18, 0, 28, 28);
            if (dz)
            {
                drawBrush.Color = Color.Green;
            }
            else drawBrush.Color = Color.Red;
            h.FillEllipse(drawBrush, 94, 0, 28, 28);
            if (czas)
            {
                drawBrush.Color = Color.Green;
            }
            else drawBrush.Color = Color.Red;
            h.FillEllipse(drawBrush, 173, 0, 28, 28);
            if (fa == 11)
            {
                drawBrush.Color = Color.Green;
            }
            else drawBrush.Color = Color.Red;
            hh.FillEllipse(drawBrush, 23, 0, 28, 28);
            if (tekst)
            {
                drawBrush.Color = Color.Green;
            }
            else drawBrush.Color = Color.Red;
            hh.FillEllipse(drawBrush, 208, 0, 28, 28);
        }
        //! Czyszczenie pola graficznego g.
        internal void Clear()
        {
            g.DrawImage(mybitmap, 0, 0);
        }
        //! Włączenie światła na polu graficznym o.
        internal void on()
        {
            drawBrush.Color = Color.LightYellow;
            o.FillEllipse(drawBrush, 30, 30, 120, 120);
            drawBrush.Color = Color.Yellow;
            o.FillEllipse(drawBrush, 40, 40, 100, 100);
        }
        //! Wyłączenie światła na polu graficznym o.
        internal void off()
        {
            drawBrush.Color = Color.LightGray;
            o.FillEllipse(drawBrush, 30, 30, 120, 120);
            drawBrush.Color = Color.Gray;
            o.FillEllipse(drawBrush, 40, 40, 100, 100);
        }
        //! Metoda zapala światło dla sygnału kropki o zadanej szykbkości transmisji.
        internal async void krop(int mn)
        {
            on();
            await Task.Delay(mn * 5);
            off();
        }
        //! Metoda zapala światło dla sygnału kreski o zadanej szykbkości transmisji.
        internal async void kres(int mn)
        {
            on();
            await Task.Delay(3 * mn * 5);
            off();
        }
    }
}
