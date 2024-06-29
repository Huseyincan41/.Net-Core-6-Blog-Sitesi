using Blog.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Blog.Entity.Entities
{
    public class AppUser :IdentityUser<Guid>,IEntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid ImageId { get; set; } = Guid.Parse("6638e99a-f4b1-48a1-b454-a11bf4b634d7");
        public Image Image { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
