using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args) {
            var ajustes = new List<Ajuste>();
            var ajuste1 = new Ajuste();
            ajuste1.Name = "Corriente";
            ajuste1.Value = 12;
            ajustes.Add(ajuste1);
                var rnd=new Random();
            for (int i = 0; i < 10; i++) {
                var ajuste2 = new Ajuste();
                ajuste2.Name = "Corriente";
                ajuste2.Value = rnd.Next(20,50);
                ajustes.Add(ajuste2);

            }
            SerializeXML("ajustes.xml",ajustes);

        }

        static void SerializeXML(string fileName, object myObject) {
            XmlSerializer xsSubmit = new XmlSerializer(myObject.GetType());
            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlTextWriter writer = new XmlTextWriter(sww) { Formatting = Formatting.Indented })
                {
                    xsSubmit.Serialize(writer, myObject);
                    xml = sww.ToString(); // Your XML
                }
            }
            System.IO.File.WriteAllText(fileName,xml);

        }
    }

    public class Ajuste
    {
        public string Name;
        public int Value;
    }


}
