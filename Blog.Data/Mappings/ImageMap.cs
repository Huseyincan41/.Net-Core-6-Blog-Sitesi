using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
    public class ImageMap : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(new Image
            {
            
                    Id=Guid.Parse("C14E7C98-C5CE-4682-B69B-31D386FFFDEA"),
                    FileName ="images/testimage",
                    FileType="jpg",
                    CreatedBy="admin test",
                    CreatedDate=DateTime.Now,
                    IsDeleted=false
            },
            new Image
            {
                    Id = Guid.Parse("A96A68D1-288A-4C5D-B66C-C58DB5EF8F90"),
                    FileName = "images/vstest",
                    FileType = "png",
                    CreatedBy = "admin test",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
            });
        }
    }
}
