using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System;

namespace jabr888Q1.Models
{
    public class Students
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
