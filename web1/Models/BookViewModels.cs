using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web1.Models
{
    public class BookViewModel
    {
        [Required]
        [Display(Name = "Book Title")]
        public string BookTitle { set; get; }
        [Required]
        [Display(Name = "Book Content")]
        public string BookContent { set; get; }
        [Required]
        [Display(Name = "Book Meta Description")]
        public string BookMetaDescription { set; get; }
        [Required]
        [Display(Name = "Book Meta Keywords")]
        public string BookMetaKeywords { set; get; }
        [Required]
        [Display(Name = "Book Meta Author")]
        public string BookMetaAuthor { set; get; }
    }

    
}