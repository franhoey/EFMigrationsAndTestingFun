using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFExampleBlog.Respository;
using EFExampleBlog.Respository.Models;

namespace EFExampleBlog
{
    public class BlogService
    {
        public Post CreatePost(Post post)
        {
            if(string.IsNullOrWhiteSpace(post.Title))
                throw new ArgumentException("Post Title must be populated", "post");
            
            var repo = new BlogRepository();
            repo.AddPost(post);

            return post;
        }

        public List<Post> SearchPosts(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return null;

            var repo = new BlogRepository();
            return repo.SearchPosts(searchTerm);
        }
    }
}
