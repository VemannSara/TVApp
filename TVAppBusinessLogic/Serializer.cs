using System.Text;
using System.Xml.Serialization;

namespace TVAppBusinessLogic;

public class Serializer<T> where T: class 
{
    public static string Serialize(T obj)
    {
        XmlSerializer xmlser = new XmlSerializer(typeof(T));

        using (MemoryStream ms = new MemoryStream())
        {
            xmlser.Serialize(ms, obj);
            ms.Seek(0, SeekOrigin.Begin);
            using (var reader = new StreamReader(ms, Encoding.UTF8, false, 1024, true))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
        
    
       
        //using (var sw = new StringWriter())
        //{
        //    using (XmlTextWriter writer = new XmlTextWriter(sw) { Formatting = Formatting.Indented })
        //    {
        //        xmlser.Serialize(writer, obj);
        //        return sw.ToString();
        //    }
        //}

