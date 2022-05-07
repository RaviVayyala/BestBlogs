using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace Repository
{
    public class PostRepository : IPostRepository
    {
        public IEnumerable<Post> GetAll()
        {
            return InMemoryDb.Posts;
        }

        public Post Get(Guid id)
        {
            return InMemoryDb.Posts.SingleOrDefault(x => x.Id == id);
        }

        public Post Create(Post post)
        {
            InMemoryDb.Posts.Add(post);
            return InMemoryDb.Posts.LastOrDefault();
        }

        public Post Update(Post post)
        {
            var index = InMemoryDb.Posts.FindIndex(x => x.Id == post.Id);
            InMemoryDb.Posts[index] = post;

            return InMemoryDb.Posts[index];
        }

        public bool Delete(Guid id)
        {
            var item = InMemoryDb.Posts.SingleOrDefault(x => x.Id == id);
            if (item != null)
                InMemoryDb.Posts.Remove(item);

            return !InMemoryDb.Posts.Any(x => x.Id == id);
        }
    }
}