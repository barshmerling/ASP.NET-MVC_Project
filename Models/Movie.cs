using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectMovies.Models
{
    public class Movie
    {
        public int ID { get; set; }
        [Display(Name = "Movie Name")]
        public string NameOfMovie { get; set; }
        [Display(Name = "Movie Rating")]
        [Range(1, 5)]
        public int RatingOfMovie { get; set; }
        [Display(Name = "Movie Video")]
        public string VideoOfMovie { get; set; }
        [Display(Name = "Movie Votes")]
        public int VotesOfMovie { get; set; }
        [Display(Name = "Movie Director")]
        public string DirectorOfMovie { get; set; }
        [Display(Name = "Movie Release Year")]
        public int ReleaseYearOfMovie { get; set; }
        [Display(Name = "Movie Summary")]
        public string SummaryOfMovie { get; set; }
        [Display(Name = "Movie Poster")]
        public string PosterOfMovie { get; set; }
        [Display(Name = "Movie Genre")]
        public string GenreOfMovie { get; set; }
        [Display(Name = "Movie Review")]
        public virtual ICollection<Review> MoviesReviewList { get; set; }
    }
}
