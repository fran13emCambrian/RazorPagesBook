using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;

namespace RazorPagesBook.Models
{
    public class Book
    {


        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        [Display(Name = "Book Title")]
        public string Title { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Category { get; set; }
        public string Author { get; set; }

        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string Edition { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Publisher { get; set; }

        [StringLength(120, MinimumLength = 3)]
        [Required]
        public string Description { get; set; }

        [RegularExpression(@"^-?[0-9][0-9,\.]+$")]
        [Required]
        public string Size { get; set; }


        
            public int Rating { set; get; }
        
    }
}
