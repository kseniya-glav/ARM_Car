namespace ARM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("public.users")]

    public partial class Users
    {
        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string login { get; set; }

        [Required]
        [StringLength(36)]
        public string prefixpassword { get; set; }

        [Required]
        [StringLength(40)]
        public string hashpassword { get; set; }

        public int level { get; set; }

        [Column(TypeName = "date")]
        public DateTime date { get; set; }

        public virtual Уровни_доступа Уровни_доступа { get; set; }
    }
}
