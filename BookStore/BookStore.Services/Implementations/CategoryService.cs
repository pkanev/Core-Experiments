namespace BookStore.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.Category;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    
    public class CategoryService : ICategoryService
    {
        private readonly BookStoreDbContext db;

        public CategoryService(BookStoreDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CategoryDetailsserviceModel>> All()
            => await this.db
                .Categories
                .ProjectTo<CategoryDetailsserviceModel>()
                .ToListAsync();

        public async Task<int> Create(string name)
        {
            var category = new Category { Name = name };
            await this.db.Categories.AddAsync(category);
            await this.db.SaveChangesAsync();
            return category.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var category = await this.db.Categories.FindAsync(id);
            if (category == null)
            {
                return false;
            }

            this.db.Categories.Remove(category);
            this.db.SaveChanges();
            return true;
        }

        public async Task<CategoryDetailsserviceModel> Details(int id)
            => await this.db
                .Categories
                .Where(c => c.Id == id)
                .ProjectTo<CategoryDetailsserviceModel>()
                .FirstOrDefaultAsync();

        public async Task<bool> Edit(int id, string name)
        {
            var category = await this.db.Categories.FindAsync(id);
            if(category == null)
            {
                return false;
            }

            category.Name = name;
            await this.db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Exists(string name)
            => await this.db
                .Categories
                .AnyAsync(c => c.Name == name);

        public async Task<bool> Exists(int id)
            => await this.db
                .Categories
                .AnyAsync(c => c.Id == id);
    }
}
