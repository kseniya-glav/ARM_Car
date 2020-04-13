
namespace ARM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Банки")]
    public partial class Банки 
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
       
        public Банки()
        {
            Автопрокаты = new HashSet<Автопрокаты>();
            Дилеры = new HashSet<Дилеры>();
        }
        [Key]
        [Column("Код_банка")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Код_банка { get; set; }

        [Column("Название_банка")]
       // [Required]
        [StringLength(20)]
        public string Название_банка { get; set; }

        [Column("Адрес_банка")]
       // [Required]
        [StringLength(20)]
        public string Адрес_банка { get; set; }

        [Column("Реквизиты_банка")]
       // [Required]
        [StringLength(20)]
        public string Реквизиты_банка { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Автопрокаты> Автопрокаты { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Дилеры> Дилеры { get; set; }
    }
}
