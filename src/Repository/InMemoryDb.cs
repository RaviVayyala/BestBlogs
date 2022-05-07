using System.Collections.Generic;
using Model;

namespace Repository
{
    public static class InMemoryDb
    {
        public static List<Comment> Comments = new();
        public static List<Post> Posts = new();
    }
}