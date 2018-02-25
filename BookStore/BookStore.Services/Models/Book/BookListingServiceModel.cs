namespace BookStore.Services.Models.Book
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;

    public class BookListingServiceModel : IMapFrom<Book>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper.CreateMap<Book, BookListingServiceModel>();
    }
}
