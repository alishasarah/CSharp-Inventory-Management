using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlishaCrockfordC968
{
    public class InHouse : Part
    {
        public InHouse() { }

        public InHouse(int partsID, string name, int inventory, decimal price, int min, int max)
        {
            PartsID = partsID;
            Name = name;
            Inventory = inventory;
            Price = price;
            Minimum = min;
            Maximum = max;
            
        }

        public InHouse(int partsID, string name, int inventory, decimal price, int min, int max, int mID)
            : base(partsID, name, inventory, price, min, max)
        {
            MachineID = mID;
        }
        public int MachineID { get; set; }

    }
}
