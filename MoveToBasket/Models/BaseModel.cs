using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoveToBasket.Entities
{
    public class BaseModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}
