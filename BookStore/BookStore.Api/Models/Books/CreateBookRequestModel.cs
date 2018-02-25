namespace BookStore.Api.Models.Books
{
    public class CreateBookRequestModel : EditBookRequestModel
    {        
        public string Categories { get; set; }
    }
}
