using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Base.Entities
{
    public class Reserve
    {
        public int Id { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public virtual int RoomId { get; set; }
		public virtual int VisitorId { get; set; }
    }
}
