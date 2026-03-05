using POS.Domain.Entities;
using POS.Infrastructure.Commons.Bases.Request;
using POS.Infrastructure.Commons.Bases.Response;

namespace POS.Infrastructure.Persistences.Interfaces
{
<<<<<<< HEAD
    public interface ICategoryRespository : IGenericRepository<Category>
    {
        Task<BaseEntityResponse<Category>> ListCategories(BaseFilterRequest filters);
=======
    public interface ICategoryRespository
    {
        Task<BaseEntityResponse<Category>> ListCategories(BaseFilterRequest filters);
        Task<IEnumerable<Category>> ListSelectCategories();
        Task<Category> CategoryById(int categoryid);
        Task<bool> RegisterCategory(Category category);
        Task<bool> EditCategory(Category category);
        Task<bool> RemoveCategory(int categoryid);
>>>>>>> 6d20b31533ce8f586b93660028abbb8bd68570ec
    }
}
