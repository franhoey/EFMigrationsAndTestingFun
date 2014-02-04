using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using EFExampleBlog.Respository.Models;

namespace EFExampleBlog.Respository.EF
{
    class BlogConfiguration : EntityTypeConfiguration<Blog>
    {
        public BlogConfiguration()
        {
            HasKey(b => b.BlogId);

            Property(b => b.Name)
                .HasColumnType("nvarchar");
        }
    }
}
