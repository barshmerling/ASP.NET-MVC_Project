using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectMovies.Models
{
    public class Review
    {
        public int ID { get; set; }
        [Display(Name = "Review Title")]
        [Required]
        public string ReviewTitle { get; set; }
        [Display(Name = "Review Writer Name")]
        [Required]
        public string ReviewWriterName { get; set; }
        [Display(Name = "Review Date")]
        public DateTime ReviewDate { get; set; }
        [Display(Name = "Review Content")]
        public string ReviewContent { get; set; }
        public virtual ICollection<Comment> CommentList { get; set; }
    }
}
