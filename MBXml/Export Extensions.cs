using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBXml
{

        public static class ExportExtensions
        {


            /// <summary>
            /// Export a list of data as an XML file
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="dataAsList">Data to be exported as list</param>
            /// <param name="rootElementName">The name of the ROOT element</param>
            /// <param name="childElementsName">The name of the Child elements</param>
            /// <param name="path">The path to be export the data into</param>
            /// <returns></returns>
            public static bool ExportAsXML<T>(this List<T> dataAsList, string rootElementName, string childElementsName, string path)
            {
                return new XMExporter().Export(dataAsList, rootElementName, childElementsName, path);
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
            public static Task<bool> ExportAsXMLAsync<T>(this List<T> dataAsList, string rootElementName, string childElementsName, string path) where T : class
            {
                return new XMExporter().ExportAsync(dataAsList, rootElementName, childElementsName, path);
            }



        
        }

}
