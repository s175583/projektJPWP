using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace MorseMaster
{
    public class grafika
    {
        public Graphics g, o, h;
        public Pen pen;
        public System.Drawing.Font drawFont;
        public System.Drawing.SolidBrush drawBrush;
        public Bitmap mybitmap = new Bitmap(global::MorseMaster.Properties.Resources.abstracts_background);

        public grafika(Graphics g, Graphics o, Graphics h)
        {
            this.g = g;
            this.o = o;
            this.h = h;
            this.drawBrush = new SolidBrush(System.Drawing.Color.Black);
            this.drawFont = new Font("Arial", 48);
            this.pen = new Pen(Color.Brown, 30);
        }

        public void RysN1(float x, float y, string znaki, Color kolor)
        {
            /*
            if (alfa.alfabet[i].kolor == "zielony")
            {
                drawBrush.Color = Color.Green;
            }
            else
            {
                drawBrush.Color = Color.Black;
            }
            */
            drawBrush.Color = kolor;
            g.DrawString(znaki, drawFont, drawBrush, x, y);
        }

        public void kontrolki1(bool sw, bool dz, bool czas)
        {
            if (sw)
            {
                drawBrush.Color = Color.Green;
            }
            else drawBrush.Color = Color.Red;
            h.FillEllipse(drawBrush, 23, 0, 28, 28);
            if (dz)
            {
                drawBrush.Color = Color.Green;
            }
            else drawBrush.Color = Color.Red;
            h.FillEllipse(drawBrush, 97, 0, 28, 28);
            if (czas)
            {
                drawBrush.Color = Color.Green;
            }
            else drawBrush.Color = Color.Red;
            h.FillEllipse(drawBrush, 171, 0, 28, 28);
        }
        public void Clear()
        {
            g.DrawImage(mybitmap, 0, 0);
        }

        public void on()
        {
            drawBrush.Color = Color.LightYellow;
            o.FillEllipse(drawBrush, 30, 30, 120, 120);
            drawBrush.Color = Color.Yellow;
            o.FillEllipse(drawBrush, 40, 40, 100, 100);
        }

        public void off()
        {
            drawBrush.Color = Color.LightGray;
            o.FillEllipse(drawBrush, 30, 30, 120, 120);
            drawBrush.Color = Color.Gray;
            o.FillEllipse(drawBrush, 40, 40, 100, 100);
        }

        public async void krop(int mn)
        {
            on();
            await Task.Delay(mn * 12);
            off();
        }

        public async void kres(int mn)
        {
            on();
            await Task.Delay(3 * mn * 12);
            off();
        }
    }
}
