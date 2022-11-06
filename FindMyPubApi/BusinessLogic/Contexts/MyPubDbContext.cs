using FindMyPubApi.BusinessLogic.Models;
using FindMyPubApi.BusinessLogic.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;

namespace FindMyPubApi.BusinessLogic.Contexts
{
    public class MyPubDbContext : DbContext
    {
        private readonly ISeeder _seeder;

        public MyPubDbContext(DbContextOptions<MyPubDbContext> options, ISeeder seeder) : base(options)
        {
            _seeder = seeder;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pub>()
                .Property(pub => pub.Tags)
                .HasConversion(new ValueConverter<List<string>, string>(
                        v => JsonSerializer.Serialize(v, new JsonSerializerOptions()),
                        v => JsonSerializer.Deserialize<List<string>>(v, new JsonSerializerOptions()) ?? new List<string>()
                    )
                );

            var records = _seeder.GetRecords();

            modelBuilder.Entity<Pub>().HasData(records.Select(pub => pub with { Reviews = null }));
            modelBuilder.Entity<PubReview>().HasData(records.SelectMany(pub => pub.Reviews).Select(review => review with { Pub = null }).ToList());
        }
    }
}
