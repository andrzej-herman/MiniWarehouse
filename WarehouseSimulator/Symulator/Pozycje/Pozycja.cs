using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseSimulator.BazaDanych;
using WarehouseSimulator.Kontrolki;
using WarehouseSimulator.Symulator.Palety;

namespace WarehouseSimulator.Symulator.Pozycje
{
    public class Pozycja : IPozycja
    {
        public int PozycjaId { get; set; }
        public int Szerokosc { get; set; }
        public int Wysokosc { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public TypPozycji Typ { get; set; }
        public int? Przod { get; set; }
        public int? Tyl { get; set; }
        public int? Lewo { get; set; }
        public int? Prawo { get; set; }
        public ucPozycja Interfejs { get; set; }
        public Dictionary<Strona, IPozycja> Sasiedzi { get; set; }
        public KierunekPozycji AktualnyKierunek { get; set; }
        public int? PaletaId { get; set; }
        public string Zatoka { get; set; }
        public string Rampa { get; set; }
        public bool CzyMasterNaPozycji { get; set; }
        public Paleta Paleta { get; set; }
        public bool CzyWykonanoRuch { get; set; }

        public virtual bool CzyMozePrzyjacPalete
        {
            get { return Paleta == null; }
        }

        public void UtworzPozycje()
        {
            Interfejs = new ucPozycja(PozycjaId, Typ, X, Y, Szerokosc, Wysokosc);
            Sasiedzi = new Dictionary<Strona, IPozycja>();
            Sasiedzi.Add(Strona.Przod, null);
            Sasiedzi.Add(Strona.Tyl, null);
            Sasiedzi.Add(Strona.Lewo, null);
            Sasiedzi.Add(Strona.Prawo, null);
        }

        public void UtworzSasiadow(IEnumerable<IPozycja> pozycje, int? przod, int? tyl, int? lewo, int? prawo)
        {
            Sasiedzi[Strona.Przod] = przod.HasValue ? pozycje.FirstOrDefault(p => p.PozycjaId == przod.Value) : null;
            Sasiedzi[Strona.Tyl] = tyl.HasValue ? pozycje.FirstOrDefault(p => p.PozycjaId == tyl.Value) : null;
            Sasiedzi[Strona.Lewo] = lewo.HasValue ? pozycje.FirstOrDefault(p => p.PozycjaId == lewo.Value) : null;
            Sasiedzi[Strona.Prawo] = prawo.HasValue ? pozycje.FirstOrDefault(p => p.PozycjaId == prawo.Value) : null;
        }

        public virtual void PokazNumerPozycji()
        {
            Interfejs.PokazNumerPozycji();
        }

        public virtual void UkryjNumerPozycji()
        {
            Interfejs.UkryjNumerPozycji();
        }

        public virtual void MapujMastera(Master master) { }

        public virtual void UsunMastera() { }

        public virtual void MapujPalete(Paleta p)
        {
            Paleta = p;
            PaletaId = p.PaletaId;
            p.Interfejs.SetBounds(0, 0, 50, 50);
            Interfejs.Controls.Add(p.Interfejs);
            p.Interfejs.BringToFront();
        }

        public void UsunPalete()
        {
            Paleta = null;
            PaletaId = null;
            foreach (Control control in Interfejs.Controls)
            {
                if (control is ucPaleta)
                    Interfejs.Controls.Remove(control);
            }
        }

        public virtual void WykonajRuch(out Paleta p)
        {
            p = null;
            if (!CzyWykonanoRuch)
            {
                if (Paleta != null)
                {
                    if (Sasiedzi[Strona.Przod] != null)
                    {
                        if (Sasiedzi[Strona.Przod].CzyMozePrzyjacPalete)
                        {
                            Sasiedzi[Strona.Przod].MapujPalete(Paleta);
                            UsunPalete();
                        }
                    }

                }

                CzyWykonanoRuch = true;
            }

        }

        public void ResetujRuch()
        {
            CzyWykonanoRuch = false;
        }
    }
}
