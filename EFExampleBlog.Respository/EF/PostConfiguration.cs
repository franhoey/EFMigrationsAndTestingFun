using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using EFExampleBlog.Respository.Models;

namespace EFExampleBlog.Respository.EF
{
    class PostConfiguration : EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            HasKey(p => p.PostId);

            Property(p => p.Title)
                .HasColumnType("nvarchar");
            Property(p => p.Tags)
                .HasColumnType("nvarchar");
        }
    }
}
