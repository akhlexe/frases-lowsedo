namespace Frases_Lowsedo.DTOs
{
    public class QuoteDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string AuthorName { get; set; }
        public int AuthorId { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
