using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delivery_order_services.Domain.Entities
{
    public class OrderEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("NameProduct")]
        public string NameProduct{ get; set; } = string.Empty;

        [BsonElement("User")]
        public UserEntity User { get; set; } = new UserEntity();
    }
}
