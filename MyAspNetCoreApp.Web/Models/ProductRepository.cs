namespace MyAspNetCoreApp.Web.Models
{
    public class ProductRepository
    {
        private static List<Product> _products = new List<Product>()
        {
            new() { Id = 1, Name = "Kalem 1", Price = 100, Stock = 200 },
            new () { Id = 2, Name = "Kalem 2", Price = 200, Stock = 300 },
            new () { Id = 3, Name = "Kalem 3", Price = 300, Stock = 400 }
        };

        public List<Product> GetAll() => _products;

        public void AddProduct(Product newProduct) => _products.Add(newProduct);

        public void RemoveProduct(int productId)
        {
            var hasProduct = _products.FirstOrDefault(x => x.Id == productId);

            if (hasProduct == null)
            {
                throw new Exception($"Bu Id({productId}) ye ait ürün bulunmamaktadır");
            }

            _products.Remove(hasProduct);
        }
        public void UpdateProduct(Product updateProduct)
        {
            var hasProduct = _products.FirstOrDefault(x => x.Id == updateProduct.Id);

            if (hasProduct == null)
            {
                throw new Exception($"Bu Id({updateProduct.Id}) ye ait ürün bulunmamaktadır");
            }

            hasProduct.Name = updateProduct.Name;
            hasProduct.Stock = updateProduct.Stock;
            hasProduct.Price = updateProduct.Price;

            var index = _products.FindIndex(x => x.Id == updateProduct.Id);

            _products[index] = hasProduct;
        }
    }
}
