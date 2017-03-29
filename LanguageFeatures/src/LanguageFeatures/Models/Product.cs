namespace LanguageFeatures.Models
{
    public class Product
    {
        public Product(bool stock = true)
        {
            this.InStock = stock;
        }
        public string Name { get; set; }
        public string Category { get; set; } = "Watersports";
        public decimal? Price { get; set; }
        public Product Related { get; set; }
        public bool InStock { get; }

        public static Product[] GetProducts()
        {
            Product kayak = new Product { Name = "Kayak", Price = 275M, Category = "Water Craft" };
            Product lifeJacket = new Product (false) { Name = "Life jacket", Price = 48.95M };
            kayak.Related = lifeJacket;

            //Product test = new Product { Name = "test"};
            //Product test2 = new Product { Price = 5000M };
            return new Product[] { kayak, lifeJacket, null };
        }
    }
}
