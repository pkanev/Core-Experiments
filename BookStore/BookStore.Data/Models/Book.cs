namespace BookStore.Data.Models
{
    using static DataConstants;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        public int Id { get; set; }

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

        public Author Author { get; set; }

        public ICollection<BookCategory> Categories { get; set; } = new HashSet<BookCategory>();
    }
}
