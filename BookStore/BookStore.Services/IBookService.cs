namespace BookStore.Services
{
    using Models.Book;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBookService
    {
        Task<IEnumerable<BookListingServiceModel>> All(string searchTerm);
        Task<BookDetailsServiceModel> Details(int id);
        Task<int> Create(
            string title, 
            string description, 
            decimal price, 
            int copies, 
            int? edition, 
            int? ageRestriction, 
            DateTime releaseDate, 
            int authorId, 
            string categories);

        Task<bool> Edit(
            int id,
            string title,
            string description,
            decimal price,
            int copies,
            int? edition,
            int? ageRestriction,
            DateTime releaseDate,
            int authorId);

        Task<bool> Exists(int id);

        Task<bool> Delete(int id);        
    }
}
