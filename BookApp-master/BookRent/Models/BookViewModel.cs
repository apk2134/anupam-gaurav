using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookRent.Models
{
    public class BookViewModel
    {
        [Required]
        public string BookId { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public int Availability { get; set; }
        [Required]
        [DisplayName("Author")]

        public int AuthorId { get; set; }
        [DisplayName("Category")]
        [Required]
        public int CategoryId { get; set; }
        [DisplayName("AuthorName")]
        public string Author { get; set; }
        [DisplayName("CategoryName")]
        public string Category { get; set; }

    }
}