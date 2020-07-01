using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSimulator.Symulator
{
    public enum TypPozycji
    {
        Produkcja = 1,
        Podstawowa = 2,
        Dwukierunkowa = 3,
        Kontrola = 4,
        Naprawa = 5,
        Inspekcja = 6,
        Magazyn = 7,
        Master = 8,
        Rampa = 9,
        Rozjazd = 10,
        Wejscie = 11
    }

    public enum Strona
    {
        Przod = 1,
        Tyl = 2,
        Lewo = 3,
        Prawo = 4
    }

    public enum KierunekPozycji
    {
        DoPrzodu = 1,
        DoTylu = 2
    }

    public enum RuchMastera
    {
        BrakRuchu = 0,
        WPrawo = 1,
        WLewo = 2
    }

    public enum StanPalety
    {
        Ok = 1,
        Uszkodzona = 2,
        NieczytelnyKodKreskowy = 3
    }

    public enum TypMisjiMastera
    {
        Magazynowa = 1,
        Zamowieniowa = 2,
        Inspekcyjna = 3
    }

    public enum StatusMisjiMastera
    {
        Planowana = 1,
        Trwajaca = 2,
        Zakonczona = 3
    }
}
