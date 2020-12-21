using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MorseMaster
{
    public class ciag
    {
        public element[] alfabet;
        public element[] losowy;
        public bool nauka = false, reset = false, menu = false, nadawanie = true, poprawne = false, swiatlo = false, tryb = false, dzwiek = false, wyk = false;
        public String znaki = "", znaki2 = "";
        float x = 510, y = 50;
        public int keyPress = 0;
        public int mn = 20, k = 0, z = 0, fa = 4, dl = 10;
        public int[,,] zapis = new int[20, 4, 2];
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
        /*
        private void uzupZ2(int i, int j)
        {
            if (alfabet[i].znak[j] == ".")
            {
                zapis[j, 0] = k;
                zapis[j, 1] = 1;
                k = k + 2;
            }
            else if (alfabet[i].znak[j] == "-")
            {
                zapis[j, 0] = k;
                zapis[j, 1] = 3;
                k = k + 4;
            }
        }
        */
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
        private void generator(grafika graf)
        {
            int liczba;
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
                k += 1;
                if (nadawanie)
                {
                    graf.RysN1(x, y, losowy[r].litera, Color.Black);
                }
                else if (!nadawanie)
                {
                    graf.RysN1(x, y, znaki, Color.Black);
                }
                znaki = "";
                x += 100;
            }
            k += 6;
        }

        private void RysT(grafika graf)
        {
            graf.Clear();
            x = 110;
            znaki = "";
            for (int rr = 0; rr < dl; rr++)
            {
                for (int j = 0; j < losowy[rr].znak.Length; j++)
                {
                    znaki = znaki + losowy[rr].znak[j];
                }
                if (nadawanie)
                {
                    graf.RysN1(x, y, losowy[rr].litera, losowy[rr].kolor);
                }
                else if (!nadawanie)
                {
                    graf.RysN1(x, y, znaki, losowy[rr].kolor);
                }
                znaki = "";
                x += 100;
            }
        }
        private void spraw(String zn, grafika graf, Label label1)
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
                znaki2 = "";
                keyPress = 0;
            }
        }
        private void mrug(int s, int l, int i, grafika graf)
        {
            if (l == zapis[s,z, 0] && zapis[s,z, 1] == 1)
            {
                graf.krop(mn);
                z++;
            }
            else if (l == zapis[s, z, 0] && zapis[s, z, 1] == 3)
            {
                graf.kres(mn);
                z++;
            }
            if (z == i)
            {
                z = 0;
                wyk = true;
            }
        }
        public async void Nauka1(grafika graf)
        {
            nauka = true;
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
                    graf.RysN1(x, y, znaki, Color.Black);
                    for (int l = 0; l < k; l++)
                    {
                        await Task.Delay(mn * 12);
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
                        if (l > 2 && swiatlo)
                        {
                            mrug(0, l, alfabet[i].znak.Length, graf);
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

        public async void Nauka2(grafika graf, Label label1, TextBox textBox1)
        {
            nauka = true;
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
                    k = k + 4;
                    if (nadawanie)
                    {
                        graf.RysN1(x, y, alfabet[i].litera, Color.Black);
                    }
                    else if (!nadawanie)
                    {
                        graf.RysN1(x, y, znaki, Color.Black);
                    }
                    while (!poprawne)
                    {
                        if (nadawanie)
                        {
                            await Task.Delay(12);
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
                                spraw(znaki, graf, label1);
                            }
                        }
                        else if (!nadawanie)
                        {
                            for (int l = 0; l < k && !poprawne; l++)
                            {
                                await Task.Delay(mn * 12);
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
                                if (l > 2 && swiatlo)
                                {
                                    mrug(0, l, alfabet[i].znak.Length, graf);
                                }
                                if (keyPress == 1)
                                {
                                    spraw(alfabet[i].litera, graf, label1);
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
                        break;
                    }
                    graf.drawBrush.Color = Color.Black;
                    if (i == 25)
                    {
                        nauka = false;
                        graf.Clear();
                        textBox1.Text = "";
                        label1.Text = "Dobra robota. Poprawnie zakodowałeś cały ciąg.";
                    }
                }
            }
        }

        public async void Trening(grafika graf, Label label1, TextBox textBox1)
        {
            nauka = true;
            poprawne = false;
            while (nauka)
            {
            int r = 0;
            z = 0;
            x = 110;
            k = 0;
            poprawne = false;
            graf.Clear();
            generator(graf);
            label1.Text = "Wpisz literę odpowiadającą symbolowi";
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
                        await Task.Delay(12);
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
                            spraw(znaki, graf, label1);
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
                            await Task.Delay(mn * 12);
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
                            if (l > 2 && swiatlo)
                            {
                                mrug(s, l, losowy[s].znak.Length, graf);
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
                                spraw(losowy[r].litera, graf, label1);
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
                            break;
                        }
                    }
                }
                if (poprawne)
                {
                    label1.Text = "Dobra robota. Poprawnie zakodowałeś cały ciąg.";
                    return;
                }
            }
        }
    }
}
