namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Property")]
    public partial class Property
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Property()
        {
            Deal = new HashSet<Deal>();
        }

        [Key]
        public int Id_Property { get; set; }

        public decimal Pr_Cost { get; set; }

        [StringLength(50)]
        public string Pr_Address { get; set; }

        public decimal? Pr_Metric_area { get; set; }

        [Required]
        [StringLength(50)]
        public string Pr_Floor { get; set; }

        public decimal? Pr_Plot_size { get; set; }

        public int Pr_Number_of_rooms { get; set; }

        public int Pr_Client_FK { get; set; }

        public int Pr_TypeP_FK { get; set; }

        public int Pr_Target_FK { get; set; }

        public int? Pr_Area_FK { get; set; }

        public int? Pr_Bathroom_FK { get; set; }

        public int? Pr_Layout_FK { get; set; }

        public int? Pr_Material_FK { get; set; }

        public virtual Area Area { get; set; }

        public virtual Bathroom Bathroom { get; set; }

        public virtual Client Client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deal> Deal { get; set; }

        public virtual Layout Layout { get; set; }

        public virtual Material Material { get; set; }

        public virtual Target Target { get; set; }

        public virtual Type_of_Property Type_of_Property { get; set; }
    }
}
