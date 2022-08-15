using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace AlishaCrockfordC968
{
    class Inventory
    {
        public static BindingList<Part> AllParts = new BindingList<Part>();
        public static BindingList<Product> Products = new BindingList<Product>();

        public static void AddProduct(Product addProduct)
        {
            Products.Add(addProduct);
        }

        public static bool RemoveProduct(Product product)
        {
            try
            {
                Products.Remove(LookupProduct(product.ProductID));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Product LookupProduct(int productID)
        {
            foreach (Product product in Products)
            {
                if (product.ProductID == productID)
                {
                    return product;
                }
            }
            Product emptyProduct = null;
            return emptyProduct;
        }
        public static void UpdatedProduct(int productID, Product updatedProduct)
        {
             foreach (Product currentProduct in Products)
             {
                  if (currentProduct.ProductID == productID)
                  {
                       currentProduct.Name = updatedProduct.Name;
                       currentProduct.Inventory = updatedProduct.Inventory;
                       currentProduct.Price = updatedProduct.Price;
                       currentProduct.Minimum = updatedProduct.Minimum;
                       currentProduct.Maximum = updatedProduct.Maximum;
                       currentProduct.AssociatedParts = updatedProduct.AssociatedParts;
                  }
              }
         }

        public static void AddPart(Part part)
        {
            AllParts.Add(part);
        }

        public static void UpdateInHousePart(int partID, InHouse inhousePart)
        {
            for (int i = 0; i < AllParts.Count; i++)
            {
                if (AllParts[i].GetType() == typeof(AlishaCrockfordC968.InHouse))
                {
                    InHouse currentPart = (InHouse)AllParts[i];

                    if (currentPart.PartsID == partID)
                    {
                         currentPart.Name = inhousePart.Name;
                         currentPart.Inventory = inhousePart.Inventory;
                         currentPart.Price = inhousePart.Price;
                         currentPart.Minimum = inhousePart.Minimum;
                         currentPart.Maximum = inhousePart.Maximum;
                         currentPart.MachineID = inhousePart.MachineID;
                    }
                }
                
            }
            
        }
        public static void UpdateOutsourcedPart(int partID, Outsourced outsourcedPart)
        {
            for (int i = 0; i < AllParts.Count; i++)
            {
                if (AllParts[i].GetType() == typeof(AlishaCrockfordC968.Outsourced))
                {
                    Outsourced currentPart = (Outsourced)AllParts[i];
                    if (currentPart.PartsID == partID)
                    {
                        currentPart.Name = outsourcedPart.Name;
                        currentPart.Inventory = outsourcedPart.Inventory;
                        currentPart.Price = outsourcedPart.Price;
                        currentPart.Minimum = outsourcedPart.Minimum;
                        currentPart.Maximum = outsourcedPart.Maximum;
                        currentPart.CompanyName = outsourcedPart.CompanyName;
                    }
                }
            }
        }
        public static bool deletePart (Part part)
        {
            try
            {
                AllParts.Remove(LookupPart(part.GetPartID()));
                return true;
            }
            catch (Exception)
            {
                return false; 
            }
        }

        public static Part LookupPart(int partsIDMatch)
        {
            Part partToReturn = null;
            foreach (Part part in AllParts)
            {
                if (part.PartsID == partsIDMatch)
                {
                    partToReturn = part;
                }
            }
            return partToReturn;
            
        }
        
        public static void updatePart(int partID, Part updatedPart)
        {
            Part selectedPart = AllParts.Where(i => i.PartsID == partID).First();
            var index = AllParts.IndexOf(selectedPart);

            if (index != -1)
            {
                AllParts[index] = updatedPart;
            }

            selectedPart = updatedPart;
        }


    }
}
