namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Deal")]
    public partial class Deal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_Deal { get; set; }

        [Column(TypeName = "date")]
        public DateTime Deal_Date { get; set; }

        [Required]
        [StringLength(50)]
        public string Deal_Form_of_Payment { get; set; }

        [StringLength(50)]
        public string Deal_Mortgage_Period { get; set; }

        [StringLength(50)]
        public string Deal_Monthly_Payout { get; set; }

        public decimal Deal_Total_Cost { get; set; }

        public int Deal_Seller_FK { get; set; }

        public int? Deal_Customer_FK { get; set; }

        public int Deal_Property_FK { get; set; }

        public int Deal_Agent_FK { get; set; }

        public decimal Deal_AgentShare_Cost { get; set; }

        public virtual Agent Agent { get; set; }

        public virtual Client Client { get; set; }

        public virtual Client Client1 { get; set; }

        public virtual Property Property { get; set; }
    }
}
