using MotoMarketApi.Entities.Enums;
using System.Net.NetworkInformation;
using System.Reflection;

namespace MotoMarketApi.Entities
{
    public class MotorcycleAd : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public int Year { get; set; }
        public int Mileage { get; set; }

        public City City { get; set; }
        public AdStatus Status { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ModelId { get; set; }
        public Model Model { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Photo> Photos { get; set; } = [];
    }
}
