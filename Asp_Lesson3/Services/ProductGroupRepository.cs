using Asp_Lesson3.Abstractions;
using Asp_Lesson3.Models;
using Asp_Lesson3.Models.Dto;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;

namespace Asp_Lesson3.Services
{
    public class ProductGroupRepository : IRepository<ProductGroupModel>
    {
        ProductsDbContext db;
        IMapper mapper;
        IMemoryCache cache;
        public ProductGroupRepository(ProductsDbContext db, IMapper mapper, IMemoryCache cache)
        {
            this.db = db;
            this.mapper = mapper;
            this.cache = cache;
        }

        public int Create(ProductGroupModel productGroup)
        {
            ProductGroup productGroupModel = mapper.Map<ProductGroup>(productGroup);
            db.ProductGroups.Add(productGroupModel);
            db.SaveChanges();
            cache.Remove("productGroup");
            return productGroupModel.Id;
        }

        public IEnumerable<ProductGroupModel> GetAll()
        {
            if (cache.TryGetValue("productGroup", out IEnumerable<ProductGroupModel>? productGroupList))
                return productGroupList!;
            productGroupList = db.ProductGroups.Select(x => mapper.Map<ProductGroupModel>(x)).ToList();
            cache.Set("productGroup", productGroupList, TimeSpan.FromMinutes(30));
            return productGroupList;
        }

        public ProductGroupModel GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
