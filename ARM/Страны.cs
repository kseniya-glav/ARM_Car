namespace ARM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("public.Страны")]

    public partial class Страны
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Страны()
        {
            Марки = new HashSet<Марки>();
        }

        [Key]
        [Column("Код_страны")]
        public int Код_страны { get; set; }

        [Column("Название_страны")]
        [Required]
        [StringLength(20)]
        public string Название_страны { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Марки> Марки { get; set; }
    }
}
