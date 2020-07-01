using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseSimulator.Symulator;

namespace WarehouseSimulator.Kontrolki
{
    public partial class ucPozycja : UserControl
    {
        public ucPozycja(int numer, TypPozycji typ, int x, int y, int szer, int wys)
        {
            InitializeComponent();
            Typ = typ;
            lblNumer.Text = numer.ToString();
            this.SetBounds(x, y, szer, wys);
            lblNumer.BackColor = DajKolorPozycji(typ);
            lblNumer.ForeColor = DajKolorNumeruPozycji(typ);
            this.BackColor = typ == TypPozycji.Master ? Color.White : Color.Gainsboro;
            lblNumer.Visible = false;
            if (typ == TypPozycji.Kontrola)
            {
                lblNumer.Text = "KONTROLA";
                lblNumer.Visible = true;
            }

            if (typ == TypPozycji.Naprawa)
            {
                lblNumer.Text = "NAPRAWA";
                lblNumer.Visible = true;
            }

            if (typ == TypPozycji.Inspekcja)
            {
                lblNumer.Text = "INSPEKCJA";
                lblNumer.Visible = true;
            }
        }

        public TypPozycji Typ { get; set; }

        public void PokazNumerPozycji()
        {
            lblNumer.Visible = true;
        }

        public void UkryjNumerPozycji()
        {
            if (Typ != TypPozycji.Kontrola && Typ != TypPozycji.Inspekcja && Typ != TypPozycji.Naprawa)
                lblNumer.Visible = false;
        }


        private Color DajKolorPozycji(TypPozycji typ)
        {
            Color wynik = Color.Gainsboro;
            switch (typ)
            {
                case TypPozycji.Produkcja:
                case TypPozycji.Podstawowa:
                case TypPozycji.Dwukierunkowa:
                case TypPozycji.Magazyn:
                case TypPozycji.Rampa:
                case TypPozycji.Rozjazd:
                    wynik = Color.Gainsboro;
                    break;
                case TypPozycji.Kontrola:
                case TypPozycji.Naprawa:
                case TypPozycji.Inspekcja:
                    wynik = Color.Gray;
                    break;
                case TypPozycji.Master:
                    wynik = Color.White;
                    break;
            }

            return wynik;
        }

        private Color DajKolorNumeruPozycji(TypPozycji typ)
        {
            Color wynik = Color.Gray;
            switch (typ)
            {
                case TypPozycji.Produkcja:
                case TypPozycji.Podstawowa:
                case TypPozycji.Dwukierunkowa:
                case TypPozycji.Magazyn:
                case TypPozycji.Rampa:
                case TypPozycji.Master:
                case TypPozycji.Rozjazd:
                    wynik = Color.Gray;
                    break;
                case TypPozycji.Kontrola:
                case TypPozycji.Naprawa:
                case TypPozycji.Inspekcja:
                    wynik = Color.WhiteSmoke;
                    break;
            }

            return wynik;
        }


    }
}
