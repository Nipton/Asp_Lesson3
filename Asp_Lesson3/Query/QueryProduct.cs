using Asp_Lesson3.Abstractions;
using Asp_Lesson3.Models;
using Asp_Lesson3.Models.Dto;
namespace Asp_Lesson3.Query
{
    public class QueryProduct
    {
        public IEnumerable<ProductModel> GetAllProducts([Service] IUnitOfWork unitOfWork)
        {
            var result = unitOfWork.Products.GetAll();
            unitOfWork.Dispose();
            return result;
        }
        public IEnumerable<ProductGroupModel> GetAllGroups([Service] IUnitOfWork unitOfWork)
        {
            var result = unitOfWork.Groups.GetAll();
            unitOfWork.Dispose();
            return result;
        }
        public IEnumerable<StoreModel> GetAllStores([Service] IUnitOfWork unitOfWork)
        {
            var result = unitOfWork.Stores.GetAll();
            unitOfWork.Dispose();
            return result;
        }
        public bool GetProduct(int id, [Service] IUnitOfWork unitOfWork)
        {
            var result = unitOfWork.Products.GetById(id);
            unitOfWork.Dispose();
            if (result != null)
                return true;
            return false;
            
        }
    }
}
