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
    //! Klasa główna gry. Obsługuje wszystkie przyciski oraz tworzy pozostałe klasy.
    public partial class Gra : Form
    {
        //! Panel graficzny wyświetlający ciągi znaków. 
        private Graphics g;
        //! Panel graficzny wyświetlający mrugające światło. 
        private Graphics o;
        //! Panel graficzny wyświetlający pierwszy zestaw kontrolek. 
        private Graphics h;
        //! Panel graficzny wyświetlający drugi zestaw kontrolek.
        private Graphics hh;
        //! Czcionka wyświetlanych znaków na panelu graficznym g.
        private System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 32);
        //! Kolor wyświetlanych znaków na panelu graficznym g.
        private System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        //! Klasa obsługująca wyświetlanie grafiki.
        private grafika graf;
        //! Klasa obsługująca tryby gry oraz zawierająca tablicę wszystkich znaków.
        private ciag alfa;
        //! Klasa obsługująca dźwięk.
        private dzwiek dzwk;
        //! Informuje czy przycisk został puszczony (tylko tryb poprawności czasu).
        private bool zer = true;
        //! Informuje czy prowadzone jest nadawanie czy odbieranie. (true => nadawanie, false => odbieranie).
        private bool nadawanie = true;
        //! Stoper liczący czas przyciśnięcia klawisza (tylko tryb poprawności czasu).
        private Stopwatch zegar = new Stopwatch();
        //! Czas przyciśnięcia klawisza (tylko tryb poprawności czasu).
        private double czas = 0;
        //! Konstruktor klasy Gra.
        public Gra()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            o = panel2.CreateGraphics();
            h = panel9.CreateGraphics();
            hh = panel10.CreateGraphics();
            alfa = new ciag();
            graf = new grafika(g, o, h, hh);
            dzwk = new dzwiek();
        }
        //! Inicjalizacja wyświetlanej grafiki.
        private void inicajacja()
        {
            graf.Clear();
            graf.kontrolki1(alfa.swiatlo, alfa.dzwiek, alfa.tryb, alfa.fa, alfa.tekst);
            graf.off();

        }
        //! Obsługa przyciśnięcia klawisza wyboru nadawania.
        private void button6_Click(object sender, EventArgs e)
        {
            if (!alfa.nauka)
            {
                button6.BackColor = Color.OliveDrab;
                button7.BackColor = Color.LightSkyBlue;
                alfa.nadawanie = true;
            }
            else if(!alfa.nadawanie)
            {
                button6.BackColor = Color.DarkSeaGreen;
            }
            else { button7.BackColor = Color.LightSkyBlue; }
            this.nadawanie = true;
        }
        //! Obsługa przyciśnięcia klawisza wyboru odbierania.
        private void button7_Click(object sender, EventArgs e)
        {
            if (!alfa.nauka)
            {
                button7.BackColor = Color.OliveDrab;
                button6.BackColor = Color.LightSkyBlue;
                alfa.nadawanie = false;
            }
            else if (alfa.nadawanie)
            {
                button7.BackColor = Color.DarkSeaGreen;
            }
            else { button6.BackColor = Color.LightSkyBlue; }
            this.nadawanie = false;
        }
        //! Obsługa przyciśnięcia klawisza wyboru trubu nauki biernej.
        private void button1_Click(object sender, EventArgs e)
        {
            sw();
            alfa.Nauka1(graf, dzwk);
        }
        //! Obsługa przyciśnięcia klawisza wyboru trubu nauki czynnej.
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            sw();
            alfa.Nauka2(graf, label1, label2, textBox1, dzwk);

        }
        //! Obsługa przyciśnięcia klawisza wyboru trubu treningu.
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            sw();
            alfa.Trening(graf, label1, label2, textBox1, dzwk, label3);
        }
        //! Obsługa przyciśnięcia klawisza menu.
        private void button3_Click(object sender, EventArgs e)
        {
            alfa.menu = true;
            graf.off();
            textBox1.Enabled = false;
            sw();
            graf.Clear();
        }
        //! Obsługa wyboru szybkości transmisji.
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Int32.Parse(comboBox1.Text))
            {
                case 5: 
                    alfa.mn = 71;
                    break;
                case 10:
                    alfa.mn = 35;
                    break;
                case 15:
                    alfa.mn = 24;
                    break;
                case 20:
                    alfa.mn = 17;
                    break;
                case 30:
                    alfa.mn = 12;
                    break;
                case 40:
                    alfa.mn = 9;
                    break;
                case 50:
                    alfa.mn = 7;
                    break;
            }
        }
        //! Obsługa przyciśnięcia przycisku włączenia/wyłączenia światła.
        private void panel3_Click(object sender, EventArgs e)
        {
            alfa.swiatlo = !alfa.swiatlo;
            graf.kontrolki1(alfa.swiatlo, alfa.dzwiek, alfa.tryb, alfa.fa, alfa.tekst);
        }
        //! Obsługa przyciśnięcia przycisku włączenia/wyłączenia dźwięku.
        private void panel4_Click(object sender, EventArgs e)
        {
            alfa.dzwiek = !alfa.dzwiek;
            graf.kontrolki1(alfa.swiatlo, alfa.dzwiek, alfa.tryb, alfa.fa, alfa.tekst);
        }
        //! Obsługa przyciśnięcia przycisku włączenia/wyłączenia trybu poprawności czasu.
        private void panel5_Click(object sender, EventArgs e)
        {
            alfa.tryb = !alfa.tryb;
            graf.kontrolki1(alfa.swiatlo, alfa.dzwiek, alfa.tryb, alfa.fa, alfa.tekst);
        }
        //! Obsługa przycisnięcia klawisza z klawiatury (tylko tryb poprawności czasu).
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (zer && alfa.tryb && alfa.nadawanie)
            {
                zegar.Reset();
                zegar.Start();
                zer = false;
                if (alfa.swiatlo) { graf.on(); }
                if (alfa.dzwiek) { dzwk.Play(); }
            }
        }
        //! Obsługa puszczenia klawisza z klawiatury.
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (alfa.tryb && alfa.nadawanie)
            {
                zegar.Stop();
                zer = true;
                czas = zegar.Elapsed.TotalMilliseconds;
                if (alfa.swiatlo) { graf.off(); }
                if (alfa.dzwiek) { dzwk.Stop(); }
            }
            if (!alfa.nadawanie)
            {
                alfa.znaki2 = e.KeyCode.ToString().ToUpper();
                alfa.keyPress++;
            }
            else if (alfa.nadawanie)
            {
                if (((e.KeyCode == Keys.Z || e.KeyCode == Keys.Down) && !alfa.tryb) || (alfa.tryb && czas <= 1.5 * alfa.mn * 5))
                {
                    alfa.znaki2 = alfa.znaki2 + ".";
                    alfa.keyPress++;
                    if (!alfa.tryb)
                    {
                        if (alfa.swiatlo) { graf.krop(alfa.mn); }
                        if (alfa.dzwiek) { dzwk.kropD(alfa.mn); }
                    }
                }
                else if (((e.KeyCode == Keys.X || e.KeyCode == Keys.Right) && !alfa.tryb) || (alfa.tryb && czas >= 2.5 * alfa.mn * 5 && czas <= 3.5 * alfa.mn * 5))
                {
                    alfa.znaki2 = alfa.znaki2 + "-";
                    alfa.keyPress++;
                    if (!alfa.tryb)
                    {
                        if (alfa.swiatlo) { graf.kres(alfa.mn); }
                        if (alfa.dzwiek) { dzwk.kresD(alfa.mn); }
                    }
                }
            }
        }
        //! Obsługa przyciśnięcia przycisku włączenia/wyłączenia wyświetlania tekstu.
        private void panel8_Click(object sender, EventArgs e)
        {
            if (!alfa.nadawanie)
            {
                alfa.tekst = !alfa.tekst;
                graf.kontrolki1(alfa.swiatlo, alfa.dzwiek, alfa.tryb, alfa.fa, alfa.tekst);
            }
        }
        //! Wyświetlenie grafiki po uruchomieniu gry.
        private void Gra_Shown(object sender, EventArgs e)
        {
            inicajacja();
        }
        //! Obsługa przyciśnięcia przycisku włączenia/wyłączenia metody Farnswortha.
        private void panel7_Click(object sender, EventArgs e)
        {
            if (alfa.fa == 11)
            {
                alfa.fa = 4;
            }
            else if (alfa.fa == 4)
            {
                alfa.fa = 11;
            }
            graf.kontrolki1(alfa.swiatlo, alfa.dzwiek, alfa.tryb, alfa.fa, alfa.tekst);
        }
        //! Obsługa przyciśnięcia przycisku reset.
        private void button4_Click(object sender, EventArgs e)
        {
            alfa.reset = true;
            alfa.nadawanie = this.nadawanie;
            if (alfa.nadawanie)
            {
                button6.BackColor = Color.OliveDrab;
                button7.BackColor = Color.LightSkyBlue;
            }
            else
            {
                button6.BackColor = Color.LightSkyBlue;
                button7.BackColor = Color.OliveDrab;
            }
        }
        //! Zablokowanie/odblokowanie przycisków wyboru trybu gry, reset oraz menu.
        private void sw()
        {
            button1.Enabled = !button1.Enabled;
            button1.Visible = !button1.Visible;
            button2.Enabled = !button2.Enabled;
            button2.Visible = !button2.Visible;
            button5.Enabled = !button5.Enabled;
            button5.Visible = !button5.Visible;
            button3.Enabled = !button3.Enabled;
            button4.Enabled = !button4.Enabled;
        }
        //! Metoda wyświetlająca instrukcję obsługi.
        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Instrukcja obsługi:\n\nPrzyciski Nadawanie oraz Odbieranie - służą do wyboru czy chcemy nadawać czy odbierać." +
                "\nKolor ciemno-zielony symbolizuje wybraną opcję.\nKolor jasno-zielony sygnalizuje, że aby opcja została wybrana program musi zostać" +
                " zresetowany przyciskiem Reset\nPrzycisk Menu - powrót do Menu.\nPrzycisk Reset - resetuje aktualnie wybrany tryb do stanu początkowego.\n" +
                "Przycisk Nauka bierna - uruchamia tryb nauki biernej.\n" +
                "Przycisk Nauka czynna - uruchamia tryb nauki czynnej.\nIkona Żarówki - włącza/wyłącza mrugające światło.\nIkona głośnika - włącza/wyłącza dźwięk.\n" +
                "Ikona zegarka - włącza/wyłącza tryb poprawności czasu.\nO stanie włączanie ikon mówią kontrolki pod nimi. Kolor zielony - włączone, kolor czerwony - wyłączone\n" +
                "Przycisk Metoda Farnswortha - włącza metodę Farnswortha (dłuższe odstępy między kodami liter)\n Przycisk Teskt - włącza/wyłącza wyświetlanie tekstu\n" +
                "O stanie włączenia tych przycisków mówią kontrolki pod nimi. Kolor zielony - włączone, kolor czerwony - wyłączone.\n" +
                "Pole szybkość transmisji - służy do wyboru szybkości transmisji (w SNM).\nDane wprowadzamy w polu nad ikoną głośnika.\n" +
                "Tryb bez poprawności czasu: Do wprowadzania służą dwa zestawy przycisków:\n" +
                "X oraz Z - X jest kropką, Z jest kreską.\n" +
                "Strzałka w dół oraz Strzałka w prawo - strzałka w dół jest kropką, strzałka w prawo jest kreską\n" +
                "W trybie poprawności czasu znaki prowadzamy poprzez przyciśnięcie dowolnego przycisku przez określoną długość czasu.\n" +
                "Symbol jest dekodowany na kreskę lub kropkę na podstawie czasu przyciśnięcia oraz szybkości transmisji.");
        }
    }
}
