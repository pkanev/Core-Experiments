namespace BookStore.Api.Controllers
{
    using Infrastructure.Extensions;
    using Models.Authors;
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using System.Threading.Tasks;

    using static WebConstants;
    using BookStore.Api.Infrastructure.Filters;

    public class AuthorsController : BaseController
    {
        private readonly IAuthorService authors;

        public AuthorsController(IAuthorService authors)
        {
            this.authors = authors;
        }

        [HttpGet(WithId)]
        public async Task<IActionResult> Get(int id) 
            => this.OkOrNotFound(await this.authors.Details(id));

        [HttpGet(WithId + "\books")]
        public async Task<IActionResult> GetBooks(int id)
            => this.Ok(await this.authors.Books(id));

        [HttpPost]
        [ValidateModelState] 
        public async Task<IActionResult> Post([FromBody] AuthorRequestModel model)
            => Ok(await this.authors.Create(
                model.FirstName, 
                model.LastName));
    }
}
