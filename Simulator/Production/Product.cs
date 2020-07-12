using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Production
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ExpirationDays { get; set; }
        public string Symbol
        {
            get { return Name.Substring(0, 1); }
        }

        public override string ToString()
        {
            string type = ExpirationDays <= 30 ? "HR" : "DS";
            return $"{Name} ({type})";
        }
    }
}
