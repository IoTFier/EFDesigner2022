//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
//
//     Produced by Entity Framework Visual Editor v4.2.6.3
//     Source:                    https://github.com/msawczyn/EFDesigner
//     Visual Studio Marketplace: https://marketplace.visualstudio.com/items?itemName=michaelsawczyn.EFDesigner
//     Documentation:             https://msawczyn.github.io/EFDesigner/
//     License (MIT):             https://github.com/msawczyn/EFDesigner/blob/master/LICENSE
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Transient
{
   /// <inheritdoc/>
   public partial class TransientContext : DbContext
   {
      #region DbSets
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::Transient.Master> Masters { get; set; }
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::Transient.PersistentDetail> PersistentDetails { get; set; }

      #endregion DbSets

      /// <summary>
      /// Default connection string
      /// </summary>
      public static string ConnectionString { get; set; } = @"Data Source=.\sqlexpress;Initial Catalog=Sandbox;Integrated Security=True;TrustServerCertificate=True";

      /// <inheritdoc />
      public TransientContext() : base()
      {
      }

      /// <summary>
      ///     <para>
      ///         Initializes a new instance of the <see cref="T:Microsoft.EntityFrameworkCore.DbContext" /> class using the specified options.
      ///         The <see cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)" /> method will still be called to allow further
      ///         configuration of the options.
      ///     </para>
      /// </summary>
      /// <param name="options">The options for this context.</param>
      public TransientContext(DbContextOptions<TransientContext> options) : base(options)
      {
      }

      partial void CustomInit(DbContextOptionsBuilder optionsBuilder);

      /// <inheritdoc />
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         optionsBuilder.UseLazyLoadingProxies();

         CustomInit(optionsBuilder);
      }

      partial void OnModelCreatingImpl(ModelBuilder modelBuilder);
      partial void OnModelCreatedImpl(ModelBuilder modelBuilder);

      /// <summary>
      ///     Override this method to further configure the model that was discovered by convention from the entity types
      ///     exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
      ///     and re-used for subsequent instances of your derived context.
      /// </summary>
      /// <remarks>
      ///     If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
      ///     then this method will not be run.
      /// </remarks>
      /// <param name="modelBuilder">
      ///     The builder being used to construct the model for this context. Databases (and other extensions) typically
      ///     define extension methods on this object that allow you to configure aspects of the model that are specific
      ///     to a given database.
      /// </param>
      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         base.OnModelCreating(modelBuilder);
         OnModelCreatingImpl(modelBuilder);

         modelBuilder.HasDefaultSchema("dbo");

         modelBuilder.Entity<global::Transient.Master>().ToTable("Masters").HasKey(t => t.Id);
         modelBuilder.Entity<global::Transient.Master>().Property(t => t.Id).ValueGeneratedOnAdd().IsRequired();
         modelBuilder.Entity<global::Transient.Master>().Property(t => t.Foo).HasMaxLength(100);
         modelBuilder.Entity<global::Transient.Master>().HasMany<global::Transient.PersistentDetail>(p => p.PersistentDetails).WithOne().HasForeignKey("MasterPersistentDetailsId");
         modelBuilder.Entity<global::Transient.Master>().OwnsMany(p => p.TransientDetails, p0 => { p0.WithOwner(); p0.ToTable("TransientDetails"); p0.HasKey(p0x => p0x.Id); p0.Property(t => t.Id).ValueGeneratedOnAdd().IsRequired(); p0.Property(t => t.Baz).HasField("_baz").UsePropertyAccessMode(PropertyAccessMode.Field).HasDefaultValue("Empty").IsRequired(); });
         modelBuilder.Entity<global::Transient.Master>().OwnsOne(p => p.TransientDetailAsJson, p0 => { p0.WithOwner(); p0.ToJson(); p0.HasKey(p0x => p0x.Id); p0.Property(t => t.Id).ValueGeneratedOnAdd().IsRequired(); p0.Property(t => t.Zoom).IsRequired(); p0.Property(t => t.Zoom1).IsRequired(); p0.Property(t => t.Zoom2).IsRequired(); p0.Property(t => t.Zoom3).IsRequired(); });

         modelBuilder.Entity<global::Transient.PersistentDetail>().UseTpcMappingStrategy().ToTable("PersistentDetails").HasKey(t => t.Id);
         modelBuilder.Entity<global::Transient.PersistentDetail>().Property(t => t.Id).ValueGeneratedOnAdd().IsRequired();
         modelBuilder.Entity<global::Transient.PersistentDetail>().Property(t => t.Bar).HasMaxLength(100);

         OnModelCreatedImpl(modelBuilder);
      }
   }
}
