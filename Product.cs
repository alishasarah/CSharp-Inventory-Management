using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace AlishaCrockfordC968
{
    public class Product
    {
        private static BindingList<Product> products = new BindingList<Product>();

        public BindingList<Part> AssociatedParts = new BindingList<Part>();

        public static BindingList<Product> Products { get { return products; } set { products = value; } }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Inventory { get; set; }
        public decimal Price { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }

        public Product(int productID, string name, int inventory, decimal price, int min, int max)
        {
            ProductID = productID;
            Name = name;
            Inventory = inventory;
            Price = price;
            Minimum = min;
            Maximum = max;

        }

        public void AddAssociatedPart(Part part)
        {
            AssociatedParts.Add(part);
        }

        public bool RemoveAssociatedPart(int partID)
        {
            bool success = false;
            foreach (Part part in AssociatedParts)
            {
                if (part.PartsID == partID)
                {
                    AssociatedParts.Remove(part);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return success;
        }

        public Part LookupAssociatedPart(int partID)
        {
            foreach (Part part in AssociatedParts)
            {
                if (part.PartsID == partID)
                {
                    return part;
                }
            }
            return null;
        }
    }

}


