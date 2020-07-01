using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseSimulator.Kontrolki;
using WarehouseSimulator.Symulator.Palety;

namespace WarehouseSimulator.Symulator.Pozycje
{
    public class PozycjaMaster : Pozycja, IPozycja
    {
        public Master Master { get; set; }

        public override bool CzyMozePrzyjacPalete
        {
            get { return Master != null && Master.Paleta == null; }
        }

        public override void PokazNumerPozycji()
        {
            Interfejs.PokazNumerPozycji();
            if (Master != null)
                Master.Interfejs.BringToFront();
        }

        public override void UkryjNumerPozycji()
        {
            Interfejs.UkryjNumerPozycji();
            if (Master != null)
                Master.Interfejs.BringToFront();
        }


        public override void MapujPalete(Paleta p)
        {
            PaletaId = p.PaletaId;
            Master.Paleta = p;
            p.Interfejs.SetBounds(20, 20, 50, 50);
            Master.Interfejs.Controls.Add(p.Interfejs);
            Master.Interfejs.BringToFront();
        }

        public override void MapujMastera(Master master)
        {
            if (Master == null)
            {
                Master = master;
                master.Pozycja = this;
                CzyMasterNaPozycji = true;
                Interfejs.Controls.Add(master.Interfejs);
                Interfejs.BringToFront();

            }
        }

        public override void UsunMastera()
        {
            Master = null;
            CzyMasterNaPozycji = false;
            foreach (Control control in Interfejs.Controls)
            {
                if (control is ucMaster)
                    Interfejs.Controls.Remove(control);
            }

            Interfejs.SendToBack();
        }

        public override void WykonajRuch(out Paleta p)
        {
            p = null;
            if (!CzyWykonanoRuch)
            {
                if (Master != null)
                {
                    if (Master.AktywnaMisja != null)
                    {
                        if (Master.AktywnaMisja.TypMisji == TypMisjiMastera.Magazynowa)
                        {
                            if (Master.Paleta == null)
                            {
                                if (Master.Pozycja.PozycjaId != Master.AktywnaMisja.PozycjaOdbioruId)
                                {
                                    Master.RozpocznijMisje();
                                    Master.UstawRuchMastera(RuchMastera.WLewo);
                                    if (Sasiedzi[Strona.Tyl].Typ == TypPozycji.Master)
                                    {
                                        Sasiedzi[Strona.Tyl].MapujMastera(Master);
                                        UsunMastera();
                                    }

                                }
                                else
                                    Master.UstawRuchMastera(RuchMastera.BrakRuchu);
                            }
                            else
                            {
                                if (Master.Pozycja.PozycjaId != Master.AktywnaMisja.PozycjaDostarczeniaId)
                                {
                                    Master.UstawRuchMastera(RuchMastera.WPrawo);
                                    Sasiedzi[Strona.Przod].MapujMastera(Master);
                                    Sasiedzi[Strona.Przod].CzyWykonanoRuch = true;
                                    UsunMastera();
                                }
                                else
                                {
                                    foreach (var pozycja in Sasiedzi.Values)
                                    {
                                        if (pozycja.Zatoka != null)
                                        {
                                            if (pozycja.Zatoka == Master.Paleta.Destynacja)
                                            {
                                                if (pozycja.CzyMozePrzyjacPalete)
                                                    pozycja.MapujPalete(Master.Paleta);
                                            }
                                                
                                        }

                                    }
                                    Master.UsunPalete();
                                    Master.UstawRuchMastera(RuchMastera.BrakRuchu);
                                    Master.ZakonczMisje();
                                }
                                    
                            }
                            
                        }
                    }
                }

                CzyWykonanoRuch = true;
            }
        }
    }
}
