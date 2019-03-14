using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace image.upload
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("Id")]
        public string Id { get; set; }

        [BsonElement("Image")]
        public byte[] Image{get;set;}
    }
}
