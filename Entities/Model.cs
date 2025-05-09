namespace MotoMarketApi.Entities
{
    public class Model : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int BrandId { get; set; }
        public Brand Brand { get; set; } = new Brand();
        public ICollection<MotorcycleAd> MotorcycleAds { get; set; } = [];

    }
}
