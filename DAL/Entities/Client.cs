namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            Deal = new HashSet<Deal>();
            Deal1 = new HashSet<Deal>();
            Property = new HashSet<Property>();
        }

        [Key]
        public int Id_Client { get; set; }

        [Required]
        [StringLength(50)]
        public string Client_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Client_Passport { get; set; }

        [StringLength(50)]
        public string Client_INN { get; set; }

        [StringLength(50)]
        public string Client_BIK { get; set; }

        [StringLength(50)]
        public string Client_SNILS { get; set; }

        [Required]
        [StringLength(50)]
        public string Client_Phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deal> Deal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deal> Deal1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Property> Property { get; set; }
    }
}
