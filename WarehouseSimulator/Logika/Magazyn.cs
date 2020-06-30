using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseSimulator.BazaDanych;
using WarehouseSimulator.Forms;
using WarehouseSimulator.Kontrolki;
using WarehouseSimulator.Properties;

namespace WarehouseSimulator.Logika
{
    public class Magazyn
    {
        private Form okno;
        private Db komunikatorDb;
        private IEnumerable<IPozycja> pozycje;

        public Magazyn(Form _okno)
        {
            okno = _okno;
            komunikatorDb = new Db();
        }


                                                    
        #region Tworzenie magazynu
        public void UtworzMagazyn()
        {
            UtworzPozycje();
            UtworzElementyDodatkowe();
        }

        private void UtworzPozycje()
        {
            pozycje = komunikatorDb.PobierzListePozycji();
            foreach (var pozycja in pozycje)
            {
                pozycja.UtworzPozycje();
                okno.Controls.Add(pozycja.Interfejs);
            }
        }

        private void UtworzElementyDodatkowe()
        {
            Bitmap[] ciezarowki = new Bitmap[4] { Resources.truck_01, Resources.truck_02, Resources.truck_03, Resources.truck_04 };
            int[] y = new int[4] { 110, 335, 614, 838 };
            for (int idx = 0; idx < 4; idx++)
            {
                PictureBox pb = new PictureBox();
                pb.Image = ciezarowki[idx];
                pb.SetBounds(1853, y[idx], 50, 107);
                okno.Controls.Add(pb);
            }

            y = new int[2] { 83, 951 };
            for (int idx = 0; idx < 2; idx++)
            {
                Panel p = new Panel();
                p.BackColor = Color.DarkBlue;
                p.SetBounds(1517, y[idx], 387, 20);
                okno.Controls.Add(p);
            }

            y = new int[6] { 223, 309, 448, 588, 727, 812 };
            for (int idx = 0; idx < 6; idx++)
            {
                Panel p = new Panel();
                p.BackColor = Color.DarkBlue;
                p.SetBounds(1629, y[idx], 274, 20);
                okno.Controls.Add(p);
            }

            y = new int[2] { 39, 1010 };
            for (int idx = 0; idx < 2; idx++)
            {
                Panel p = new Panel();
                p.BackColor = Color.DarkBlue;
                p.SetBounds(475, y[idx], 1006, 10);
                okno.Controls.Add(p);
            }

            int[] x = new int[4] {475, 1471, 475, 1471 };
            y = new int[4] { 39, 39, 561, 561 };
            for (int idx = 0; idx < 4; idx++)
            {
                Panel p = new Panel();
                p.BackColor = Color.DarkBlue;
                p.SetBounds(x[idx], y[idx],  10, 458);
                okno.Controls.Add(p);
            }

            int[] numer = new int[20] { 17, 13, 9, 5, 1, 3, 7, 11, 15, 19, 18, 14, 10, 6, 2, 4, 8, 12, 16, 20 };
            int xx = 521;
            int zz = 521;
            int yy = 60; 
            for (int idx = 0; idx < 20; idx++)
            {
                if (idx > 9)
                    yy = 972;

                ucNazwaZatoki nazwaZatoki = new ucNazwaZatoki(numer[idx]);
                if (idx <= 9)
                {
                    nazwaZatoki.SetBounds(xx, yy, 50, 25);
                    xx += 96;
                }
                else
                {
                    nazwaZatoki.SetBounds(zz, yy, 50, 25);
                    zz += 96;
                }    

                okno.Controls.Add(nazwaZatoki);
            }


        } 
        #endregion





    }
}
