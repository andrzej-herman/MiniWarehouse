using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSimulator.Symulator.Palety;
using WarehouseSimulator.Symulator.Pozycje;

namespace WarehouseSimulator.Symulator
{
    public class MisjaMastera
    {
        public string MisjaId { get; set; }
        public TypMisjiMastera TypMisji { get; set; }
        public StatusMisjiMastera Status { get; set; }
        public int PozycjaOdbioruId { get; set; }
        public int PozycjaDostarczeniaId { get; set; }
        public IPozycja PozycjaOdbioru { get; set; }
        public IPozycja PozycjaDostarczenia { get; set; }
        public Paleta Paleta { get; set; }
        public DateTime DataUtworzenia { get; set; }
    }
}
