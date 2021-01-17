using System.Drawing;

namespace MorseMaster
{
    partial class Gra
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(451, 676);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 77);
            this.button1.TabIndex = 0;
            this.button1.Text = "Nauka bierna";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Location = new System.Drawing.Point(692, 677);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 76);
            this.button2.TabIndex = 1;
            this.button2.Text = "Trening";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button3.Enabled = false;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button3.Location = new System.Drawing.Point(12, 693);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(142, 63);
            this.button3.TabIndex = 2;
            this.button3.Text = "Menu";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button4.Enabled = false;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button4.Location = new System.Drawing.Point(160, 693);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(142, 63);
            this.button4.TabIndex = 3;
            this.button4.Text = "Reset";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::MorseMaster.Properties.Resources.abstracts_background;
            this.panel1.Location = new System.Drawing.Point(74, 248);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1109, 169);
            this.panel1.TabIndex = 4;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button5.Location = new System.Drawing.Point(572, 677);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 76);
            this.button5.TabIndex = 5;
            this.button5.Text = "Nauka czynna";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.ForeColor = System.Drawing.Color.SeaGreen;
            this.label1.Location = new System.Drawing.Point(34, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 24);
            this.label1.TabIndex = 6;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.textBox1.Location = new System.Drawing.Point(572, 474);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 32);
            this.textBox1.TabIndex = 7;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.OliveDrab;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button6.Location = new System.Drawing.Point(12, 621);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(142, 63);
            this.button6.TabIndex = 8;
            this.button6.Text = "Nadawanie";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button7.Location = new System.Drawing.Point(160, 621);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(142, 63);
            this.button7.TabIndex = 9;
            this.button7.Text = "Odbieranie";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.Location = new System.Drawing.Point(531, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(180, 180);
            this.panel2.TabIndex = 10;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "30",
            "40",
            "50"});
            this.comboBox1.Location = new System.Drawing.Point(1110, 601);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(147, 39);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.SelectedIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = global::MorseMaster.Properties.Resources.zar;
            this.panel3.Location = new System.Drawing.Point(515, 545);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(59, 70);
            this.panel3.TabIndex = 16;
            this.panel3.Click += new System.EventHandler(this.panel3_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BackgroundImage = global::MorseMaster.Properties.Resources.dzw;
            this.panel4.Location = new System.Drawing.Point(591, 545);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(70, 70);
            this.panel4.TabIndex = 17;
            this.panel4.Click += new System.EventHandler(this.panel4_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.BackgroundImage = global::MorseMaster.Properties.Resources.zegar;
            this.panel5.Location = new System.Drawing.Point(667, 545);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(70, 70);
            this.panel5.TabIndex = 17;
            this.panel5.Click += new System.EventHandler(this.panel5_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.BackgroundImage = global::MorseMaster.Properties.Resources.szybk;
            this.panel6.Location = new System.Drawing.Point(1110, 573);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(147, 22);
            this.panel6.TabIndex = 18;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.BackgroundImage = global::MorseMaster.Properties.Resources.metoda;
            this.panel7.Location = new System.Drawing.Point(863, 688);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(222, 31);
            this.panel7.TabIndex = 17;
            this.panel7.Click += new System.EventHandler(this.panel7_Click);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Transparent;
            this.panel8.BackgroundImage = global::MorseMaster.Properties.Resources.tekst;
            this.panel8.Location = new System.Drawing.Point(1110, 690);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(94, 29);
            this.panel8.TabIndex = 19;
            this.panel8.Click += new System.EventHandler(this.panel8_Click);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Transparent;
            this.panel9.Location = new System.Drawing.Point(515, 621);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(222, 28);
            this.panel9.TabIndex = 18;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Transparent;
            this.panel10.Location = new System.Drawing.Point(937, 725);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(267, 28);
            this.panel10.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.SeaGreen;
            this.label2.Location = new System.Drawing.Point(38, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 24);
            this.label2.TabIndex = 20;
            this.label2.Text = "Błędy: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.SeaGreen;
            this.label3.Location = new System.Drawing.Point(38, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 24);
            this.label3.TabIndex = 21;
            this.label3.Text = "Czas: ";
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button8.Location = new System.Drawing.Point(1168, 12);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(100, 36);
            this.button8.TabIndex = 22;
            this.button8.Text = "Instrukcja";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // Gra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.BackgroundImage = global::MorseMaster.Properties.Resources.abstracts_background;
            this.ClientSize = new System.Drawing.Size(1280, 768);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Gra";
            this.Text = "Morse Master";
            this.Shown += new System.EventHandler(this.Gra_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        //! Przycisk "Nauka bierna" - uruchamia tryb nauki biernej.
        private System.Windows.Forms.Button button1;
        //! Przycisk "Trening" - uruchamia tryb treningu.
        private System.Windows.Forms.Button button2;
        //! Przycisk "Menu" - powrót do Menu.
        private System.Windows.Forms.Button button3;
        //! Przycisk "Reset" - resetuje aktualnie wykonywany tryb do stanu początkowego.
        private System.Windows.Forms.Button button4;
        //! Przycisk "Nauka czynna" - uruchamia tryb nauki czynnej.
        private System.Windows.Forms.Button button5;
        //! Pole wyświetlające komunikaty.
        private System.Windows.Forms.Label label1;
        //! Pole do wprowadzania danych.
        private System.Windows.Forms.TextBox textBox1;
        //! Przycisk "Nadawanie" - włącza opcję nadawania.
        private System.Windows.Forms.Button button6;
        //! Przycisk "Odbieranie" - włącza opcję odbierania.
        private System.Windows.Forms.Button button7;
        //! Panel graficzny odpowiedzialny za wyświetlanie migającego światła.
        private System.Windows.Forms.Panel panel2;
        //! Panel graficzny odpowiedzialny za wyświetlanie znaków.
        private System.Windows.Forms.Panel panel1;
        //! Panel z przyciskiem żarówki (włącza/wyłącza migające światło).
        private System.Windows.Forms.Panel panel3;
        //! Panel z przyciskiem głośnika (włącza/wyłącza dźwięk).
        private System.Windows.Forms.Panel panel4;
        //! Panel z przyciskiem zegarka (włącza/wyłącza tryb poprawności czasu).
        private System.Windows.Forms.Panel panel5;
        //! Panel z napisem "Szybkość transmisji".
        private System.Windows.Forms.Panel panel6;
        //! Panel z przyciskiem "Metoda Farnswortha" (włącza/wyłącza metodę Farnswortha).
        private System.Windows.Forms.Panel panel7;
        //! Pole wyboru szybkości transmisji.
        private System.Windows.Forms.ComboBox comboBox1;
        //! Panel z przyciskiem "Tekst" (włącza/wyłącza wyświetlanie tekstu).
        private System.Windows.Forms.Panel panel8;
        //! Panel graficzny z pierwszym zestawem kontrolek.
        private System.Windows.Forms.Panel panel9;
        //! Panel graficzny z drugim zestawem kontrolek.
        private System.Windows.Forms.Panel panel10;
        //! Wyświetla ilość błędów popełnionych przez użytkownika.
        private System.Windows.Forms.Label label2;
        //! Wyświetla czas jaki zajeło użytkownikowi kodowanie/dekodowanie.
        private System.Windows.Forms.Label label3;
        //! Przycisk "Instrukcja" - uruchamia okno z instrukcją.
        private System.Windows.Forms.Button button8;
    }
}

