using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Production
{
    public class BatchPallet
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Barcode { get; set; }
        public int BatchId { get; set; }
        public int StateId { get; set; }
    }
}
