using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace Api.Tests
{
    public static class TestData
    {
        public static IEnumerable<Post> GetPosts()
        {
            return new List<Post>()
            {
                new Post(){
                    Id = new Guid("6a495018-2790-4da2-8199-bfc1bb0aaed2"),
                    Title = "Post title 1",
                    Content = "Post content 1",
                    CreationDate = new DateTime()
                },
                new Post(){
                    Id = new Guid("d73e151c-2f97-4e2b-b7a2-661916018f09"),
                    Title = "Post title 2",
                    Content = "Post content 2",
                    CreationDate = new DateTime(),
                },
                new Post(){
                    Id = new Guid("3e088d42-b502-40da-888e-4d96a73e7ff2"),
                    Title = "Post title 3",
                    Content = "Post content 3",
                    CreationDate = new DateTime(),
                }
            };
        }

        public static IEnumerable<Comment> GetComments()
        {
            return new List<Comment>()
            {
                new Comment(){
                    Id = new Guid("02b23f1a-bd5f-4077-94c1-a525d2110da7"),
                    PostId = GetPosts().FirstOrDefault().Id,
                    Author = "Author 1",
                    Content = "Comment content 1",
                    CreationDate = new DateTime()
                },
                 new Comment(){
                    Id = new Guid("5dd01878-dc67-4f35-a0c1-5848bd62685d"),
                    PostId = GetPosts().FirstOrDefault().Id,
                    Author = "Author 2",
                    Content = "Comment content 2",
                    CreationDate = new DateTime()
                },
                new Comment(){
                    Id = new Guid("8bc7cc3d-4c3e-45ae-9ca7-6ea35917f681"),
                    PostId = GetPosts().LastOrDefault().Id,
                    Author = "Author 3",
                    Content = "Comment content 3",
                    CreationDate = new DateTime()
                },
                 new Comment(){
                    Id = new Guid("8b1fe85a-be9a-4fab-92ba-9192803659b4"),
                    PostId = GetPosts().LastOrDefault().Id,
                    Author = "Author 4",
                    Content = "Comment content 4",
                    CreationDate = new DateTime()
                },
            };
        }

        public static IEnumerable<Comment> GetComments(Guid postId)
        {
            return GetComments().Where(x => x.PostId == postId);
        }
    }

}