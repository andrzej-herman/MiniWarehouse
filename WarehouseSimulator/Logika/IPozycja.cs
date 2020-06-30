using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSimulator.Kontrolki;

namespace WarehouseSimulator.Logika
{
    public interface IPozycja
    {
        ucPozycja Interfejs { get; set; }
        void UtworzPozycje();
    }
}
