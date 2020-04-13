namespace ARM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using System.Data.Entity.Spatial;
    [Table("public.Автопрокаты")]
    public partial class Автопрокаты
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Автопрокаты()
        {
            Автомобили = new HashSet<Автомобили>();
        }

        [Key]
        [Column("Код_автопроката")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Код_автопроката { get; set; }

        [Column("Собственник_автопроката")]
        //[Required]
        [StringLength(20)]
        public string Собственник_автопроката { get; set; }

        [Column("Название_автопроката")]
        //[Required]
        [StringLength(20)]
        public string Название_автопроката { get; set; }

        [Column("Адрес_автопроката")]
        //[Required]
        [StringLength(20)]
        public string Адрес_автопроката { get; set; }

        [Column("Расчетный_счет")]
       // [Required]
        [StringLength(20)]
        public string Расчетный_счет { get; set; }

        [Column("Код_банка")]
        public int Код_банка { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Автомобили> Автомобили { get; set; }

        public virtual Банки Банки { get; set; }
    }
}
