namespace ARM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("public.Марки")]
    public partial class Марки
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Марки()
        {
            Модели = new HashSet<Модели>();
        }

        [Key]
        [Column("Код_марки")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int Код_марки { get; set; }

        [Column("Название_марки")]
       // [Required]
        [StringLength(20)]
        public string Название_марки { get; set; }

        [Column("Дата_создания", TypeName = "date")]
        public DateTime Дата_создания { get; set; }

        // [Required]
        [Column("Код_страны")]
        public int Код_страны { get; set; }
        public virtual Страны Страны { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Модели> Модели { get; set; }
    }
}
