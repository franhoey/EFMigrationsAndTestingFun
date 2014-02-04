using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using EFExampleBlog.Respository;
using EFExampleBlog.Respository.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EFExampleBlog.Tests
{
    [TestClass]
    public class BlogPostTests
    {
        private static int _testBlogId;

        [ClassInitialize]
        public static void ClassInitialise(TestContext context)
        {
            var repo = new BlogRepository();

            repo.RemoveTestData();

            var blog = new Blog()
                {
                    Name = "Test Blog Name",
                    Posts = Enumerable.Range(0, 50).Select(i =>
                                                       new Post
                                                           {
                                                               Title = string.Concat("Post Title ", i),
                                                               Content = string.Concat("Blog content ", i)
                                                           }
                ).ToList()
                };

            var testData = repo.CreateTestData(new List<Blog>() { blog });

            _testBlogId = testData[0].BlogId;
        }

        [TestMethod]
        public void CanCreatePost()
        {
            var post = new Post()
                {
                    BlogId = _testBlogId,
                    Title = "Test Insert",
                };

            var serv = new BlogService();
            var result = serv.CreatePost(post);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.PostId > 0);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CreatePostWithNoTitleFails()
        {
            var post = new Post()
            {
                BlogId = _testBlogId,
            };

            var serv = new BlogService();
            var result = serv.CreatePost(post);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.PostId > 0);
        }

        [TestMethod]
        public void CanSearchForPostsByTitle()
        {
            var serv = new BlogService();
            var result = serv.SearchPosts("Title 1");

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 11);
        }



        [TestMethod]
        public void CanSearchForPostsByContent()
        {
            var serv = new BlogService();
            var result = serv.SearchPosts("content 1");

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 11);
        }
    }
}
