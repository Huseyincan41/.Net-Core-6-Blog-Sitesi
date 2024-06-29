using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasData(new Article
            {
                Id=Guid.NewGuid(),
                Title="Asp.net Core Deneme Makalesi 1",
                Content= " Asp.net Core Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır.",
                VievCount=15,
                CategoryId= Guid.Parse("43B000D9-CC6A-47D7-BC38-4C226E4C4332"), 
                ImageId= Guid.Parse("C14E7C98-C5CE-4682-B69B-31D386FFFDEA"),
                CreatedBy="Admin Test",
                CreatedDate=DateTime.Now,
                IsDeleted=false,
                UserId= Guid.Parse("57D7ADD5-F617-43B9-95D6-D48ABD90AF06"),
            },
            new Article
            {
                Id = Guid.NewGuid(),
                Title = "Visual Studio  Deneme Makalesi 1",
                Content = " Visual Studio Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır.",
                VievCount = 15,
                CategoryId=Guid.Parse("EB22AA4B-CE51-424B-BC1F-E02C7838D2E3"),
                ImageId = Guid.Parse("A96A68D1-288A-4C5D-B66C-C58DB5EF8F90"),
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                UserId= Guid.Parse("50BC0A8F-2F1E-4E21-B191-39E083BDFCD8"),
            }
            
            );
        }
    }
}
