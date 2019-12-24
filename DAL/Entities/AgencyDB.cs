namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AgencyDB : DbContext
    {
        public AgencyDB()
            : base("name=AgencyDB")
        {
        }

        public virtual DbSet<Agent> Agent { get; set; }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Bathroom> Bathroom { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Deal> Deal { get; set; }
        public virtual DbSet<Layout> Layout { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<Property> Property { get; set; }
        public virtual DbSet<Target> Target { get; set; }
        public virtual DbSet<Type_of_Property> Type_of_Property { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agent>()
                .HasMany(e => e.Deal)
                .WithRequired(e => e.Agent)
                .HasForeignKey(e => e.Deal_Agent_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Area>()
                .HasMany(e => e.Property)
                .WithOptional(e => e.Area)
                .HasForeignKey(e => e.Pr_Area_FK);

            modelBuilder.Entity<Bathroom>()
                .HasMany(e => e.Property)
                .WithOptional(e => e.Bathroom)
                .HasForeignKey(e => e.Pr_Bathroom_FK);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Deal)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.Deal_Seller_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Deal1)
                .WithRequired(e => e.Client1)
                .HasForeignKey(e => e.Deal_Customer_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Property)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.Pr_Client_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Layout>()
                .HasMany(e => e.Property)
                .WithOptional(e => e.Layout)
                .HasForeignKey(e => e.Pr_Layout_FK);

            modelBuilder.Entity<Material>()
                .HasMany(e => e.Property)
                .WithOptional(e => e.Material)
                .HasForeignKey(e => e.Pr_Material_FK);

            modelBuilder.Entity<Property>()
                .HasMany(e => e.Deal)
                .WithRequired(e => e.Property)
                .HasForeignKey(e => e.Deal_Property_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Target>()
                .HasMany(e => e.Property)
                .WithRequired(e => e.Target)
                .HasForeignKey(e => e.Pr_Target_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Type_of_Property>()
                .HasMany(e => e.Property)
                .WithRequired(e => e.Type_of_Property)
                .HasForeignKey(e => e.Pr_TypeP_FK)
                .WillCascadeOnDelete(false);
        }
    }
}
