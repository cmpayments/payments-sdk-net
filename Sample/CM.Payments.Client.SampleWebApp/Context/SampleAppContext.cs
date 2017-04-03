using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics.CodeAnalysis;
using CM.Payments.Client.SampleWebApp.Models;

namespace CM.Payments.Client.SampleWebApp.Context
{
    [SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global", Justification = "Entity Framework")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global", Justification = "Entity Framework")]
    public class SampleAppContext : DbContext
    {
        public SampleAppContext() : base("SampleApp") { }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}