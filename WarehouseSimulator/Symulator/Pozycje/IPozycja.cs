using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSimulator.Kontrolki;
using WarehouseSimulator.Symulator.Palety;

namespace WarehouseSimulator.Symulator.Pozycje
{
    public interface IPozycja
    {
        ucPozycja Interfejs { get; set; }
        int PozycjaId { get; set; }
        TypPozycji Typ { get; set; }
        int? Przod { get; set; }
        int? Tyl { get; set; }
        int? Lewo { get; set; }
        int? Prawo{ get; set; }
        int? PaletaId { get; set; }
        string Zatoka { get; set; }
        Paleta Paleta { get; set; }
        bool CzyMasterNaPozycji { get; set; }
        bool CzyWykonanoRuch { get; set; }
        bool CzyMozePrzyjacPalete { get; }
        void UtworzPozycje();
        void UtworzSasiadow(IEnumerable<IPozycja> pozycje, int? przod, int? tyl, int? lewo, int? prawo);
        void MapujMastera(Master master);
        void UsunMastera();
        void PokazNumerPozycji();
        void UkryjNumerPozycji();
        void MapujPalete(Paleta p);
        void UsunPalete();
        void WykonajRuch(out Paleta p);
        void ResetujRuch();
    }
}
