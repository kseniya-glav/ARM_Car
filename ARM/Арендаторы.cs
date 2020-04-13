
namespace ARM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("public.Арендаторы")]
    public partial class Арендаторы
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Арендаторы()
        {
            Квитанция = new HashSet<Квитанция>();
        }

        [Key]
        [Column("Номер_паспорта")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Номер_паспорта { get; set; }

        [Column("ФИО_арендатора")]
        //[Required]
        [StringLength(20)]
        public string ФИО_арендатора { get; set; }

        [Column("Адрес_арендатора")]
        //[Required]
        [StringLength(20)]
        public string Адрес_арендатора { get; set; }

        public int Возраст { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Квитанция> Квитанция { get; set; }
    }
}
