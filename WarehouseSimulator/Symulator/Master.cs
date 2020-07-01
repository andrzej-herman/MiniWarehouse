using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseSimulator.Kontrolki;
using WarehouseSimulator.Symulator.Palety;
using WarehouseSimulator.Symulator.Pozycje;

namespace WarehouseSimulator.Symulator
{
    public class Master
    {
        public Master()
        {
            Interfejs = new ucMaster();
            UstawRuchMastera(RuchMastera.BrakRuchu);
            Misje = new List<MisjaMastera>();
        }

        public ucMaster Interfejs { get; set; }
        public RuchMastera Ruch { get; set; }
        public IPozycja Pozycja { get; set; }
        public Paleta Paleta { get; set; }
        List<MisjaMastera> Misje { get; set; }
        public IEnumerable<IPozycja> PozycjeMagazynu { get; set; }
        public MisjaMastera AktywnaMisja
        {
            get
            {
                var trwajace = Misje.Where(m => m.Status == StatusMisjiMastera.Trwajaca).OrderBy(m => m.DataUtworzenia).ToList();
                var misja = trwajace.FirstOrDefault();
                if (misja == null)
                {
                    var planowane = Misje.Where(m => m.Status == StatusMisjiMastera.Planowana).OrderBy(m => m.DataUtworzenia).ToList();
                    misja = planowane.FirstOrDefault();
                }

                return misja;
            }
        }

        public void RozpocznijMisje()
        {
            Misje.FirstOrDefault(m => m.MisjaId == AktywnaMisja.MisjaId).Status = StatusMisjiMastera.Trwajaca;
        }

        public void ZakonczMisje()
        {
            Misje.FirstOrDefault(m => m.MisjaId == AktywnaMisja.MisjaId).Status = StatusMisjiMastera.Zakonczona;
        }

        public void UstawRuchMastera(RuchMastera ruch)
        {
            Ruch = ruch;
            Interfejs.PokazKierunekRuchuMastera(ruch);
        }

        public void AktualizujPozycje(IEnumerable<IPozycja> pozycje)
        {
            PozycjeMagazynu = pozycje;
        }


        public void MapujPalete(Paleta p)
        {
            if (Paleta == null)
            {
                Paleta = p;
                Interfejs.MapujPalete(p);
            }
        }

        public void UsunPalete()
        {
            Paleta = null;
            Interfejs.UsunPalete();
        }

        public void UtworzMisjeMagazynowa(Paleta pal)
        {
            MisjaMastera misja = new MisjaMastera
            {
                MisjaId = Guid.NewGuid().ToString(),
                TypMisji = TypMisjiMastera.Magazynowa,
                Status = StatusMisjiMastera.Planowana,
                Paleta = pal,
                PozycjaOdbioruId = 401,
                PozycjaDostarczeniaId = ZnajdzPozycjeDostarczenia(pal),
                PozycjaOdbioru = PozycjeMagazynu.FirstOrDefault(p => p.PozycjaId == 401),
                DataUtworzenia = DateTime.Now
            };

            misja.PozycjaDostarczenia = PozycjeMagazynu.FirstOrDefault(p => p.PozycjaId == misja.PozycjaDostarczeniaId);
            Misje.Add(misja);
        }

        private int ZnajdzPozycjeDostarczenia(Paleta p)
        {
            if (p.Destynacja == "M1" || p.Destynacja == "M2")
                return 405;
            else if (p.Destynacja == "M3" || p.Destynacja == "M4")
                return 406;
            else if (p.Destynacja == "M5" || p.Destynacja == "M6")
                return 404;
            else if (p.Destynacja == "M7" || p.Destynacja == "M8")
                return 407;
            else if (p.Destynacja == "M9" || p.Destynacja == "M10")
                return 403;
            else if (p.Destynacja == "M11" || p.Destynacja == "M12")
                return 408;
            else if (p.Destynacja == "M13" || p.Destynacja == "M14")
                return 402;
            else if (p.Destynacja == "M15" || p.Destynacja == "M16")
                return 409;
            else if (p.Destynacja == "M17" || p.Destynacja == "M18")
                return 401;
            else
                return 410;
        }
    }
}
