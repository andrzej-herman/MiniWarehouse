using Simulator.Controls;
using Simulator.Database;
using Simulator.Helpers;
using Simulator.WarehouseData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Simulator.Production
{
    public class ProductionGenerator
    {
        #region Constructor
        public ProductionGenerator(SimulatorContext context)
        {
            _dbContext = context;
            IsRunning = false;
            productionTimer = new Timer(5000d);
            productionTimer.Elapsed += ProductionTimer_Elapsed;
            productionTimer.Stop();
            GetProducts();
            GetActiveBatch();
        }
        #endregion

        #region Private

        private Timer productionTimer;
        private readonly SimulatorContext _dbContext;
        private List<Product> _products { get; set; }
        private Batch _activeBatch;

        private void ProductionTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Time?.Invoke(this);
        }

        private void GetActiveBatch()
        {
            var pallets = _dbContext.PartiePalety.ToList();
            if (pallets == null || pallets.Count() == 0)
            {
                _activeBatch = null;
                return;
            }

            var batchId = pallets.First().PartiaId;
            _activeBatch = Mapper.DbBatchToBatch(_dbContext.Partie.FirstOrDefault(par => par.PartiaId == batchId));
            _activeBatch.PalletsToProduce = pallets.Select(pal => Mapper.DbBatchPalletToBatchPallet(pal)).OrderBy(pal => pal.Id).ToList();
        }

        private void GetProducts()
        {
            var dbProducts = _dbContext.Produkty.ToList();
            _products = dbProducts.Select(p => Mapper.DbProductToProduct(p)).ToList();
        }

        private string GetBatchNumber(string productName)
        {
            return $"{DateTime.Now.Day:00}{DateTime.Now.Hour:00}{DateTime.Now.Minute:00}/{productName}/{Rand.GetRandomBatchNumber()}";
        }

        private string CreateBarcode(Product p, int batchId, DateTime batchCreationDate, int index)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(p.Id.ToString("00"));
            if (p.ExpirationDays <= 30)
                sb.Append("1");
            else
                sb.Append("2");

            sb.Append(batchId.ToString("000000"));
            sb.Append("XXXXXXXX");
            DateTime exDate = batchCreationDate.AddDays(p.ExpirationDays);
            sb.Append(exDate.Year.ToString());
            sb.Append(exDate.Month.ToString("00"));
            sb.Append(exDate.Day.ToString("00"));
            sb.Append(index.ToString("00000"));
            var t = sb.ToString();
            var ile = t.Length;
            return sb.ToString();
        }

        private DateTime GetExpirationDate(string barcode)
        {
            int year = Convert.ToInt32(barcode.Substring(17, 4));
            int month = Convert.ToInt32(barcode.Substring(21, 2));
            int day = Convert.ToInt32(barcode.Substring(23, 2));
            return new DateTime(year, month, day, 0, 0, 0, 0);
        }

        private string GetProductName(string barcode)
        {
            int prodId = Convert.ToInt32(barcode.Substring(0, 2));
            return _products.First(p => p.Id == prodId).Name;
        }

        #endregion

        #region Public

        public delegate void Activation(object sender);
        public event Activation Time;

        public bool IsRunning { get; set; }

        public bool CanCreateBatch
        {
            get
            {
                return _activeBatch == null;
            }        
        }

        public bool CanRun
        {
            get
            {
                return _activeBatch != null;
            }
        }

        public Batch ActiveBatch
        {
            get { return _activeBatch; }
        }

        public List<Product> Products
        {
            get { return _products; }
        }

        public void TurnOn()
        {
            IsRunning = true;
            productionTimer.Start();
        }

        public void TurnOff()
        {
            IsRunning = false;
            productionTimer.Stop();
        }

        public void CreateBatch(int productId, int numberOfPallets)
        {
            var _product = _products.FirstOrDefault(product => product.Id == productId);
            if (_product != null)
            {
                Partie p = new Partie
                {
                    NumerPartii = GetBatchNumber(_product.Symbol),
                    ProduktId = _product.Id,
                    DataUtworzenia = DateTime.Now,
                    IloscPalet = numberOfPallets
                };

                _dbContext.Partie.Add(p);
                _dbContext.SaveChanges();
                List<PartiePalety> paletyPartii = new List<PartiePalety>();
                for (int idx = 0; idx < numberOfPallets; idx++)
                {
                    PartiePalety pp = new PartiePalety
                    {
                        Oznaczenie = _product.Symbol,
                        KodKreskowy = CreateBarcode(_product, p.PartiaId, p.DataUtworzenia, idx + 1),
                        PartiaId = p.PartiaId,
                        StateId = Rand.GetRandomPalletStateId()
                    };

                    paletyPartii.Add(pp);
                }

                _dbContext.PartiePalety.AddRange(paletyPartii);
                _dbContext.SaveChanges();
                GetActiveBatch();
            }
        }


        public Pallet CreateNewPallet()
        {
            if (_activeBatch != null)
            {
                var bp = _activeBatch.PalletsToProduce.FirstOrDefault();
                if (bp != null)
                {
                    var date = DateTime.Now;
                    var pallet = new Pallet
                    {
                        Id = bp.Id,
                        Symbol = bp.Symbol,
                        State = (PalletState)bp.StateId,
                        ProductionDate = date,
                        Destination = null,
                        Barcode = bp.Barcode.Replace("XXXXXXXX", $"{date.Year}{date.Month:00}{date.Day:00}"),
                        Type = (PalletType)Convert.ToInt32(bp.Barcode.Substring(2, 1)),
                        BatchNumber = _activeBatch.BatchNumber,
                        ExpirationDate = GetExpirationDate(bp.Barcode),
                        ProductName = GetProductName(bp.Barcode),
                        Display = new ucPallet()
                    };

                    var db = Mapper.PalletToDbPalet(pallet);
                    _dbContext.Palety.Add(db);
                    var toRemove = _dbContext.PartiePalety.First(tr => tr.PaletaId == bp.Id);
                    _dbContext.PartiePalety.Remove(toRemove);
                    _dbContext.SaveChanges();
                    GetActiveBatch();
                    return pallet;
                }
                else
                    return null;
            }
            else
                return null;
        }

        public void Enable()
        {
            productionTimer.Enabled = true;
        }

        public void Disable()
        {
            productionTimer.Enabled = false;
        }

        #endregion

    }
}
