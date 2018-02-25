namespace BookStore.Data.Models
{
    using static DataConstants;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class Author
    {
        public int Id { get; set; }

        [Required]
        [MinLength(AuthorNameMinLength)]
        [MaxLength(AuthorNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(AuthorNameMinLength)]
        [MaxLength(AuthorNameMaxLength)]
        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
