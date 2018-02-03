namespace BookEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BillDetails
    {
        [Key]
        public int BillId { get; set; }

        public int CoustomerId { get; set; }

        public int SubscriptionId { get; set; }

        public DateTime RenualDate { get; set; }

        public virtual CoustomerDetails CoustomerDetails { get; set; }

        public virtual Subscriptions Subscriptions { get; set; }
    }
}
