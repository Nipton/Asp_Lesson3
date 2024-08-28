using Asp_Lesson3.Abstractions;
using Asp_Lesson3.Models;
using Asp_Lesson3.Models.Dto;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;

namespace Asp_Lesson3.Services
{
    public class ProductRepository : IRepository<ProductModel>
    {
        ProductsDbContext db;
        IMapper mapper;
        IMemoryCache cache;
        public ProductRepository(ProductsDbContext db, IMapper mapper, IMemoryCache cache)
        {
            this.db = db;
            this.mapper = mapper;
            this.cache = cache;
        }

        public int Create(ProductModel productModel)
        {
            Product product = mapper.Map<Product>(productModel);
            db.Products.Add(product);
            db.SaveChanges();
            cache.Remove("products");
            return product.Id;
        }

        public IEnumerable<ProductModel> GetAll()
        {
            if(cache.TryGetValue("products", out IEnumerable<ProductModel>? productList))
                return productList!;
            productList = db.Products.Select(x => mapper.Map<ProductModel>(x)).ToList();
            cache.Set("products", productList, TimeSpan.FromMinutes(30));
            return productList;
        }

        public ProductModel? GetById(int id)
        {
            var warehouseEntity = db.Products.Find(id);
            if (warehouseEntity == null)
            {
                return null;
            }
            else
            {
                return mapper.Map<ProductModel>(warehouseEntity);
            }
        }
    }
}
