namespace MotoMarketApi.Entities
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Model> Models { get; set; } = [];
    }
}
