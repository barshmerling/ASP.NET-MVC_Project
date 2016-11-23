using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectMovies.Models
{
    public class Actor
    {

        public int ID { get; set; }
        [Display(Name = "Actor Name")]
        public string FullName { get; set; }
        [Display(Name = "Actor Birth Date")]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Actor Years in industry")]
        public int Years { get; set; }
        [Display(Name = "Actor Gender")]
        public string Gender { get; set; }
        [Display(Name = "Actor Famous Movie")]
        public string FamousMovie { get; set; }
        [Display(Name = "Actor Equity")]
        public Decimal Equity { get; set; }
    }
}
