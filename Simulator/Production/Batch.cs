using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Production
{
    public class Batch
    {
        public int Id { get; set; }
        public string BatchNumber { get; set; }
        public int ProductId { get; set; }
        public DateTime DateCreated { get; set; }
        public int NumberOfPallets { get; set; }
        public List<BatchPallet> PalletsToProduce { get; set; }

        public string Status
        {
            get
            {
                if (PalletsToProduce == null)
                    return "-/-";
                else
                {
                    var produced = NumberOfPallets - PalletsToProduce.Count();
                    return $"{produced}/{NumberOfPallets}";
                }
            }
        }
    }
}
