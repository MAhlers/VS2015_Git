using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal? Price { get; private set; }
        public int SupplierID { get; private set; }
        
        public Product() { }

        public Product(int id, string name, int supplierID, decimal? price = null)
        {
            Id = id;
            Name = name;
            Price = price;
            SupplierID = supplierID;
        }

        public static List<Product> GetSampleProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name="West Side Story", Price = 9.99m, SupplierID=1 },
                new Product { Id = 2, Name="Assassins", Price=14.99m, SupplierID=2 },
                new Product { Id = 3, Name="Frogs", Price=13.99m, SupplierID=1 },
                new Product { Id = 4, Name="Sweeney Todd", Price=10.99m, SupplierID=3},
                new Product { Id = 5, Name="Unreleased", Price=null, SupplierID=3}
            };
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Name, Price);
        }
    }
}
