namespace ARM
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    public partial class ModelCarRental: DbContext
    {
        public ModelCarRental() 
            : base("Server=127.0.0.1;Database=carrental2;User Id=postgres;Password=12345")
        {
        }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Автомобили> Автомобили { get; set; }
        public virtual DbSet<Автопрокаты> Автопрокаты { get; set; }
        public virtual DbSet<Арендаторы> Арендаторы { get; set; }
        public virtual DbSet<Банки> Банки { get; set; }
        public virtual DbSet<Дилеры> Дилеры { get; set; }
        public virtual DbSet<Квитанция> Квитанция { get; set; }
        public virtual DbSet<Марки> Марки { get; set; }
        public virtual DbSet<Модели> Модели { get; set; }
        public virtual DbSet<Страны> Страны { get; set; }
        public virtual DbSet<Типы> Типы { get; set; }
        public virtual DbSet<Уровни_доступа> Уровни_доступа { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Автомобили>()
                .Property(e => e.Цена_за_сутки)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Автомобили>()
                .HasMany(e => e.Квитанция)
                .WithRequired(e => e.Автомобили)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Автопрокаты>()
                .HasMany(e => e.Автомобили)
                .WithRequired(e => e.Автопрокаты)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Арендаторы>()
                .HasMany(e => e.Квитанция)
                .WithRequired(e => e.Арендаторы)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Банки>()
                .HasMany(e => e.Автопрокаты)
                .WithRequired(e => e.Банки)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Банки>()
                .HasMany(e => e.Дилеры)
                .WithRequired(e => e.Банки)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Дилеры>()
                .HasMany(e => e.Автомобили)
                .WithRequired(e => e.Дилеры)
                .HasForeignKey(e => e.Код_диллера)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Марки>()
                .HasMany(e => e.Модели)
                .WithRequired(e => e.Марки)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Модели>()
                .HasMany(e => e.Автомобили)
                .WithRequired(e => e.Модели)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Страны>()
                .HasMany(e => e.Марки)
                .WithRequired(e => e.Страны)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Типы>()
                .HasMany(e => e.Модели)
                .WithRequired(e => e.Типы)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Уровни_доступа>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Уровни_доступа)
                .HasForeignKey(e => e.level)
                .WillCascadeOnDelete(false);
        }
    }
}
