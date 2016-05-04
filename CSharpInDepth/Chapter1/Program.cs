using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using cm = System.Configuration.ConfigurationManager;
using c = System.Console;

namespace Chapter1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = Product.GetSampleProducts();

            c.WriteLine("\n--Ordering--");

            //Ordering by name via Lambda inside List OrderBy
            foreach (Product product in products.OrderBy(p => p.Name))
            {
                c.WriteLine(product);
            }

            c.WriteLine("\n--Testing via Lambda--");

            //Testing via Lambda
            foreach (Product product in products.Where(p => p.Price > 10))
            {
                c.WriteLine(product);
            }

            c.WriteLine("\n--Testing nulls--");

            //Testing Unknown Prices via Lambda
            foreach (Product product in products.Where(p => p.Price == null))
            {
                c.WriteLine(product);
            }

            c.WriteLine("\n--LINQ (Language-Integrated Query)--");

            //Querying with LINQ
            var filtered = from Product p in products
                           where p.Price > 10
                           select p;

            foreach (Product product in filtered)
            {
                c.WriteLine(product);
            }

            c.WriteLine("\n--Querying XML--");

            //Querying with LINQ
            string xmlData = cm.AppSettings.Get("XMLData");

            XDocument doc = XDocument.Load(xmlData);
            var filteredXML = from p in doc.Descendants("Product")
                              join s in doc.Descendants("Supplier")
                                on (int)p.Attribute("SupplierID")
                                equals (int)s.Attribute("SupplierID")
                              where (decimal)p.Attribute("Price") > 10
                              orderby (string)s.Attribute("Name"),
                              (string)p.Attribute("Name")
                              select new
                              {
                                  SupplierName = (string)s.Attribute("Name"),
                                  ProductName = (string)p.Attribute("Name")
                              };

            foreach (var v in filteredXML)
            {
                c.WriteLine("Supplier={0}; Product={1}", v.SupplierName, v.ProductName);
            }
            
            c.WriteLine("\n--LINQ to SQL--");

            //LINQ to SQL

            c.ReadLine();
        }
    }
}
