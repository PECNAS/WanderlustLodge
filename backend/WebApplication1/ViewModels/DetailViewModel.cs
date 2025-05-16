using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class DetailViewModel
    {
        [Required]
        public int RoomId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public DateOnly InDate { get; set; }
        [Required]
        public DateOnly OutDate { get; set; }
    }
}
