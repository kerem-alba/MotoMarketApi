namespace MotoMarketApi.Dtos
{
    public class MotorcycleAdDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public int City { get; set; }
        public int Status { get; set; }
        public int ModelId { get; set; }
        public int CategoryId { get; set; }
    }
}
