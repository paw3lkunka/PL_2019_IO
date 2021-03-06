using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Pesel { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public DateTime Birthday { get; set; }
        public virtual List<Employment> ActiveEmployments { get; set; }
    }
}
