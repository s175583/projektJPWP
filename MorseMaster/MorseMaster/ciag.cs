using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace MorseMaster
{
    //! Klasa obsługująca tryby gry oraz zawierająca tablicę wszystkich znaków.
    public class ciag
    {
        //! Tablica zawierająca litery i odpowiadające im kody Morse'a dla całego alfabetu.
        private element[] alfabet;
        //! Tablica zawierająca litery i odpowiadające im kody Morse'a dla losowego ciągu.
        private element[] losowy;
        //! Sygnalizuje, że użytkownik poprawnie zakodował znak.
        private bool poprawne = false;
        //! Sygnalizuje zakończenie odegrania (dźwiękowego/świetlnego) sekwencji kodu Morse'a dla pojedynczej litery (Tylko dla trybu treningu)
        private bool wyk = false;
        //! Sygnalizuje, że program wykonuje jakiś tryb (nauki/treningu)
        internal bool nauka = false;
        //! Określa czy włączony tryb nadawania/odbierania (true - nadawanie, false - odbieranie).
        internal bool nadawanie = true;
        //! Określa czy włączone jest mruganie światła.
        internal bool swiatlo = false;
        //! Określa czy włączony jest dźwięk.
        internal bool dzwiek = false;
        //! Określa czy wyświetlany jest tekst sekwencji liter/znaków Morse'a (tryb nauki czynnej oraz treningu).
        internal bool tekst = true;
        //! Sygnalizuje naciśnięcie przycisku Menu.
        internal bool menu = false;
        //! Określa czy włączony jest tryb poprawności czasowej (tryb komunikacji z użyciem jednego przycisku).
        internal bool tryb = false;
        //! Sygnalizuje naciśnięcie przycisku Reset.
        internal bool reset = false;
        //! Przechowuje kod Morse'a aktualnie przetwarzanej litery.
        private String znaki = "";
        //! Przechowuje znaki wprowadzane z klawiatury.
        internal String znaki2 = "";
        //! Współrzędna pozioma na polu graficznym g.
        private float x = 510;
        //! Współrzędna pionowa na polu graficznym g.
        private float y = 50;
        //! Przechowuje liczbę naciśnięć przycisków klawiatury.
        internal int keyPress = 0;
        //! Długość kodu Morse'a dla danej litery określona jako ilość najkrótszych sygnałów (kropek) przy danej szybkości transmisji z których składa się kod.
        private int k = 0;
        //! Odlicza symbole, z których składa się kod Morse'a danej litery.
        private int z = 0;
        //! Długość wygenerowanego losowo ciągu (tylko tryb treningu).
        private int dl = 10;
        //! Przechowuje wartość określającą ilość popełnionych błędów (tylko tryb treningu oraz nauki czynnej). 
        private int bledy = 0;
        //! Mnożnik zwiększający najmniejszy odstęp czasu programu dla danej szybkości czasu.
        internal int mn = 71;
        //! Zawiera wartość odstępu między kodami poszczególnych liter (zmienia się dla metody Farnswortha).
        internal int fa = 4;
        //! Zawiera punkty w czasie, dla których musi zostać uruchomiona funkcja mrugania / odegrania dźwięku.
        private int[,,] zapis = new int[20, 4, 2];
        //! Stoper zliczający czas w którym użytkownik koduje dany ciąg (tylko tryb treningu).
        private Stopwatch zegar2 = new Stopwatch();
        //! Kontruktor tworzący tablicę zawierającą dane dla liter całego alfabetu oraz pustą tablicę na losowy ciąg.
        public ciag()
        {
            this.alfabet = new element[26];
            this.losowy = new element[10];
            alfabet[0] = new element("A", new string[2] { ".", "-" });
            alfabet[1] = new element("B", new string[4] { "-", ".", ".", "." });
            alfabet[2] = new element("C", new string[4] { "-", ".", "-", "." });
            alfabet[3] = new element("D", new string[3] { "-", ".", "." });
            alfabet[4] = new element("E", new string[1] { "." });
            alfabet[5] = new element("F", new string[4] { ".", ".", "-", "." });
            alfabet[6] = new element("G", new string[3] { "-", "-", "." });
            alfabet[7] = new element("H", new string[4] { ".", ".", ".", "." });
            alfabet[8] = new element("I", new string[2] { ".", "." });
            alfabet[9] = new element("J", new string[4] { ".", "-", "-", "-" });
            alfabet[10] = new element("K", new string[3] { "-", ".", "-" });
            alfabet[11] = new element("L", new string[4] { ".", "-", ".", "." });
            alfabet[12] = new element("M", new string[2] { "-", "-" });
            alfabet[13] = new element("N", new string[2] { "-", "." });
            alfabet[14] = new element("O", new string[3] { "-", "-", "-" });
            alfabet[15] = new element("P", new string[4] { ".", "-", "-", "." });
            alfabet[16] = new element("Q", new string[4] { "-", "-", ".", "-" });
            alfabet[17] = new element("R", new string[3] { ".", "-", "." });
            alfabet[18] = new element("S", new string[3] { ".", ".", "." });
            alfabet[19] = new element("T", new string[1] { "-" });
            alfabet[20] = new element("U", new string[3] { ".", ".", "-" });
            alfabet[21] = new element("V", new string[4] { ".", ".", ".", "-" });
            alfabet[22] = new element("W", new string[3] { ".", "-", "-" });
            alfabet[23] = new element("X", new string[4] { "-", ".", ".", "-" });
            alfabet[24] = new element("Y", new string[4] { "-", ".", "-", "-" });
            alfabet[25] = new element("Z", new string[4] { "-", "-", ".", "." });
        }
        //! Metoda uzupełniająca tablicę zapis[,,] punktami w czasie.
        private void uzupZ(int s, int i, int j)
        {
            if (alfabet[i].znak[j] == ".")
            {
                zapis[s, j, 0] = k;
                zapis[s, j, 1] = 1;
                k = k + 2;
            }
            else if (alfabet[i].znak[j] == "-")
            {
                zapis[s, j, 0] = k;
                zapis[s,j, 1] = 3;
                k = k + 4;
            }
        }
        //! Metoda generująca losowy ciąg znaków (tylko tryb treningu).
        private void generator(grafika graf)
        {
            znaki = "";
            int liczba;
            int dlugosc = 0;
            x = 50;
            Random rnd = new Random();
            k += 1;
            for (int r = 0; r < dl; r++)
            {
                k += 2;
                liczba = rnd.Next(26);
                losowy[r] = new element(alfabet[liczba].litera, alfabet[liczba].znak);
                for (int j = 0; j < losowy[r].znak.Length; j++)
                {
                    znaki = znaki + losowy[r].znak[j];
                    uzupZ(r, liczba, j);
                }
                if (fa == 4) { k += 1; } else { k += 4; }
                if (nadawanie)
                {
                    graf.RysN1(x, y, losowy[r].litera, Color.Black, tekst);
                    dlugosc = TextRenderer.MeasureText(losowy[r].litera, new Font("Arial", 48)).Width;
                }
                else if (!nadawanie)
                {
                    graf.RysN1(x, y, znaki, Color.Black, tekst);
                    dlugosc = TextRenderer.MeasureText(znaki, new Font("Arial", 48)).Width;
                }
                znaki = "";
                x += dlugosc + 5;
            }
            k += 2 + fa;
        }
        //! Metoda rysująca pełny ciąg znaków na panelu graficznym g (tylko tryb treningu).
        private void RysT(grafika graf)
        {
            graf.Clear();
            x = 50;
            int dlugosc = 0;
            znaki = "";
            for (int rr = 0; rr < dl; rr++)
            {
                for (int j = 0; j < losowy[rr].znak.Length; j++)
                {
                    znaki = znaki + losowy[rr].znak[j];
                }
                if (nadawanie)
                {
                    graf.RysN1(x, y, losowy[rr].litera, losowy[rr].kolor, tekst);
                    dlugosc = TextRenderer.MeasureText(losowy[rr].litera, new Font("Arial", 48)).Width;
                }
                else if (!nadawanie)
                {
                    graf.RysN1(x, y, znaki, losowy[rr].kolor, tekst);
                    dlugosc = TextRenderer.MeasureText(znaki, new Font("Arial", 48)).Width;
                }
                znaki = "";
                x += dlugosc + 5;
            }
        }
        //! Metoda sprawdza czy wprowadzony kod z klawiatury jest poprawny (tylko tryb treningu oraz nauki czynnej).
        private void spraw(String zn, grafika graf, Label label1, Label label2)
        {
            if (zn == znaki2)
            {
                label1.ForeColor = Color.Green;
                label1.Text = "Poprawnie!";
                if (!nadawanie) graf.off();
                poprawne = true;
            }
            else
            {
                label1.ForeColor = Color.Red;
                label1.Text = "Błąd!";
                bledy += 1;
                label2.Text = "Błędy: " + bledy;
                znaki2 = "";
                keyPress = 0;
            }
        }
        //! Metoda uruchamiająca funkcje odpowiedzialne za mruganie oraz odgrywanie dźwięku dla danych punktów w czasie zapisanych w tablicy zapis[,,].
        private void mrug(int s, int l, int i, grafika graf, dzwiek dzwk)
        {
            if (l == zapis[s,z, 0] && zapis[s,z, 1] == 1)
            {
                if (swiatlo) { graf.krop(mn); }
                if (dzwiek) { dzwk.kropD(mn); }
                z++;
            }
            else if (l == zapis[s, z, 0] && zapis[s, z, 1] == 3)
            {
                if (swiatlo) { graf.kres(mn); }
                if (dzwiek) { dzwk.kresD(mn); }
                z++;
            }
            if (z == i)
            {
                z = 0;
                wyk = true;
            }
        }
        //! Metoda obsługująca tryb nauki biernej.
        internal async void Nauka1(grafika graf, dzwiek dzwk)
        {
            nauka = true;
            x = 450;
            while (nauka)
            {
                graf.Clear();
                graf.off();
                for (int i = 0; i < 26; i++)
                {
                    znaki = alfabet[i].litera + "     ";
                    k = 3;
                    for (int j = 0; j < alfabet[i].znak.Length; j++)
                    {
                        znaki = znaki + alfabet[i].znak[j];
                        uzupZ(0, i, j);
                    }
                    k = k + fa;
                    z = 0;
                    graf.RysN1(x, y, znaki, Color.Black, true);
                    for (int l = 0; l < k; l++)
                    {
                        await Task.Delay(mn * 5);
                        if (reset || menu)
                        {
                            if (menu)
                            {
                                menu = false;
                                nauka = false;
                                return;
                            }
                            break;
                        }
                        if (l > 2 && (swiatlo || dzwiek))
                        {
                            mrug(0, l, alfabet[i].znak.Length, graf, dzwk);
                        }
                    }
                    if (reset)
                    {
                        reset = false;
                        break;
                    }
                    graf.Clear();
                }

            }
        }
        //! Metoda obsługująca tryb nauki czynnej.
        internal async void Nauka2(grafika graf, Label label1, Label label2, TextBox textBox1, dzwiek dzwk)
        {
            nauka = true;
            bledy = 0;
            x = 510;
            label2.Text = "Błędy: " + bledy;
            while (nauka)
            {
                graf.Clear();
                label1.Text = "Wpisz literę odpowiadającą symbolowi";
                graf.drawBrush.Color = Color.Black;
                for (int i = 0; i < 26; i++)
                {
                    znaki2 = "";
                    znaki = "";
                    keyPress = 0;
                    poprawne = false;
                    graf.Clear();
                    k = 3;
                    z = 0;
                    for (int j = 0; j < alfabet[i].znak.Length; j++)
                    {
                        znaki = znaki + alfabet[i].znak[j];
                        uzupZ(0, i, j);
                    }
                    k = k + fa;
                    if (nadawanie)
                    {
                        graf.RysN1(x, y, alfabet[i].litera, Color.Black, tekst);
                    }
                    else if (!nadawanie)
                    {
                        graf.RysN1(x, y, znaki, Color.Black, tekst);
                    }
                    while (!poprawne)
                    {
                        if (nadawanie)
                        {
                            await Task.Delay(5);
                            if (reset || menu)
                            {
                                if (menu)
                                {
                                    menu = false;
                                    nauka = false;
                                    return;
                                }
                                break;
                            }
                            textBox1.Text = znaki2;
                            if (keyPress == alfabet[i].znak.Length)
                            {
                                spraw(znaki, graf, label1, label2);
                            }
                        }
                        else if (!nadawanie)
                        {
                            for (int l = 0; l < k && !poprawne; l++)
                            {
                                await Task.Delay(mn * 5);
                                if (reset || menu)
                                {
                                    if (menu)
                                    {
                                        menu = false;
                                        nauka = false;
                                        return;
                                    }
                                    break;
                                }
                                if (l > 2 && (swiatlo || dzwiek))
                                {
                                    mrug(0, l, alfabet[i].znak.Length, graf, dzwk);
                                }
                                if (keyPress == 1)
                                {
                                    spraw(alfabet[i].litera, graf, label1, label2);
                                    textBox1.Text = "";
                                    if (poprawne)
                                    {
                                        z = 0;
                                    }
                                }
                            }
                        }
                        if (reset) break;
                    }
                    if (reset)
                    {
                        reset = false;
                        bledy = 0;
                        break;
                    }
                    graf.drawBrush.Color = Color.Black;
                    if (i == 25)
                    {
                        nauka = false;
                        graf.Clear();
                        textBox1.Text = "";
                        graf.drawBrush.Color = Color.Green;
                        label1.Text = "Dobra robota. Poprawnie zakodowałeś cały ciąg.";
                        while (!menu)
                        {
                            await Task.Delay(mn * 5);
                            if (reset)
                            {
                                reset = false;
                                nauka = true;
                                bledy = 0;
                                break;
                            }
                        }
                    }
                }
            }
        }
        //! Metoda obsługująca tryb treningu.
        internal async void Trening(grafika graf, Label label1, Label label2, TextBox textBox1, dzwiek dzwk, Label label3)
        {
            nauka = true;
            poprawne = false;
            bledy = 0;
            while (nauka)
            {
            int r = 0;
                z = 0;
                x = 50;
                k = 0;
                poprawne = false;
                graf.Clear();
                generator(graf);
                label1.Text = "Wpisz literę odpowiadającą symbolowi";
                zegar2.Reset();
                zegar2.Start();
                if (nadawanie)
                {
                    r = 0;
                    znaki = "";
                    for (int i = 0; i < losowy[r].znak.Length; i++)
                    {
                        znaki = znaki + losowy[r].znak[i];
                    }
                    while (!poprawne)
                    {
                        await Task.Delay(5);
                        if (reset || menu)
                        {
                            if (menu)
                            {
                                menu = false;
                                nauka = false;
                                return;
                            }
                            reset = false;
                            break;
                        }
                        textBox1.Text = znaki2;
                        if (keyPress == losowy[r].znak.Length)
                        {
                            keyPress = 0;
                            spraw(znaki, graf, label1, label2);
                            if (poprawne)
                            {
                                losowy[r].kolor = Color.Green;
                                r = r + 1;
                                znaki = "";
                                znaki2 = "";
                                RysT(graf);
                                for (int i = 0; i < losowy[r].znak.Length; i++)
                                {
                                    znaki = znaki + losowy[r].znak[i];
                                }
                                if (r < dl)
                                {
                                    poprawne = false;
                                }
                            }
                        }
                    }
                }
                else if (!nadawanie)
                {
                    r = 0;
                    znaki = "";
                    int s = 0;
                    wyk = false;
                    while (!poprawne)
                    {
                        for (int l = 0; l < k && !poprawne; l++)
                        {
                            await Task.Delay(mn * 5);
                            if (reset || menu)
                            {
                                if (menu)
                                {
                                    menu = false;
                                    nauka = false;
                                    return;
                                }
                                break;
                            }
                            if (l > 2 && (swiatlo || dzwiek))
                            {
                                mrug(s, l, losowy[s].znak.Length, graf, dzwk);
                                if (wyk)
                                {
                                    wyk = false;
                                    s++;
                                    if(s == dl)
                                    {
                                        s = 0;
                                    }
                                }
                            }
                            if (keyPress == 1)
                            {
                                keyPress = 0;
                                textBox1.Text = "";
                                spraw(losowy[r].litera, graf, label1, label2);
                                if (poprawne)
                                {
                                    losowy[r].kolor = Color.Green;
                                    r = r + 1;
                                    znaki2 = "";
                                    RysT(graf);
                                    if (r < dl)
                                    {
                                        poprawne = false;
                                    }
                                }
                            }
                        }
                        if (reset)
                        {
                            reset = false;
                            bledy = 0;
                            break;
                        }
                    }
                }
                if (poprawne)
                {
                    zegar2.Stop();
                    graf.Clear();
                    textBox1.Text = "";
                    graf.drawBrush.Color = Color.Green;
                    label1.Text = "Dobra robota. Poprawnie zakodowałeś cały ciąg.";
                    label3.Text = "Czas: " + zegar2.Elapsed;
                    nauka = false;
                    while (!menu)
                    {
                        await Task.Delay(mn * 5);
                        if (reset)
                        {
                            reset = false;
                            nauka = true;
                            bledy = 0;
                            break;
                        }
                    }
                }
            }
        }
    }
}
