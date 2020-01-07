using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web1.Models
{
    public class SectionViewModel
    {
        
        [Required]
        [Display(Name = "Section Title")]
        public string SectionTitle { set; get; }
        [Required]
        [Display(Name = "Section Content")]
        public string SectionContent { set; get; }
        [Required]
        [Display(Name = "Section Meta Description")]
        public string SectionMetaDescription { set; get; }
        [Required]
        [Display(Name = "Section Meta Keywords")]
        public string SectionMetaKeywords { set; get; }
        [Required]
        [Display(Name = "Section Meta Author")]
        public string SectionMetaAuthor { set; get; }
        [Required]
        [Display(Name = "Book ID")]
        public int BookID { set; get; }
        
    }
}