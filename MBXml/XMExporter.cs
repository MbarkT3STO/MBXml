using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MBXml
{

    /// <summary>
    /// To Export data as an XML file
    /// </summary>
    class XMExporter
    {

        private bool _Export<T>(List<T> dataAsList, string rootElementName,string path)
        {
            XDocument xdoc = new XDocument(new XElement(rootElementName));

            //Get DataAsList parameter type number of properties
            int PropertiesLength = typeof(T).GetProperties().Length;
            
            //Get DataAsList parameter type properties
            var dataAsList_Properties = typeof(T).GetProperties();


            foreach (var d in dataAsList)
            {
                
            }


        }

    }
}
