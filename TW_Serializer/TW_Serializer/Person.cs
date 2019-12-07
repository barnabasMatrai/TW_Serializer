using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TW_Serializer
{
    [Serializable]
    class Person : IDeserializationCallback
    {
        private string name;
        private string address;
        private string phoneNumber;
        private DateTime dataRecordingDate;
        [NonSerialized]
        private static int serialNumberCounter = Directory.GetFiles(@"C:\Users\matra\OneDrive\Asztali gép\codecool\TW_assignments\3rd_week\TW_Serializer", "*.dat").Length;
        [NonSerialized]
        private int serialNumber;

        public Person(string name, string address, string phoneNumber)
        {
            this.name = name;
            this.address = address;
            this.phoneNumber = phoneNumber;
            dataRecordingDate = DateTime.Now;
            serialNumberCounter++;
            serialNumber = serialNumberCounter;
        }

        public void Serialize(string filePath)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, this);
            stream.Close();
        }

        public static Person Deserialize(string filePath)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            Person person = (Person)formatter.Deserialize(stream);
            stream.Close();

            return person;
        }

        public void OnDeserialization(object sender)
        {
        }

        public string Name
        {
            get { return name; }
        }

        public string Address
        {
            get { return address; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
        }

        public int SerialNumber
        {
            get { return serialNumber; }
            set { serialNumber = value; }
        }
    }
}
