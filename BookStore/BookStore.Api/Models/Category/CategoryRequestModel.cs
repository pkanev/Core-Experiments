namespace BookStore.Api.Models.Category
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class CategoryRequestModel
    {
        [Required]
        [MinLength(CategoryNameMinLength)]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; }
    }
}
