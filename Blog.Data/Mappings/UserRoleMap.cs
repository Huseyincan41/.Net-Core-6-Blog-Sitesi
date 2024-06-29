using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");
            builder.HasData(new AppUserRole
            {
                UserId= Guid.Parse("57D7ADD5-F617-43B9-95D6-D48ABD90AF06"),
                RoleId= Guid.Parse("6FD4922E-C8E2-4397-B7F8-ADD5D2879121"),
            },
            new AppUserRole
            {
                UserId= Guid.Parse("50BC0A8F-2F1E-4E21-B191-39E083BDFCD8"),
                RoleId= Guid.Parse("ED992D7D-D22C-498D-9407-E8D9F5094C34"),
            });
        }
    }
}
