using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductInfo.Models
{
    public class Products
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string iid { get; set; }

        public int id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }
    }
}
