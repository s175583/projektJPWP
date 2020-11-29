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
        public bool nauka = false, reset = false, menu = false, nadawanie = true, poprawne = false, swiatlo = false;
        public String znaki = "", znaki2 = "";
        float x = 510, y = 130;
        public int keyPress = 0;
        public int mn = 20, k = 0, z = 0;
        public int[,] zapis = new int[4, 2];
        public ciag(bool reset, bool menu)
        {
            this.alfabet = new element[26];
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
            this.reset = reset;
            this.menu = menu;
        }

        private void uzupZ(int i, int j)
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

        private void spraw(String zn, grafika graf, Label label1)
        {
            if (zn == znaki2)
            {
                label1.ForeColor = Color.Green;
                label1.Text = "Poprawnie!";
                if (!nadawanie) graf.off();
                z = 0;
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
        private void mrug(int l, int i, grafika graf)
        {
            if (l == zapis[z, 0] && zapis[z, 1] == 1)
            {
                graf.krop(mn);
                z++;
            }
            else if (l == zapis[z, 0] && zapis[z, 1] == 3)
            {
                graf.kres(mn);
                z++;
            }
            if (z == alfabet[i].znak.Length)
            {
                z = 0;
            }
        }
        public async void Nauka1(grafika graf)
        {
            if (!nauka)
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
                            uzupZ(i, j);
                        }
                        k = k + 4;
                        z = 0;
                        graf.RysN1(i, x, y, znaki);
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
                            if (l > 2)
                            {
                                mrug(l, i, graf);
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
        }

        public async void Nauka2(grafika graf, Label label1, TextBox textBox1)
        {
            if (!nauka)
            {
                nauka = true;
                while (nauka)
                {
                    graf.Clear();
                    label1.Text = "Wpisz znaki odpowiadające literze";
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
                            uzupZ(i, j);
                        }
                        k = k + 4;
                        if (nadawanie)
                        {
                            graf.RysN1(i, x, y, alfabet[i].litera);
                        }
                        else if (!nadawanie)
                        {
                            graf.RysN1(i, x, y, znaki);
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
                                    if (l > 2)
                                    {
                                        mrug(l, i, graf);
                                    }
                                    textBox1.Text = znaki2;
                                    if (keyPress == 1)
                                    {
                                        spraw(alfabet[i].litera, graf, label1);
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
                        }
                    }
                }
            }
        }

    }
}
