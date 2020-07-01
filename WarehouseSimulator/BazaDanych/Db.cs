using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSimulator.Symulator.Pozycje;
using WarehouseSimulator.Symulator;
using WarehouseSimulator.Symulator.Produkcja;
using WarehouseSimulator.Symulator.Palety;

namespace WarehouseSimulator.BazaDanych
{
    public class Db
    {
        private MagazynContext magazynContext;
        private ProdukcjaContext produkcjaContext;

        public Db()
        {
            this.magazynContext = new MagazynContext();
            this.produkcjaContext = new ProdukcjaContext();
        }

        public List<Paleta> PobierzListePalet(List<Produkt> produkty)
        {
            var wynik = new List<Paleta>();
            var paletyDb = magazynContext.Palety.ToList();
            foreach (var p in paletyDb)
            {
                wynik.Add(new Paleta
                {
                    PaletaId = p.PaletaId,
                    KodKreskowy = p.KodKreskowy,
                    Produkt = produkty.FirstOrDefault(pr => pr.ProduktId == p.ProduktId),
                    DataProdukcji = p.DataProdukcji,
                    PartiaProdukcyjnaId = p.PartiaProdukcyjnaId,
                    Stan = (StanPalety)p.StanPaletyId,
                    Destynacja = p.Destynacja
                });
            }

            return wynik.OrderBy(p => p.PaletaId).ToList();
        }


        public List<Produkt> PobierzListeProduktow()
        {
            return produkcjaContext.Produkty.Select(p => new Produkt
            {
                ProduktId = p.ProduktId,
                Nazwa = p.Nazwa,
                TerminPrzydatnosciWDniach = p.TerminPrzydatnosciWDniach,
                KolorId = p.Kolor,
                CzcionkaId = p.Czcionka
            }
            ).ToList();
        }


        public IEnumerable<IPozycja> PobierzListePozycji()
        {
            var wynik = new List<IPozycja>();
            var pozycjeZBazy = magazynContext.Pozycje;

            foreach (var p in pozycjeZBazy)
            {
                var typ = (TypPozycji)p.TypPozycjiId;
                switch (typ)
                {
                    case TypPozycji.Produkcja:
                    case TypPozycji.Podstawowa:
                    case TypPozycji.Dwukierunkowa:
                    case TypPozycji.Naprawa:
                    case TypPozycji.Inspekcja:
                    case TypPozycji.Magazyn:
                    case TypPozycji.Rampa:
                    case TypPozycji.Rozjazd:
                        wynik.Add(new Pozycja
                        {
                            PozycjaId = p.PozycjaId,
                            Szerokosc = p.Szerokosc,
                            Wysokosc = p.Wysokosc,
                            X = p.X,
                            Y = p.Y,
                            Typ = (TypPozycji)p.TypPozycjiId,
                            Przod = p.Przod,
                            Tyl = p.Tyl,
                            Lewo = p.Lewo,
                            Prawo = p.Prawo,
                            AktualnyKierunek = (KierunekPozycji)p.AktualnyKierunek,
                            Zatoka = p.Zatoka,
                            Rampa = p.Rampa,
                            PaletaId = p.PaletaId,
                            CzyMasterNaPozycji = p.CzyMasterNaPozycji
                        });
                        break;
                    case TypPozycji.Master:
                        wynik.Add(new PozycjaMaster
                        {
                            PozycjaId = p.PozycjaId,
                            Szerokosc = p.Szerokosc,
                            Wysokosc = p.Wysokosc,
                            X = p.X,
                            Y = p.Y,
                            Typ = (TypPozycji)p.TypPozycjiId,
                            Przod = p.Przod,
                            Tyl = p.Tyl,
                            Lewo = p.Lewo,
                            Prawo = p.Prawo,
                            AktualnyKierunek = (KierunekPozycji)p.AktualnyKierunek,
                            Zatoka = p.Zatoka,
                            Rampa = p.Rampa,
                            PaletaId = p.PaletaId,
                            CzyMasterNaPozycji = p.CzyMasterNaPozycji
                        });
                        break;
                    case TypPozycji.Kontrola:
                        wynik.Add(new PozycjaKontrola
                        {
                            PozycjaId = p.PozycjaId,
                            Szerokosc = p.Szerokosc,
                            Wysokosc = p.Wysokosc,
                            X = p.X,
                            Y = p.Y,
                            Typ = (TypPozycji)p.TypPozycjiId,
                            Przod = p.Przod,
                            Tyl = p.Tyl,
                            Lewo = p.Lewo,
                            Prawo = p.Prawo,
                            AktualnyKierunek = (KierunekPozycji)p.AktualnyKierunek,
                            Zatoka = p.Zatoka,
                            Rampa = p.Rampa,
                            PaletaId = p.PaletaId,
                            CzyMasterNaPozycji = p.CzyMasterNaPozycji
                        });
                        break;
                }
            }

            return wynik.OrderBy(p=> p.PozycjaId).ToList();

        }



    }
}
