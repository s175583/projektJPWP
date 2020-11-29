using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace MorseMaster
{
    public partial class Form1 : Form
    {
        public Graphics g, o;
        public System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 32);
        public System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        public grafika graf;
        public ciag alfa;
        bool menu = false, reset = false;
        String znaki3;

        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            o = panel2.CreateGraphics();
            alfa = new ciag(reset, menu);
            graf = new grafika(g, o);
            graf.off();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!alfa.nadawanie)
            {
                znaki3 = Char.ToString(Char.ToUpper(e.KeyChar));
                alfa.znaki2 = znaki3;
                alfa.keyPress++;
            }
            else if (alfa.nadawanie)
            {
                if (e.KeyChar - 32 == (char)Keys.Z)
                {
                    alfa.znaki2 = alfa.znaki2 + ".";
                    alfa.keyPress++;
                    if (alfa.swiatlo) graf.krop(alfa.mn);
                }
                else if (e.KeyChar - 32 == (char)Keys.X)
                {
                    alfa.znaki2 = alfa.znaki2 + "-";
                    alfa.keyPress++;
                    if (alfa.swiatlo) graf.kres(alfa.mn);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            alfa.nadawanie = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            alfa.swiatlo = !alfa.swiatlo;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            alfa.nadawanie = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;
            button4.Enabled = true;
            sw();
            alfa.Nauka1(graf);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            sw();
            alfa.Nauka2(graf, label1, textBox1);

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            menu = true;
            alfa.menu = true;
            graf.off();
            button3.Enabled = false;
            button4.Enabled = false;
            textBox1.Enabled = false;
            sw();
            g.Clear(Color.LightBlue);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            reset = true;
            alfa.reset = true;
        }

        private void sw()
        {
            button1.Enabled = !button1.Enabled;
            button1.Visible = !button1.Visible;
            button2.Enabled = !button2.Enabled;
            button2.Visible = !button2.Visible;
            button5.Enabled = !button5.Enabled;
            button5.Visible = !button5.Visible;
        }

    }
}
