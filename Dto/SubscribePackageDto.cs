namespace BlazorApp1.Dto
{
    public class SubscribePackageDto
    {
        public string Id { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Discount { get; set; } = 0m;
        public bool IsSpecial { get; set; } = false;
        public string Description { get; set; } = string.Empty;
        public int MaxStudents { get; set; } = 0;
        public int MaxSubjects { get; set; } = 0;
        public decimal Price { get; set; } = 0m;
        public decimal PricePerHour { get; set; } = 0m;
        public string Currency { get; set; } = string.Empty;
    }

}
