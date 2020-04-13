using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("public.Диллеры")]
    public partial class Дилеры
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Дилеры()
        {
            Автомобили = new HashSet<Автомобили>();
        }

        [Key]
        [Column("Код_диллера")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Код_диллера { get; set; }

        [Column("Название_фирмы")]
        //[Required]
        [StringLength(20)]
        public string Название_фирмы { get; set; }

        [Column("Адрес_фирмы")]
        //[Required]
        [StringLength(20)]
        public string Адрес_фирмы { get; set; }

        [Column("ФИО_владельца")]
        //[Required]
        [StringLength(50)]
        public string ФИО_владельца { get; set; }

        [Column("Расчетный_код")]
        //[Required]
        [StringLength(20)]
        public string Расчетный_счет { get; set; }

        [Column("Код_банка")]
        public int Код_банка { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Автомобили> Автомобили { get; set; }

        public virtual Банки Банки { get; set; }
    }
}
