using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace Repository
{
    public class CommentRepository : ICommentRepository
    {
        public IEnumerable<Comment> GetAll()
        {
            return InMemoryDb.Comments;
        }

        public Comment Get(Guid id)
        {
            return InMemoryDb.Comments.SingleOrDefault(x => x.Id == id);
        }

        public Comment Create(Comment comment)
        {
            if (!InMemoryDb.Posts.Any(x => x.Id == comment.PostId))
            {
                throw new Exception("PostId does not exist.");
            }

            InMemoryDb.Comments.Add(comment);
            return InMemoryDb.Comments.LastOrDefault();
        }

        public Comment Update(Comment comment)
        {
            var index = InMemoryDb.Comments.FindIndex(x => x.Id == comment.Id);
            InMemoryDb.Comments[index] = comment;

            return InMemoryDb.Comments[index];
        }

        public bool Delete(Guid id)
        {
            var item = InMemoryDb.Comments.SingleOrDefault(x => x.Id == id);
            if (item != null)
                InMemoryDb.Comments.Remove(item);

            return !InMemoryDb.Comments.Any(x => x.Id == id);
        }

        public IEnumerable<Comment> GetByPostId(Guid postId)
        {
            return InMemoryDb.Comments.Where(x => x.PostId == postId);
        }
    }
}