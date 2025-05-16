using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Base.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public bool IsAdmin { get; set; } = false;
        public string Login { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Position { get; set; } // должность
        public int Wages { get; set; } // зарплата
    }
}
