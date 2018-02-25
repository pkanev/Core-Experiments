namespace BookStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class BookCategory
    {
        public int BookId { get; set; }

        [Required]
        public Book Book { get; set; }

        public int CategoryId { get; set; }

        [Required]
        public Category Category { get; set; }
    }
}
