namespace BookEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Address")]
    public partial class Address
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Address()
        {
            CoustomerDetails = new HashSet<CoustomerDetails>();
        }

        public int AddressId { get; set; }

        [Required]
        [StringLength(200)]
        public string House { get; set; }

        [Required]
        [StringLength(50)]
        public string Locality { get; set; }

        [Required]
        [StringLength(50)]
        public string pin { get; set; }

        [StringLength(50)]
        public string landmark { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CoustomerDetails> CoustomerDetails { get; set; }
    }
}
