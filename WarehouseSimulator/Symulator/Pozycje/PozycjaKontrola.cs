using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSimulator.Symulator.Palety;

namespace WarehouseSimulator.Symulator.Pozycje
{
    public class PozycjaKontrola : Pozycja, IPozycja
    {
        public override void MapujPalete(Paleta p)
        {
            Paleta = p;
            PaletaId = p.PaletaId;
            p.Interfejs.SetBounds(20, 20, 50, 50);
            Interfejs.Controls.Add(p.Interfejs);
            p.Interfejs.BringToFront();
        }

        public override void WykonajRuch(out Paleta p)
        {
            p = null;
            if (!CzyWykonanoRuch)
            {
                if (Paleta != null)
                {
                    if (Paleta.Stan == StanPalety.Ok)
                    {
                        Paleta.Destynacja = "M1";
                        p = Paleta;
                        if (Sasiedzi[Strona.Przod].CzyMozePrzyjacPalete)
                        {
                            Sasiedzi[Strona.Przod].MapujPalete(Paleta);
                            UsunPalete();
                        }
                    }
                    else
                    {
                        if (Sasiedzi[Strona.Prawo].Paleta == null)
                        {
                            Sasiedzi[Strona.Prawo].MapujPalete(Paleta);
                            UsunPalete();
                        }
                    }

 
                }

                CzyWykonanoRuch = true;
            }
        }
    }
}
