namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Agent")]
    public partial class Agent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Agent()
        {
            Deal = new HashSet<Deal>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_Agent { get; set; }

        [Required]
        [StringLength(50)]
        public string Agent_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Agent_Passport { get; set; }

        [Required]
        [StringLength(50)]
        public string Agent_Position { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deal> Deal { get; set; }
    }
}
