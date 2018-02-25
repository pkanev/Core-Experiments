namespace BookStore.Services.Models.Book
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class BookDetailsServiceModel : BookBase, IMapFrom<Book>, IHaveCustomMapping
    {
        public int AuthorId { get; set; }

        public string Author { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper.CreateMap<Book, BookDetailsServiceModel>()
            .ForMember(b => b.Categories, cfg => cfg
                .MapFrom(b => b.Categories.Select(c => c.Category.Name)))
            .ForMember(b => b.Author, cfg => cfg
                .MapFrom(b => $"{b.Author.LastName}, {b.Author.FirstName}"));
    }
}
