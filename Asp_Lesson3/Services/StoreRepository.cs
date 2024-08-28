using Asp_Lesson3.Abstractions;
using Asp_Lesson3.Models;
using Asp_Lesson3.Models.Dto;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;

namespace Asp_Lesson3.Services
{
    public class StoreRepository : IRepository<StoreModel>
    {
        ProductsDbContext db;
        IMapper mapper;
        IMemoryCache cache;
        public StoreRepository(ProductsDbContext db, IMapper mapper, IMemoryCache cache)
        {
            this.db = db;
            this.mapper = mapper;
            this.cache = cache;
        }

        public int Create(StoreModel storeModel)
        {
            Store store = mapper.Map<Store>(storeModel);
            db.Stores.Add(store);
            db.SaveChanges();
            cache.Remove("stores");
            return store.Id;
        }

        public IEnumerable<StoreModel> GetAll()
        {
            if (cache.TryGetValue("stores", out IEnumerable<StoreModel>? storesList))
                return storesList!;
            storesList = db.Stores.Select(x => mapper.Map<StoreModel>(x)).ToList();
            cache.Set("stores", storesList, TimeSpan.FromMinutes(30));
            return storesList;
        }

        public StoreModel GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
