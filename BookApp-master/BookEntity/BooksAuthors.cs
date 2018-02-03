namespace BookEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BooksAuthors
    {
        public int AuthorId { get; set; }

        [Required]
        [StringLength(50)]
        public string BookId { get; set; }

        [Key]
        [StringLength(50)]
        public string BookAuthorid { get; set; }

        public virtual Authors Authors { get; set; }

        public virtual Books Books { get; set; }
    }
}
