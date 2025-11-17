using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace CRUDMongo.Models
{
    public class Authors
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Country { get; private set; }

        public Authors(string name, string country)
        {
            Name = name;
            Country = country;
        }

        public override string? ToString()
        {
            return $"ID do Autor: {Id}\n"+
                $"Nome: {Name}\n" +
                $"País: {Country}";
        }
    }
}
