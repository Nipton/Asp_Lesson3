using Asp_Lesson3.Abstractions;
using Asp_Lesson3.Models.Dto;

namespace Asp_Lesson3.Mutation
{
    public class MutationProduct
    {
        public int Addproduct(ProductModel product, [Service] IUnitOfWork unitOfWork)
        {
            var id = unitOfWork.Products.Create(product);
            return id;
        }
        public int AddGroup(ProductGroupModel groupModel, [Service] IUnitOfWork unitOfWork)
        {
            var id = unitOfWork.Groups.Create(groupModel);
            return id;
        }
    }
}
