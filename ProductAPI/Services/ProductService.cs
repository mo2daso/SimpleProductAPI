using ProductAPI.Models;

namespace ProductAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new();
        private int _nextId = 1;

        public List<Product> GetAllProducts() => _products;

        public Product? GetProductById(int id) =>
            _products.FirstOrDefault(p => p.Id == id);

        public void AddProduct(Product product)
        {
            product.Id = _nextId++;
            _products.Add(product);
        }

        public bool UpdateProduct(int id, Product updatedProduct)
        {
            var product = GetProductById(id);
            if (product == null) return false;

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            return true;
        }

        public bool DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product == null) return false;

            _products.Remove(product);
            return true;
        }

        public decimal GetTotalPrice()
        {
            return _products.Sum(p => p.Price);
        }

    }
}

