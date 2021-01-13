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

        private bool _Export<T>(List<T> dataAsList, string rootElementName,string childElementsName,string path)
        {


            //Get DataAsList parameter type number of properties
            int PropertiesLength = typeof(T).GetProperties().Length;
            
            //Get DataAsList parameter type properties
            var dataAsList_Properties = typeof(T).GetProperties();

            //Add the Root element into the XML document
            XDocument xdoc = new XDocument(new XElement(rootElementName));

            //Add one Child element
            xdoc.Element(rootElementName).Add(new XElement(childElementsName));


            //Determine the last DataAsList parameter Index
            int LastIndex = dataAsList.Count - 1;

            //Create an Index tracker inside the FOREACH iterations
            int IterationNumber = 0;

            foreach (var d in dataAsList)
            {
                

                    for (int i = 0; i < PropertiesLength; i++)
                    {

                        xdoc.Element(rootElementName).Element(childElementsName).Add(new XElement(dataAsList_Properties[i].Name, dataAsList_Properties[i].GetValue(d)));

                    }
                    
                    //Check if this is not the last FOREACH iteration, IF not a new element will added, IF the LAST Iteration no element will added
                    if (LastIndex != IterationNumber) 
                    {
                        //Add new XElement
                        xdoc.Element(rootElementName).Element(childElementsName).AddBeforeSelf(new XElement(childElementsName));
                        
                        //Update the Iteration Tracker
                        IterationNumber++;
                    }

                    
                    
            }


            //Save the document
            xdoc.Save(path);


            return true;

        }











        /// <summary>
        /// Export a list of data as an XML file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataAsList">Data to be exported as list</param>
        /// <param name="rootElementName">The name of the ROOT element</param>
        /// <param name="childElementsName">The name of the Child elements</param>
        /// <param name="path">The path to be export the data into</param>
        /// <returns></returns>
        public bool Export<T>(List<T> dataAsList, string rootElementName, string childElementsName, string path)
        {
            return _Export(dataAsList, rootElementName, childElementsName, path);
        }



        /// <summary>
        /// Export a list of data as an XML file, Asynchronously
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataAsList">Data to be exported as list</param>
        /// <param name="rootElementName">The name of the ROOT element</param>
        /// <param name="childElementsName">The name of the Child elements</param>
        /// <param name="path">The path to be export the data into</param>
        /// <returns></returns>
        public Task<bool> ExportAsync<T>(List<T> dataAsList, string rootElementName, string childElementsName, string path)
        {
            return Task<bool>.Factory.StartNew(() => _Export(dataAsList, rootElementName, childElementsName, path));
        }

    }
}
