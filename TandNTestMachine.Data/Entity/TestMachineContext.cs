using System;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace TandNTestMachine.Data.Entity
{
    public class TestMachineContext : DbContext
    {
        public DbSet<AppData> AppData { get; set; }
        public DbSet<Operation> Operation { get; set; }
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<OperationRecipe> OperationRecipe { get; set; }
        public DbSet<TagAddress> TagAddress { get; set; }
        public DbSet<TestProcedure> TestProcedure { get; set; }
        public DbSet<TestProcedureOperation> TestProcedureOperation { get; set; }
        public DbSet<TestProcedureSensorLog> TestProcedureSensorLog { get; set; }

        //public TestMachineContext(): base()
        //{
        //    var builder = new ConfigurationBuilder();
        //    builder.AddJsonFile("appsettings.json", optional: false);

        //    var configuration = builder.Build();

        //    connectionString = configuration.GetConnectionString("TestMachineDB").ToString();

        //}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(connectionString);
            //optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=TNTestMachine;Trusted_Connection=True;");
            //optionsBuilder.UseSqlite(@"Data Source=C:\ProgramData\Bones Controls LLC\Tuft And Needle Test Machine\data.sqlite");

            var location = Path.Combine($"{Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments)}",
                @"Bones Controls LLC\Tuft and Needle Test Machine\data.sqlite");


            optionsBuilder.UseSqlite($"Data Source={location}");


            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppData>(entity =>
            {
                //entity.ToTable("AppData");
                entity.Property(p => p.DataKey).IsRequired();
                entity.Property(p => p.DataValue).IsRequired();
            });

            modelBuilder.Entity<Operation>(entity =>
            {
                //entity.ToTable("Operation");
                entity.Property(p => p.OpCode).IsRequired();
            });
            //modelBuilder.Entity<Recipe>().ToTable("Recipe");

            var entity = modelBuilder.Entity<Recipe>()
                .HasMany(r => r.Operations)
                .WithMany(s => s.Recipes)
                .UsingEntity<OperationRecipe>
                (joinEntity => joinEntity.HasOne<Operation>().WithMany(),
                    joinEntyty => joinEntyty.HasOne<Recipe>().WithMany());
            entity.Property(p => p.OperationIndex);
            entity.Property(p => p.Param1);
            entity.Property(p => p.Param2);
            entity.Property(p => p.Param3);
            entity.Property(p => p.Param4);
            entity.Property(p => p.Param5);

            modelBuilder.Entity<OperationRecipe>(entity =>
            {
                entity.Property(p => p.OperationId).IsRequired();
                entity.Property(p => p.RecipeId).IsRequired();
                entity.Property(p => p.OperationIndex).IsRequired();
                entity.HasKey("OperationId", "RecipeId", "OperationIndex");
            });

            modelBuilder.Entity<TagAddress>(entity =>
            {
                entity.Property(p => p.TagName).IsRequired();
                entity.Property(p => p.PLCAddress).IsRequired();
            });
        }
    }
}