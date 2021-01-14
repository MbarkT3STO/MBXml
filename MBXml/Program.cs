﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MBXml
{
    class Program
    {

        private static readonly List<Order> Orders = new List<Order>
                                                     {
                                                         new Order(1, "Ennasiri Ali", "PRD-1", 1500),
                                                         new Order(2, "Badaoui Inas", "PRD-1", 2000),
                                                         new Order(3, "Baddouh Ali", "PRD-3", 1000),
                                                         new Order(4, "Mouslim Kawtar", "PRD-2", 3500),
                                                         new Order(5, "Essalmi Karim", "PRD-1", 2000),
                                                         new Order(6, "Nousayr Ahmed", "PRD-1", 2000),
                                                         new Order(7, "Mersaoui Fatima", "PRD-3", 1000),
                                                         new Order(8, "Fanar Adil", "PRD-1", 2200),
                                                         new Order(9, "Eddawdi Nawal", "PRD-2", 3200),
                                                         new Order(10, "Houmam Karim", "PRD-1", 2400),
                                                         new Order(11, "Ennasiri Ali", "PRD-2", 2000),
                                                         new Order(12, "Ennasiri Ali", "PRD-3", 3500),
                                                         new Order(13, "Essalmi Karim", "PRD-2", 1500),
                                                         new Order(14, "Eddawdi Nawal", "PRD-1", 2000)
                                                     };

        static async Task Main(string[] args)
        {

            //XDocument doc = new XDocument(new XElement("Orders",
            //                                           new XElement("Client", "CLT-1"),
            //                                           new XElement("Total", "5000 MAD")));
            //doc.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\xxx.xml");

            //-------------------------------------------------------------------------------------------------------------------------------
            //Examples
            //-------------------------------------------------------------------------------------------------------------------------------


            //-------------------------------------------------------------------------------------------------------------------------------
            //Export data to XML
            //-------------------------------------------------------------------------------------------------------------------------------

            //XMExporter xporter = new XMExporter();

            //---------------------------------
            /* ex 1 - Export data to XML*/
            //---------------------------------
            //Console.WriteLine("Wait...");
            //await  xporter.ExportAsync(Orders,"Orders","Order",Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\xxx.xml");
            //Console.WriteLine("Exported");

            //---------------------------------
            /* ex 2 - Export data to XML*/
            //---------------------------------
            //Console.WriteLine( "Wait..." );
            //await Orders.ExportAsXMLAsync( "Orders" , "Order" , Environment.GetFolderPath( Environment.SpecialFolder.Desktop ) + "\\xxx.xml" );
            //Console.WriteLine( "Exported" );


            //-------------------------------------------------------------------------------------------------------------------------------
            //Import data from XML
            //-------------------------------------------------------------------------------------------------------------------------------

            XMImporter Importer = new XMImporter();

            //---------------------------------
            /*Import XML data from local storage*/
            //---------------------------------

            Console.WriteLine("Wait...");

            //var Doc =  await Importer.ImportAsync(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\XXX.xml");
            var Doc =  await Importer.ImportAsync("https://file.io/3YEFNjb48xHW");

            var R = (from x in Doc.Root.Elements("Order")
                     select new
                            {
                                ID      = x.Element("ID").Value,
                                Client  = x.Element("Client").Value,
                                Product = x.Element("Product").Value,
                                Total   = x.Element("Total").Value
                            });


            foreach (var o in R)
            {
                Console.WriteLine($"{o.ID}, {o.Client}, {o.Product}, {o.Total}");
            }

            Console.WriteLine("Done...");


            Console.ReadKey();

        }
    }
}
