using Simulator.Production;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulator.Forms
{
    public partial class frmGenerateBatch : Form
    {
        private List<Product> _products;
        public Product SelectedProduct { get; set; }
        public int NumberOfPallets { get; set; }

        public frmGenerateBatch(List<Product> products)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            _products = products;
            Init();
            btnCreateBatch.Focus();
        }

        private void Init()
        {
            foreach (var product in _products)
            {         
                cmbProducts.Items.Add(product.ToString());
            }
        }

        private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCreateBatch.Focus();
        }

        private void btnCreateBatch_Click(object sender, EventArgs e)
        {
            if (cmbProducts.SelectedItem != null)
            {
                var item = cmbProducts.SelectedIndex;
                SelectedProduct = _products.First(p => p.Id == item + 1);
                NumberOfPallets = (int)numericUpDown1.Value;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
