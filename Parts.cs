using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace AlishaCrockfordC968
{
    public abstract class Part
    {
        private static BindingList<Part> parts = new BindingList<Part>();
        public static BindingList<Part> Parts { get { return parts; } set { parts = value; } }
        public static Part CurrentPart { get; set; }

        public static Part NewPart { get; set; }
        public static int CurrentPartID { get; set; }
        public static int CurrentPartIndex { get; set; }
        public static string PartText { get; set; }
        public int PartsID { get; set; }
        public string Name { get; set; }
        public int Inventory { get; set; }
        public decimal Price { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }

        public Part(int partsID, string name, int inventory, decimal price, int min, int max)
        {
            PartsID = partsID;
            Name = name;
            Inventory = inventory;
            Price = price;
            Minimum = min;
            Maximum = max;
        }
        public int GetPartID()
        {
            this.PartsID = PartsID;
            return PartsID;
        }

        public Part()
        {
            return;
        }
        public Part(string name)
        {
            Name = name;
        }
    }
}
