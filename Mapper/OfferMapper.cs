using BlazorApp1.Dto;
using BlazorApp1.Models; // adjust to match your namespace
using MongoDB.Bson;

public static class SubscribePackageMapper
{
    public static SubscribePackageDto ToDto(this SubscribePackageModel model)
    {
        return new SubscribePackageDto
        {
            Id = model.Id.ToString(),
            Type = model.Type,
            Name = model.Name,
            Discount = model.Discount,
            IsSpecial = model.IsSpecial,
            Description = model.Description,
            MaxStudents = model.MaxStudents,
            MaxSubjects = model.MaxSubjects,
            Price = model.Price,
            PricePerHour = model.PricePerHour,
            Currency = model.Currency
        };
    }

    public static SubscribePackageModel ToModel(this SubscribePackageDto dto)
    {
        return new SubscribePackageModel
        {
            Id = string.IsNullOrWhiteSpace(dto.Id) ? ObjectId.GenerateNewId() : ObjectId.Parse(dto.Id),
            Type = dto.Type,
            Name = dto.Name,
            Discount = dto.Discount,
            IsSpecial = dto.IsSpecial,
            Description = dto.Description,
            MaxStudents = dto.MaxStudents,
            MaxSubjects = dto.MaxSubjects,
            Price = dto.Price,
            PricePerHour = dto.PricePerHour,
            Currency = dto.Currency
        };
    }

    public static void UpdateModel(this SubscribePackageModel model, SubscribePackageDto dto)
    {
        model.Type = dto.Type;
        model.Name = dto.Name;
        model.Discount = dto.Discount;
        model.IsSpecial = dto.IsSpecial;
        model.Description = dto.Description;
        model.MaxStudents = dto.MaxStudents;
        model.MaxSubjects = dto.MaxSubjects;
        model.Price = dto.Price;
        model.PricePerHour = dto.PricePerHour;
        model.Currency = dto.Currency;
    }
}
