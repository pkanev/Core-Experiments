namespace BookStore.Data.Models
{
    using static DataConstants;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MinLength(CategoryNameMinLength)]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; }

        public ICollection<BookCategory> Books { get; set; } = new HashSet<BookCategory>();
    }
}
