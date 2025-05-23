using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorApp1.Models
{
    public class SubscribePackageModel
    {

        [BsonId]
        public ObjectId Id { get; set; }

        public string Type { get; set; } // حضوري - اونلاين
        public string Name { get; set; }
        public decimal Discount { get; set; }
        public bool IsSpecial { get; set; }
        public string Description { get; set; }
        public int MaxStudents { get; set; }
        public int MaxSubjects { get; set; }
        public decimal Price { get; set; }
        public decimal PricePerHour { get; set; }
        public string Currency { get; set; }
    }

}
