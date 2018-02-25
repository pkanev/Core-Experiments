using BookStore.Services.Models.Category;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public interface ICategoryService
    {
        Task<CategoryDetailsserviceModel> Details(int id);

        Task<IEnumerable<CategoryDetailsserviceModel>> All();

        Task<int> Create(string name);

        Task<bool> Edit(int id, string name);

        Task<bool> Delete(int id);

        Task<bool> Exists(string name);

        Task<bool> Exists(int id);
    }
}
