using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Base.Entities
{
    public class Visitor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        /*public virtual ICollection<Reserve> Reserves { get; set; }

        public Visitor()
        {
            this.Reserves = new List<Reserve>();
        }*/
    }
}
