namespace ARM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("public.Автомобили")]
    public partial class Автомобили
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Автомобили()
        {
            Квитанция = new HashSet<Квитанция>();
        }

        [Key]
        [Column("Номер_автомобиля")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Номер_автомобиля { get; set; }

        [Column("Код_модели")]
        public int Код_модели { get; set; }

        [Column("Основной_цвет")]
        //[Required]
        [StringLength(20)]
        public string Основной_цвет { get; set; }

        [Column("Состояние")]
        //[Required]
        [StringLength(20)]
        public string Состояние { get; set; }

        [Column("Код_диллера")]
        public int Код_диллера { get; set; }

        [Column("Цена_за_сутки")]
        public decimal Цена_за_сутки { get; set; }

        [Column("Код_автопроката")]
        public int Код_автопроката { get; set; }

        public virtual Автопрокаты Автопрокаты { get; set; }

        public virtual Дилеры Дилеры { get; set; }

        public virtual Модели Модели { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Квитанция> Квитанция { get; set; }
    }
}
