namespace ARM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("public.Типы")]
    public partial class Типы
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Типы()
        {
            Модели = new HashSet<Модели>();
        }

        [Key]
        [Column("Код_типа")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int Код_типа { get; set; }

        [Column("Название_типа")]
        //[Required]
        [StringLength(50)]
        public string Название_типа { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Модели> Модели { get; set; }
    }
}
