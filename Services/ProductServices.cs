using DynamicGridDemo.Data;
using DynamicGridDemo.Model;
using Microsoft.EntityFrameworkCore;

namespace DynamicGridDemo.Services
{
    public class ProductServices
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductServices(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetProducts()
        {
            
            return await _dbContext.Products.Include(p => p.Attributes).ToListAsync();
        }

        public async Task<List<ProductAttribute>> GetProductAttributeAsync()
        {
            return await _dbContext.ProductAttributes.ToListAsync();
        }

        public async Task AddDynamicField(int productId, string fieldName, string fieldValue)
        {
           
            var existingAttribute = await _dbContext.ProductAttributes
                .FirstOrDefaultAsync(a => a.ProductId == productId && a.Key == fieldName);

            if (existingAttribute != null)
            {
                
                existingAttribute.Value = fieldValue;
            }
            else
            {
                
                var attribute = new ProductAttribute
                {
                    ProductId = productId,
                    Key = fieldName,
                    Value = fieldValue
                };

                _dbContext.ProductAttributes.Add(attribute);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateProductAttribute(ProductAttribute attribute)
        {
            
            var existingAttribute = await _dbContext.ProductAttributes.FindAsync(attribute.Id);
            if (existingAttribute != null)
            {
                existingAttribute.Value = attribute.Value;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
