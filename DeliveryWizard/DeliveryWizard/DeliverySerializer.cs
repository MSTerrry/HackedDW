using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace DeliveryWizard
{
    public class DeliverySerializer
    {
        private static readonly XmlSerializer Xs = new XmlSerializer(typeof(DeliveryRquestDto));
        public static void WriteToFile(string fileName, DeliveryRquestDto data)
        {
            using (var fileStream = File.Create(fileName))
            {
                Xs.Serialize(fileStream, data);
            }
        }

        public static DeliveryRquestDto LoadFromFile(string fileName)
        {
            using (var fileStream = File.OpenRead(fileName))
            {
                return (DeliveryRquestDto)Xs.Deserialize(fileStream);
            }
        }

        public static DeliveryRquestDto LoadFromStream(Stream file)
        {
            return (DeliveryRquestDto)Xs.Deserialize(file);
        }
    }
}
