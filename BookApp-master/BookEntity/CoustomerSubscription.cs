namespace BookEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CoustomerSubscription")]
    public partial class CoustomerSubscription
    {
        public int CoustomerId { get; set; }

        public int SubscriptionId { get; set; }

        [Key]
        [StringLength(50)]
        public string CustomerSubscription { get; set; }

        public int? booksTaken { get; set; }

        public int booksRemaning { get; set; }

        public virtual CoustomerDetails CoustomerDetails { get; set; }

        public virtual Subscriptions Subscriptions { get; set; }
    }
}
