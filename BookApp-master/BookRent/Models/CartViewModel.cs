using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookRent.Models
{
    public class CartViewModel
    {
        [Required]
        public string BookId { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public string Publisher { get; set; }
    }
}