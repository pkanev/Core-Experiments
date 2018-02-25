namespace BookStore.Services.Models.Book
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class BooksWithCategoriesServiceModel : BookBase, IMapFrom<Book>, IHaveCustomMapping
    {        
        public IEnumerable<string> Categories { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<Book, BooksWithCategoriesServiceModel>()
                .ForMember(b => b.Categories, cfg => cfg
                    .MapFrom(b => b.Categories.Select(c => c.Category.Name)));
    }
}
