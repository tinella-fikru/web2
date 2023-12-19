using Microsoft.EntityFrameworkCore;

namespace _1.Models
{
    public class ProductRepository
    {
        private readonly EcomContext ecomContext;
        public ProductRepository(EcomContext ecomContext)
        {
            this.ecomContext = ecomContext;
        }
        public Product Add(Product product)
        {
            ecomContext.products.Add(product);
            ecomContext.SaveChanges();
            return product;
        }

        public List<Product> GetAllProducts() 
        {
            return this.ecomContext.products.ToList();
        }
        public Product GetProductById(int id)
        {
            Product? product = this.ecomContext.products.Include(x=>x.imageGallary).FirstOrDefault(p=>p.productId == id);
            return product;
        }
    }
}
