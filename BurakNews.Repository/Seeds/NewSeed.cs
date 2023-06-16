using BurakNews.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BurakNews.Repository.Seeds
{
    public class NewSeed : IEntityTypeConfiguration<New>
    {
        public void Configure(EntityTypeBuilder<New> builder)
        {
            builder.HasData(
                new New()
                {
                    Id = 1,
                    CategoryId = 1,
                    Title = "Galatasaray - Fenerbahçe Derbisi",
                    Description = "Süper Lig'de son hafta Galatasaray-Fenerbahçe derbisi oynanacak!",
                    Author = "Erman Toroğlu",
                    CreatedDate = DateTime.Now
                },
                new New()
                {
                    Id = 2,
                    CategoryId = 2,
                    Title = "Türkiye'de Güneş Tutulması",
                    Description = "2022'nin ilk güneş tutulması 30 Nisan'da, ikinci ve son güneş tutulması ise 25 Ekim günü yaşanmıştı. 2023 yılı gök olayları takvimine göre bu yılın güneş tutulması tarihleri belli oldu. Buna göre; 2023 yılı güneş tutulması 20 Nisan 2023'te ve 14 Ekim 2023'te gerçekleşecek.",
                    Author = "Ntv",
                    CreatedDate = DateTime.Now,
                },
                new New()
                {
                    Id = 3,
                    CategoryId = 3,
                    Title = "Başbakanın Son Dakika Açıklaması",
                    Description = "Başbakanın yapmış olduğu açıklama ile ilk yerli akıllı telefonumuzu üretiyoruz.",
                    Author = "Hürriyet"
                }
            );
        }
    }
}
