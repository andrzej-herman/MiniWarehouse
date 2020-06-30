using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSimulator.Logika;

namespace WarehouseSimulator.BazaDanych
{
    public class Db
    {
        private PozycjeContext context;

        public Db()
        {
            this.context = new PozycjeContext();
        }

        public IEnumerable<IPozycja> PobierzListePozycji()
        {
            return context.Pozycje.Select(p => new Pozycja
            {
                PozycjaId = p.PozycjaId,
                Szerokosc = p.Szerokosc,
                Wysokosc = p.Wysokosc,
                X = p.X,
                Y = p.Y,
                Typ = (TypPozycji)p.TypPozycjiId
            }
            ).ToList();

        }
    }
}
