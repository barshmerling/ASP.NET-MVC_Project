using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectMovies.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public int ReviewID { get; set; }
        [Display(Name = "Comment Title")]
        [StringLength(20, MinimumLength = 2)]
        [Required]
        public string CommentTitle { get; set; }
        [Display(Name = "Comment Writer")]
        [StringLength(20, MinimumLength = 2)]
        [Required]
        public string CommentWriter { get; set; }
        [Display(Name = "Comment Content")]
        [Required]
        public string CommentContent { get; set; }
        public virtual Review CommentReview { get; set; }
    }
}
