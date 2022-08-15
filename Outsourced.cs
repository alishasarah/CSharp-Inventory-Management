using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlishaCrockfordC968
{
    public class Outsourced : Part
    {
        public string CompanyName { get; set; }
        public Outsourced()

        {
        }

        public Outsourced(int partsID, string name, int inventory, decimal price, int min, int max) : base(partsID, name, inventory, price, min, max)
        {
        }

        public Outsourced(int partsID, string name, int inventory, decimal price, int min, int max, string cName)
            : base(partsID, name, inventory, price, min, max)
        {
            CompanyName = cName;
        }
    }
}
