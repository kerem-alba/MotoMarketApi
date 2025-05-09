namespace MotoMarketApi.Entities
{
    public class FavoriteAd : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int MotorcycleAdId { get; set; }
        public MotorcycleAd MotorcycleAd { get; set; }
    }
}
