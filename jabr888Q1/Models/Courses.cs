using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System;

namespace jabr888Q1.Models
{
    public class Courses
    {
        [Key]
        public string Code { get; set; }
        public string Start1 { get; set; }
        public string End1 { get; set; }
        public string Weekday1 { get; set; }
        public string Location1 { get; set; }
        public string Start2 { get; set; }
        public string End2 { get; set; }
        public string Weekday2 { get; set; }
        public string Location2 { get; set; }

    }
}
