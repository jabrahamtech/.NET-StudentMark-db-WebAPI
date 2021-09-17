using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System;
using jabr888Q1.DTO;

namespace jabr888Q1.Models
{
    public class Marks
    {
        [Key]
        public int Id { get; set; }
        public float A1 { get; set; }
        public float A2 { get; set; }
    }
}
