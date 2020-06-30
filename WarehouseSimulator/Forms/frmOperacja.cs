using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarehouseSimulator.Forms
{
    public partial class frmOperacja : Form
    {
        private static Task task;
        private static frmOperacja instancja;
        private static string opis;
        private static int? procentUkonczenia;

        public static frmOperacja Instancja()
        {
            if (instancja == null)
                instancja = new frmOperacja();
            instancja.timer.Enabled = true;
            return instancja;
        }


        public static frmOperacja Instancja(Action work)
        {
            if (instancja == null)
                instancja = new frmOperacja();
            frmOperacja.task = Task.Factory.StartNew(work);
            instancja.timer.Enabled = true;
            return instancja;
        }

        public static frmOperacja Instancja(Task task)
        {
            if (instancja == null)
                instancja = new frmOperacja();
            frmOperacja.task = task;
            instancja.timer.Enabled = true;
            return instancja;
        }

        public frmOperacja()
        {
            InitializeComponent();
        }
    }
}
