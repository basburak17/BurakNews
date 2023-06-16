using BurakNews.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BurakNews.Repository.Configurations
{
    public class NewConfiguration : IEntityTypeConfiguration<New>
    {
        public void Configure(EntityTypeBuilder<New> builder)
        {
            builder.ToTable("News");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(35);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(3000);
            builder.Property(x => x.Author).HasMaxLength(40);

            //builder.HasOne(x => x.Category).WithMany(x => x.News).HasForeignKey(x => x.CategoryId); 
        }
    }
}
