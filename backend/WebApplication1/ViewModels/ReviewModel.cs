using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class ReviewModel
    {
        [Required]
        public int VisitorId { get; set; }
        [Required]
        public string ReviewText { get; set; }
        [Required]
        public int Rating { get; set; }
    }
}
