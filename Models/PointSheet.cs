using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace myTestAngular.Models {
    public class PointSheet {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public string StartDate { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;        
        [BsonDateTimeOptions]
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        public int UserId { get; set; } = 0;
    }
}