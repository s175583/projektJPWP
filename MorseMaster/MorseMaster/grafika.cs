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
        public Graphics g, o;
        public Pen pen;
        public System.Drawing.Font drawFont;
        public System.Drawing.SolidBrush drawBrush;

        public grafika(Graphics g, Graphics o)
        {
            this.g = g;
            this.o = o;
            this.drawBrush = new SolidBrush(System.Drawing.Color.Black);
            this.drawFont = new Font("Arial", 32);
            this.pen = new Pen(Color.Brown, 30);
        }

        public void RysN1(int i, float x, float y, string znaki)
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
            drawBrush.Color = Color.Black;
            g.DrawString(znaki, drawFont, drawBrush, x, y);
        }

        public void Clear()
        {
            g.Clear(Color.AliceBlue);
        }

        public void on()
        {
            o.Clear(Color.AliceBlue);
            drawBrush.Color = Color.LightYellow;
            o.FillEllipse(drawBrush, 30, 30, 120, 120);
            drawBrush.Color = Color.Yellow;
            o.FillEllipse(drawBrush, 40, 40, 100, 100);
        }

        public void off()
        {
            o.Clear(Color.AliceBlue);
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
