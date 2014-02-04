using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using EFExampleBlog.Respository.EF;
using EFExampleBlog.Respository.Migrations;
using EFExampleBlog.Respository.Models;

namespace EFExampleBlog.Respository
{
    public class BlogRepository
    {
        public Blog InsertBlog(Blog blog)
        {
            using (var dbContext = new BloggingContext())
            {
                dbContext.Blogs.Add(blog);
                dbContext.SaveChanges();
            }
            return blog;
        }

        public Blog GetBlog(int blogId)
        {
            using (var dbContext = new BloggingContext())
            {
                return dbContext.Blogs.FirstOrDefault(b => b.BlogId == blogId);
            }
        }

        public Post AddPost(Post post)
        {
            using (var dbContext = new BloggingContext())
            {
                dbContext.Posts.Add(post);
                dbContext.SaveChanges();
            }
            return post;
        }

        public List<Post> SearchPosts(string searchTerm)
        {
            using (var dbContext = new BloggingContext())
            {
                return dbContext.Posts.Where(p =>
                                      p.Title.Contains(searchTerm)
                                      || p.Content.Contains(searchTerm))
                                      .ToList();
            }
        }
        
        //This is used by the test harness to remove test data
        internal void RemoveTestData()
        {
            Database.SetInitializer<BloggingContext>(
                    new MigrateDatabaseToLatestVersion<BloggingContext, Configuration>());

            using (var dbContext = new BloggingContext())
            {
                    dbContext.Posts.RemoveRange(
                        dbContext.Posts);

                    dbContext.Blogs.RemoveRange(
                        dbContext.Blogs);

                dbContext.SaveChanges();
            }
        }

        //This is used by the test harness to generate test data
        internal List<Blog> CreateTestData(List<Blog> dataItems)
        {
            Database.SetInitializer<BloggingContext>(
                    new MigrateDatabaseToLatestVersion<BloggingContext, Configuration>());

            using (var dbContext = new BloggingContext())
            {
                dbContext.Blogs.AddRange(dataItems);
                dbContext.SaveChanges();

            }

            return dataItems;
        }
         

    }
}
