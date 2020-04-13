namespace ARM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("public.Квитанция")]
    public partial class Квитанция
    {
        [Key]
        [Column("Номер_автомобиля", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Номер_автомобиля { get; set; }

        [Key]
        [Column("Время_выдачи", Order = 1)]
        public DateTime Время_выдачи { get; set; }

        [Column("Номер_паспорта")]
        public int Номер_паспорта { get; set; }

        [Column("Время_сдачи")]
        public DateTime? Время_сдачи { get; set; }

        //[Required]
        [StringLength(20)]
        public string Сумма { get; set; }

        public virtual Автомобили Автомобили { get; set; }

        public virtual Арендаторы Арендаторы { get; set; }
    }
}
