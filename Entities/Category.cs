namespace MotoMarketApi.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<MotorcycleAd> MotorcycleAds { get; set; } = [];
    }
}
