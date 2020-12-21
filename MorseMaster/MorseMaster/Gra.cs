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
using System.Diagnostics;

namespace MorseMaster
{
    public partial class Gra : Form
    {
        public Graphics g, o, h;
        public System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 32);
        public System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        public grafika graf;
        public ciag alfa;
        bool zer = true;
        String znaki3;
        Stopwatch zegar = new Stopwatch();
        double czas = 0;
        
        public Gra()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            o = panel2.CreateGraphics();
            h = panel9.CreateGraphics();
            alfa = new ciag();
            graf = new grafika(g, o, h);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            alfa.nadawanie = true;
            button6.BackColor = Color.GreenYellow;
            button7.BackColor = Color.LightSkyBlue;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            alfa.nadawanie = false;
            button6.BackColor = Color.LightSkyBlue;
            button7.BackColor = Color.GreenYellow;
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
            textBox1.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            sw();
            alfa.Trening(graf, label1, textBox1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            alfa.menu = true;
            graf.off();
            button3.Enabled = false;
            button4.Enabled = false;
            textBox1.Enabled = false;
            sw();
            graf.Clear();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                alfa.fa = 11;
            }
            else alfa.fa = 4;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            alfa.mn = Int32.Parse(comboBox1.Text);
            label2.Text = alfa.mn.ToString();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            alfa.swiatlo = !alfa.swiatlo;
            graf.kontrolki1(alfa.swiatlo, alfa.dzwiek, alfa.tryb);
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            alfa.dzwiek = !alfa.dzwiek;
            graf.kontrolki1(alfa.swiatlo, alfa.dzwiek, alfa.tryb);
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            alfa.tryb = !alfa.tryb;
            graf.kontrolki1(alfa.swiatlo, alfa.dzwiek, alfa.tryb);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (zer && alfa.tryb && alfa.nadawanie)
            {
                zegar.Reset();
                zegar.Start();
                zer = false;
                graf.on();
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (alfa.tryb && alfa.nadawanie)
            {
                zegar.Stop();
                zer = true;
                czas = zegar.Elapsed.TotalMilliseconds;
                graf.off();
            }
            if (!alfa.nadawanie)
            {
                znaki3 = e.KeyCode.ToString().ToUpper();
                alfa.znaki2 = znaki3;
                alfa.keyPress++;
            }
            else if (alfa.nadawanie)
            {
                if ((e.KeyCode == Keys.Z && !alfa.tryb) || (alfa.tryb && czas <= 1.5 * alfa.mn * 12))
                {
                    alfa.znaki2 = alfa.znaki2 + ".";
                    alfa.keyPress++;
                    if (alfa.swiatlo && !alfa.tryb) graf.krop(alfa.mn);
                }
                else if ((e.KeyCode == Keys.X && !alfa.tryb) || (alfa.tryb && czas >= 2.5 * alfa.mn * 12 && czas <= 3.5 * alfa.mn * 12))
                {
                    alfa.znaki2 = alfa.znaki2 + "-";
                    alfa.keyPress++;
                    if (alfa.swiatlo && !alfa.tryb) graf.kres(alfa.mn);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
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
