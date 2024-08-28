using Asp_Lesson3.Abstractions;
using Asp_Lesson3.Models;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;

namespace Asp_Lesson3.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProductsDbContext db;
        private IMapper mapper;
        private IMemoryCache cache;
        private ProductRepository productRepository;
        private ProductGroupRepository productGroupRepository;
        private StoreRepository storeRepository;
        private bool disposedValue;

        public ProductRepository Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(db, mapper, cache);
                return productRepository;
            }
        }
        public ProductGroupRepository Groups
        {
            get
            {
                if (productGroupRepository == null)
                    productGroupRepository = new ProductGroupRepository(db, mapper, cache);
                return productGroupRepository;
            }
        }
        public StoreRepository Stores
        {
            get
            {
                if (storeRepository == null)
                    storeRepository = new StoreRepository(db, mapper, cache);
                return storeRepository;
            }
        }
        public UnitOfWork(IMapper mapper, ProductsDbContext db, IMemoryCache cache)
        {
            this.mapper = mapper;
            this.db = db;
            this.cache = cache;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (db != null)
                    {
                        db.Dispose();
                        db = null;
                    }
                }
                productRepository = null;
                productGroupRepository = null;
                storeRepository = null;
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
