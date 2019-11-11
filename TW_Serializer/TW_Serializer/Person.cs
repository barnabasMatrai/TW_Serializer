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
    class Person
    {
        private string name;
        private string address;
        private string phoneNumber;
        private DateTime dataRecordingDate;
        [NonSerialized]
        private static int serialNumber = 0;

        public Person(string name, string address, string phoneNumber)
        {
            this.name = name;
            this.address = address;
            this.phoneNumber = phoneNumber;
            dataRecordingDate = DateTime.Now;
            serialNumber++;
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

        public static int SerialNumber
        {
            get { return serialNumber; }
        }
    }
}
