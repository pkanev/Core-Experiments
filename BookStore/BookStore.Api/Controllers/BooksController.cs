namespace BookStore.Api.Controllers
{    
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Mvc;
    using Models.Books;
    using Services;
    using System.Threading.Tasks;

    using static WebConstants;

    public class BooksController : BaseController
    {
        private readonly IBookService books;
        private readonly IAuthorService authors;

        public BooksController(IBookService books, IAuthorService authors)
        {
            this.books = books;
            this.authors = authors;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string search = "")
            => this.Ok(await this.books.All(search));

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Post([FromBody] CreateBookRequestModel model)
        {
            var authorExists = await this.authors.Exists(model.AuthorId);
            if(!authorExists)
            {
                return this.BadRequest("Author does not exist.");
            }

            var id = await this.books.Create(
                model.Title, 
                model.Description, 
                model.Price, 
                model.Copies, 
                model.Edition, 
                model.AgeRestriction, 
                model.ReleaseDate, 
                model.AuthorId, 
                model.Categories);

            return this.Ok(id);
        }

        [HttpPut(WithId)]
        [ValidateModelState]
        public async Task<IActionResult> Put(int id, [FromBody] EditBookRequestModel model)
        {
            var bookExists = await this.books.Exists(id);
            if (!bookExists)
            {
                return this.NotFound("The book does not exist.");
            }

            var authorExists = await this.authors.Exists(model.AuthorId);
            if (!authorExists)
            {
                return this.BadRequest("Author does not exist.");
            }
            
            var edited = await this.books.Edit(
                id,
                model.Title,
                model.Description,
                model.Price,
                model.Copies,
                model.Edition,
                model.AgeRestriction,
                model.ReleaseDate,
                model.AuthorId);

            if(!edited)
            {
                return this.BadRequest("The book could not be edited.");
            }

            return this.Ok(model);
        }

        [HttpGet(WithId)]
        public async Task<IActionResult> Get(int id)
            => this.OkOrNotFound(await this.books.Details(id));

        [HttpDelete(WithId)]
        public async Task<IActionResult> Delete(int id)
        {
            var bookExists = await this.books.Exists(id);
            if (!bookExists)
            {
                return this.NotFound("The book does not exist.");
            }

            return this.Ok(await this.books.Delete(id));
        }
    }
}
