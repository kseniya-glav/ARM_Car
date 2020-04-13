namespace ARM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("public.Модели")]
    public partial class Модели
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Модели()
        {
            Автомобили = new HashSet<Автомобили>();
        }

        [Key]
        [Column("Код_модели")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Код_модели { get; set; }

        [Column("Код_марки")]
        public int Код_марки { get; set; }

        [Column("Код_типа")]
        public int Код_типа { get; set; }

        [Column("Название_модели")]
        //[Required]
        [StringLength(20)]
        public string Название_модели { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Автомобили> Автомобили { get; set; }

        public virtual Марки Марки { get; set; }

        public virtual Типы Типы { get; set; }
    }
}
