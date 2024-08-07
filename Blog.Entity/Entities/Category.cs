﻿using Blog.Core.Entities;

namespace Blog.Entity.Entities
{
    public class Category :EntityBase
    {
        public Category()
        {
            
        }
        public Category(string name,string createdBy)
        {
            Name = name;
            CreatedBy = createdBy;
        }
        public String Name { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
