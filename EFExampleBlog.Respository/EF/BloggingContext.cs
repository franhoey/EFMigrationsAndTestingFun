using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using EFExampleBlog.Respository.Models;

namespace EFExampleBlog.Respository.EF
{
    class BloggingContext : DbContext
    {
        static BloggingContext()
        {
            var _ = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
            var __ = typeof(System.Data.Entity.SqlServerCompact.SqlCeProviderServices); 
        }

        public BloggingContext()
            : base("BlogData")
        {
            
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BlogConfiguration());
            modelBuilder.Configurations.Add(new PostConfiguration());
        } 
    }
}
