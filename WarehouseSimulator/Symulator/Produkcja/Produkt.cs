using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSimulator.Symulator.Produkcja
{
    public class Produkt
    {
        public int ProduktId { get; set; }
        public string Nazwa { get; set; }
        public int AktualnyKodKreskowy { get; set; }
        public int TerminPrzydatnosciWDniach { get; set; }
        public string KolorId { get; set; }
        public string CzcionkaId { get; set; }

        public Color KolorTla
        {
            get { return ColorTranslator.FromHtml(KolorId);  }
        }

        public Color KolorCzcionki
        {
            get { return ColorTranslator.FromHtml(CzcionkaId); }
        }

    }
}
