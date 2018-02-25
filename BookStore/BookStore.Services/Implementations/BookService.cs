namespace BookStore.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Common.Extensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.Book;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BookService : IBookService
    {
        private readonly BookStoreDbContext db;

        public BookService(BookStoreDbContext db)
        {
            this.db = db;
        }

        public async Task<BookDetailsServiceModel> Details(int id)
            => await this.db
                .Books
                .Where(b => b.Id == id)
                .ProjectTo<BookDetailsServiceModel>()
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<BookListingServiceModel>> All(string searchTerm)
            => await this.db
                .Books
                .Where(b => b.Title.ToLower().Contains(searchTerm.ToLower()))
                .OrderBy(b => b.Title)
                .Take(10)
                .ProjectTo<BookListingServiceModel>()
                .ToListAsync();

        public async Task<int> Create(
            string title, 
            string description, 
            decimal price, 
            int copies, 
            int? edition, 
            int? ageRestriction, 
            DateTime releaseDate, 
            int authorId, 
            string categories)
        {
            var book = new Book
            {
                Title = title,
                Description = description,
                Price = price,
                Copies = copies,
                Edition = edition,
                AgeRestriction = ageRestriction,
                ReleaseDate = releaseDate,
                AuthorId = authorId
            };

            var categoryCollection = categories
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToHashSet();

            var exisitngCategories = await this.db
                .Categories
                .Where(c => categoryCollection.Contains(c.Name.ToLower()))
                .ToListAsync();

            var allCategories = new List<Category>(exisitngCategories);
            foreach (var categoryName in categoryCollection)
            {
                if(exisitngCategories.All(c => c.Name != categoryName))
                {
                    var category = new Category { Name = categoryName };
                    allCategories.Add(category);
                    this.db.Categories.Add(category);
                }
            }

            await this.db.SaveChangesAsync();

            foreach (var category in allCategories)
            {
                book.Categories.Add(new BookCategory { CategoryId = category.Id });
            }

            await this.db.Books.AddAsync(book);
            await this.db.SaveChangesAsync();

            return book.Id;
        }

        public async Task<bool> Exists(int id)
            => await this.db.Books.AnyAsync(b => b.Id == id);

        public async Task<bool> Edit(
            int id, 
            string title, 
            string description, 
            decimal price, 
            int copies, 
            int? edition, 
            int? ageRestriction, 
            DateTime releaseDate, 
            int authorId)
        {
            var book = await this.db.Books.FindAsync(id);
            if (book == null)
            {
                //throw new NullReferenceException("No such book in the database.");
                return false;
            }

            book.Title = title;
            book.Description = description;
            book.Price = price;
            book.Copies = copies;
            book.Edition = edition;
            book.AgeRestriction = ageRestriction;
            book.ReleaseDate = releaseDate;
            book.AuthorId = authorId;

            db.SaveChanges();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var book = await this.db.Books.FindAsync(id);
            if (book == null)
            {
                //throw new NullReferenceException("No such book in the database.");
                return false;
            }

            this.db.Books.Remove(book);
            this.db.SaveChanges();
            return true;
        }
    }
}
