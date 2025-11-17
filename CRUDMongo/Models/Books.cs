using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CRUDMongo.Models
{
    public class Books
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
        public string Title { get; private set; }
        public string AuthorId { get; private set; }
        public int Year { get; private set; }

        public Books(string title, string authorId, int year)
        {
            Title = title;
            AuthorId = authorId;
            Year = year;
        }

        public override string? ToString()
        {
            return $"Book Id={Id}\n" +
                $"Title={Title}\n" +
                $"AuthorId={AuthorId}\n" +
                $"Year={Year}";
        }
    }
}
