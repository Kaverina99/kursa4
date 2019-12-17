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

        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Bathroom> Bathrooms { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Deal> Deals { get; set; }
        public virtual DbSet<Layout> Layouts { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<Target> Targets { get; set; }
        public virtual DbSet<Type_of_Property> Type_of_Property { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agent>()
                .HasMany(e => e.Deals)
                .WithRequired(e => e.Agent)
                .HasForeignKey(e => e.Deal_Agent_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Area>()
                .HasMany(e => e.Properties)
                .WithOptional(e => e.Area)
                .HasForeignKey(e => e.Pr_Area_FK);

            modelBuilder.Entity<Bathroom>()
                .HasMany(e => e.Properties)
                .WithOptional(e => e.Bathroom)
                .HasForeignKey(e => e.Pr_Bathroom_FK);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Deals)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.Deal_Seller_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Deals1)
                .WithOptional(e => e.Client1)
                .HasForeignKey(e => e.Deal_Customer_FK);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Properties)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.Pr_Client_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Layout>()
                .HasMany(e => e.Properties)
                .WithOptional(e => e.Layout)
                .HasForeignKey(e => e.Pr_Layout_FK);

            modelBuilder.Entity<Material>()
                .HasMany(e => e.Properties)
                .WithOptional(e => e.Material)
                .HasForeignKey(e => e.Pr_Material_FK);

            modelBuilder.Entity<Property>()
                .HasMany(e => e.Deals)
                .WithRequired(e => e.Property)
                .HasForeignKey(e => e.Deal_Property_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Target>()
                .HasMany(e => e.Properties)
                .WithRequired(e => e.Target)
                .HasForeignKey(e => e.Pr_Target_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Type_of_Property>()
                .HasMany(e => e.Properties)
                .WithRequired(e => e.Type_of_Property)
                .HasForeignKey(e => e.Pr_TypeP_FK)
                .WillCascadeOnDelete(false);
        }
    }
}
