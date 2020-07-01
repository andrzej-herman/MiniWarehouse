using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSimulator.Kontrolki;
using WarehouseSimulator.Symulator.Produkcja;

namespace WarehouseSimulator.Symulator.Palety
{
    public class Paleta
    {
        public Paleta()
        {
            Interfejs = new ucPaleta();
        }

        public int PaletaId { get; set; }
        public string KodKreskowy { get; set; }
        public Produkt Produkt { get; set; }
        public DateTime DataProdukcji { get; set; }
        public int PartiaProdukcyjnaId { get; set; }
        public StanPalety Stan { get; set; }
        public string Destynacja { get; set; }
        public ucPaleta Interfejs { get; set; }

        public DateTime DataPrzydatnosci
        {
            get { return DataProdukcji.AddDays(Produkt.TerminPrzydatnosciWDniach); }
        }

        public void UtworzPalete()
        {
            Interfejs.UtworzPalete(this);
        }

    }
}
