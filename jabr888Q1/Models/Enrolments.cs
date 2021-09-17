using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace jabr888Q1.Models
{
    public class Enrolments
    {
        [Key]
        public int EnrolmentNum { get; set; }
        public int StudentId { get; set; }
        public string Course { get; set; }
    }
}
