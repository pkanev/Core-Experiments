namespace BookStore.Api.Models.Books
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class EditBookRequestModel
    {
        [Required]
        [MinLength(BookTitleMinLength)]
        [MaxLength(BookTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, double.MaxValue)]
        public int Copies { get; set; }

        [Range(0, double.MaxValue)]
        public int? Edition { get; set; }

        [Range(0, double.MaxValue)]
        public int? AgeRestriction { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int AuthorId { get; set; }        
    }
}
