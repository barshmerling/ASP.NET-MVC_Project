using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectMovies.Models
{
    public class CinemaLocation
    {
        public int ID { get; set; }
        [Display(Name = "Cinema Latitude")]
        public Double CinemaLatitude { get; set; }
        [Display(Name = "Cinema Longitude")]
        public Double CinemaLongitude { get; set; }
        [Display(Name = "Cinema Name")]
        public string CinemaName { get; set; }
    }
}

