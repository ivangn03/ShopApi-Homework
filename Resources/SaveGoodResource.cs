namespace Shop.Api.Resources
{
    public class SaveGoodResource
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public int CategoryId { get; set; }
    }
}