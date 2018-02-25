namespace BookStore.Api.Controllers
{
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Mvc;
    using Models.Category;
    using Services;
    using System.Threading.Tasks;

    using static WebConstants;
    
    public class CategoriesController : BaseController
    {
        private readonly ICategoryService categories;
        public CategoriesController(ICategoryService categories)
        {
            this.categories = categories;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => this.Ok(await this.categories.All());

        [HttpGet(WithId)]
        public async Task<IActionResult> Get(int id)
            => this.OkOrNotFound(await this.categories.Details(id));

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Post([FromBody] CategoryRequestModel model)
        {
            if (await this.categories.Exists(model.Name)) {
                return this.BadRequest("Category already exists");
            }

            return this.Ok(await this.categories.Create(model.Name));
        }

        [HttpPut(WithId)]
        public async Task<IActionResult> Put(int id, [FromBody] CategoryRequestModel model)
        {
            if (!await this.categories.Exists(id))
            {
                return this.BadRequest("There is no category with such id.");
            }

            var edited = await this.categories.Edit(id, model.Name);

            if(!edited)
            {
                return this.BadRequest("The category could not be edited.");
            }

            return this.Ok(model);
        }

        [HttpDelete(WithId)]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await this.categories.Exists(id))
            {
                return this.NotFound("The book does not exist.");
            }

            return this.Ok(await this.categories.Delete(id));
        }

    }
}
