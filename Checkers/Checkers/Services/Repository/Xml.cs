using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Checkers.Models;

namespace Checkers.Services.Repository
{
    public sealed class Xml : DBRepository
    {
        public Xml() : base()
        {
            
        }

        public Xml(string filePath) : base(filePath)
        {

        }

        protected override string SerializeUsers(List<User> users)
        {
            var serializer = new XmlSerializer(typeof(List<User>));
            using (var writer = XmlWriter.Create("../temp.json", new XmlWriterSettings(){Indent = true, IndentChars = "\t"}))
            {
                serializer.Serialize(writer, users);
            }

            return File.ReadAllText("../temp.json");
        }

        protected override List<User> DeserializeUsers(string serializedUsers)
        {
            var serializer = new XmlSerializer(typeof(List<User>));
            using (var reader = XmlReader.Create(ImportFilePath))
            {
                return (List<User>)serializer.Deserialize(reader);
            }
        }
    }
}