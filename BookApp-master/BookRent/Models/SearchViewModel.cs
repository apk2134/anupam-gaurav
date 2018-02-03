using BookEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookRent.Models
{
    public class SearchViewModel
    {
        public IEnumerable<Books> SearchBook { get; set;}
        public IEnumerable<BookViewModel> AllBookData { get; set; }
        [DisplayName("Subscription")]
        [Required]
        public int SubscriptionId { get; set; }

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

    }
}