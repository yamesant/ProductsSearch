using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductsSearch.Core;

public sealed class Product
{
    [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
    public string ObjectId { get; set; }

    public int Id { get; set; }
    public string Sku { get; set; }

    public string Name { get; set; }
    [BsonRepresentation(BsonType.Double)]
    public decimal Price { get; set; }
    public Attribute Attribute { get; set; }
}
public sealed class Attribute
{
    public Fantastic Fantastic { get; set; }
    public Rating Rating { get; set; }
}
public sealed class Fantastic
{
    public bool Value { get; set; }
    public int Type { get; set; }
    public string Name { get; set; }
}
public sealed class Rating
{
    [BsonRepresentation(BsonType.Double)]
    public decimal Value { get; set; }

    public string Type { get; set; }
    public string Name { get; set; }

}