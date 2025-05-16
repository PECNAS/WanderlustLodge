namespace WebApplication1.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int VisitorId { get; set; }
        public string ReviewText { get; set; }
        public float Rating { get; set; }
    }
}
