namespace BookStore.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using BookStore.Data.Models;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models.Author;
    using Models.Book;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AuthorService : IAuthorService
    {
        private readonly BookStoreDbContext db;

        public AuthorService(BookStoreDbContext db)
        {
            this.db = db;
        }

        public async Task<int> Create(string firstName, string lastName)
        {
            var author = new Author
            {
                FirstName = firstName,
                LastName = lastName
            };

            await this.db.Authors.AddAsync(author);
            await this.db.SaveChangesAsync();

            return author.Id;
        }

        public async Task<AuthorDetailsServiceModel> Details(int id)
            => await this.db
                .Authors
                .Where(a => a.Id == id)
                .ProjectTo<AuthorDetailsServiceModel>()
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<BooksWithCategoriesServiceModel>> Books(int authorid)
            => await this.db
                .Books
                .Where(b => b.AuthorId == authorid)
                .ProjectTo<BooksWithCategoriesServiceModel>()
                .ToListAsync();

        public async Task<bool> Exists(int id)
            => await this.db.Authors.AnyAsync(a => a.Id == id);
    }
}
