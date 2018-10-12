using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace BusinessObjectLayer.Common
{
    public static class SerializeDeserialize
    {
        /// <summary>
        /// Serialize an object into XML.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static String SerializeAnObject(Object obj)
        {
            XmlDocument doc = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            MemoryStream stream = new MemoryStream();
            try
            {
                serializer.Serialize(stream, obj);
                stream.Position = 0;
                doc.Load(stream);
                return doc.InnerXml;
            }
            catch
            {
                throw;
            }
            finally
            {
                stream.Close();
                stream.Dispose();
            }
        }

        /// <summary>
        /// Deserialize an object from XML.
        /// </summary>
        /// <param name="xmlOfAnObject"></param>
        /// <returns></returns>
        public static Object DeserializeAnObject(String xmlOfAnObject,Type type)
        {
            Object obj = new Object();
            StringReader read = new StringReader(xmlOfAnObject);
            XmlSerializer serializer = new XmlSerializer(type);
            XmlReader reader = new XmlTextReader(read);
            try
            {
                obj = (Object)serializer.Deserialize(reader);
                return obj;
            }
            catch
            {
                throw;
            }
            finally
            {
                reader.Close();
                read.Close();
                read.Dispose();
            }
        }
    }
}
