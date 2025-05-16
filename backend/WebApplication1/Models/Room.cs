using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Base.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public bool IsFree { get; set; } = true;
        public string Image { get; set; }
    }
}
