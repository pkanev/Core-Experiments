namespace BookStore.Services.Models.Category
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;

    public class CategoryDetailsserviceModel : IMapFrom<Book>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper.CreateMap<Category, CategoryDetailsserviceModel>();
    }
}
