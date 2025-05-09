namespace MotoMarketApi.Entities
{
    public class Photo : BaseEntity
    {
        public string Url { get; set; } = string.Empty;
        public int MotorcycleAdId { get; set; }
        public MotorcycleAd MotorcycleAd { get; set; } = new MotorcycleAd();

    }
}
