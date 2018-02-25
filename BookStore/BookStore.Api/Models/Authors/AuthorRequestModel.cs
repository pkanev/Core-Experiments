namespace BookStore.Api.Models.Authors
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class AuthorRequestModel
    {
        [Required]
        [MinLength(AuthorNameMinLength)]
        [MaxLength(AuthorNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(AuthorNameMinLength)]
        [MaxLength(AuthorNameMaxLength)]
        public string LastName { get; set; }
    }
}
