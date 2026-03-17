using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;
using POS.Infrastructure.Commons.Bases.Request;
using POS.Infrastructure.Commons.Bases.Response;
using POS.Infrastructure.Persistences.Contexts;
using POS.Infrastructure.Persistences.Interfaces;
using POS.Utilities.Static;
using System.Linq.Dynamic.Core;

namespace POS.Infrastructure.Persistences.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRespository
    {
        public CategoryRepository(POSContext context) : base(context) { }

        public async Task<BaseEntityResponse<Category>> ListCategories(BaseFilterRequest filters)
        {
            var response = new BaseEntityResponse<Category>();

            var categories = GetEntityQuery(x => x.AuditDeleteUser == null && x.AuditDeleteDate == null);

            if (filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
            {
                switch (filters.NumFilter)
                {
                    case 1:
                        categories = categories.Where(x => x.Name!.Contains(filters.TextFilter));
                        break;
                    case 2:
                        categories = categories.Where(x => x.Description!.Contains(filters.TextFilter));
                        break;
                }
            }
            if (filters.StateFilter is not null)
            {
                categories = categories.Where(x => x.State.Equals(filters.StateFilter));
            }

            if (!string.IsNullOrEmpty(filters.StartDate) && !string.IsNullOrEmpty(filters.EndDate))
            {
                categories = categories.Where(x => x.AuditCreateDate >= Convert.ToDateTime(filters.StartDate) && x.AuditCreateDate <= Convert.ToDateTime(filters.EndDate).AddDays(1));
            }

            if (filters.Sort is null) filters.Sort = "CategoryId";

            response.TotalRecords = await categories.CountAsync();
            response.Items = await Ordering(filters, categories, !(bool)filters.Download!).ToListAsync();
            return response;
        }

        // Si necesitas estos métodos adicionales, puedes delegarlos al GenericRepository:
        public async Task<IEnumerable<Category>> ListSelectCategories()
        {
            return await GetAllAsync();
        }

        public async Task<Category> CategoryById(int categoryid)
        {
            return await GetByIdAsync(categoryid);
        }

        public async Task<bool> RegisterCategory(Category category)
        {
            return await RegisterAsync(category);
        }

        public async Task<bool> EditCategory(Category category)
        {
            return await EditAsync(category);
        }

        public async Task<bool> RemoveCategory(int categoryid)
        {
            return await RemoveAsync(categoryid);
        }
    }
}