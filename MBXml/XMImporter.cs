using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MBXml
{
    /// <summary>
    /// To import data from an XML file
    /// </summary>
    public class XMImporter
    {

        private XDocument _Import(string filePath)
        {
            //Load the XML document
            XDocument XDoc = XDocument.Load(filePath);

            return XDoc;
        }






        /// <summary>
        /// Import/Load an XML file from path
        /// </summary>
        /// <param name="filePath">Path of file to be imported</param>
        /// <returns></returns>
        public XDocument Import(string filePath)
        {
            return _Import(filePath);
        } 



        
        /// <summary>
        /// Import/Load an XML file from path, Asynchronously
        /// </summary>
        /// <param name="filePath">Path of file to be imported</param>
        /// <returns></returns>
        public Task<XDocument> ImportAsync(string filePath)
        {
            return Task.Factory.StartNew(() => _Import(filePath));
        } 

    }
}
