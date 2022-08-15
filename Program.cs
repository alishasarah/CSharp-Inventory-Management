using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlishaCrockfordC968
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Part examplePart1 = new InHouse(1, "Seat Covers", 12, 39.99m, 4, 20, 55);
            Part examplePart2 = new InHouse(2, "Windshield Wipers", 16, 9.99m, 1, 20, 56);
            Part examplePart3 = new InHouse(3, "Air freshener", 10, 5.99m, 2, 16, 57);
            Part examplePart4 = new Outsourced(4, "Tires", 12, 109.99m, 4, 20, "Michelin");
            Part examplePart5 = new Outsourced(5, "Wheels", 16, 159.99m, 1, 20, "Subaru");
            Part examplePart6 = new Outsourced(6, "Brakes", 8, 139.99m, 2, 16, "BrakeMaster");

            Inventory.AllParts.Add(examplePart1);
            Inventory.AllParts.Add(examplePart2);
            Inventory.AllParts.Add(examplePart3);
            Inventory.AllParts.Add(examplePart4);
            Inventory.AllParts.Add(examplePart5);
            Inventory.AllParts.Add(examplePart6);

            Product exampleProduct1 = new Product(1, "Toyota Tacoma", 6, 25000m, 1, 10);
            Product exampleProduct2 = new Product(2, "Ford F150", 6, 30000m, 1, 10);
            Product exampleProduct3 = new Product(3, "Honda Ridgeline", 6, 28000m, 1, 10);

            Inventory.Products.Add(exampleProduct1);
            Inventory.Products.Add(exampleProduct2);
            Inventory.Products.Add(exampleProduct3);

            exampleProduct1.AddAssociatedPart(examplePart1);
            exampleProduct1.AddAssociatedPart(examplePart2);
            exampleProduct1.AddAssociatedPart(examplePart3);
            exampleProduct2.AddAssociatedPart(examplePart4);
            exampleProduct2.AddAssociatedPart(examplePart5);
            exampleProduct2.AddAssociatedPart(examplePart6);



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainScreen());
        }
    }
}
