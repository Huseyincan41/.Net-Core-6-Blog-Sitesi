using Blog.Core.Entities;

namespace Blog.Entity.Entities
{
    public class Article :EntityBase , IEntityBase
    {
        public Article()
        {
            
        }
        public Article(string title,string content,Guid userId, string createdBy,Guid catergoryId,Guid imageId)
        {
            Title = title;
            Content = content;
            UserId = userId;
            CategoryId = catergoryId;
            ImageId = imageId;
            CreatedBy = createdBy;
        }
        
        public String? Title { get; set; }
        public String? Content { get; set; }
        public int? VievCount { get; set; } = 0;
        public Guid? CategoryId { get; set; }
        public Category? Category { get; set; }
        public Guid? ImageId { get; set; }
        public Image? Image { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
       
        public ICollection<ArticleVisitor> ArticleVisitors { get; set; }

    }
}
