using BurakNews.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BurakNews.Repository.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
            new Category()
            {
                Id = 1,
                Name = "Spor",
                Description = "Spora dair tüm gündem haberlerin yer aldığı kategori.",
                CreatedDate = DateTime.Now
            },
            new Category()
            {
                Id = 2,
                Name = "Bilim",
                Description = "Bilime dair tüm gündem haberlerin yer aldığı kategori.",
                CreatedDate = DateTime.Now
            },
            new Category()
            {
                Id = 3,
                Name = "Siyaset",
                Description = "Siyasete dair tüm gündem haberlerin yer aldığı kategori.",
                CreatedDate = DateTime.Now
            });
        }
    }
}
