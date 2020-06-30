using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSimulator.BazaDanych;
using WarehouseSimulator.Kontrolki;

namespace WarehouseSimulator.Logika
{
    public class Pozycja : IPozycja
    {
        public int PozycjaId { get; set; }
        public int Szerokosc { get; set; }
        public int Wysokosc { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public TypPozycji Typ { get; set; }
        public ucPozycja Interfejs { get; set; }

        public void UtworzPozycje()
        {
            Interfejs = new ucPozycja(PozycjaId, Typ, X, Y, Szerokosc, Wysokosc);
        }
    }
}
