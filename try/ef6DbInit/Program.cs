using System;
using System.Linq;

namespace ef6DbInit
{
    class Program
    {
        static void Main(string[] args)
        {
            var connStr = "Server=localhost,1433;Database=ef6GetStarted;Trusted_Connection=True;";

            using (var db = new BloggingContext(connStr))
            {
                // Note: This sample requires the database to be created before running.

                // Create
                Console.WriteLine("Inserting a new blog");
                db.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                db.SaveChanges();

                // Read
                Console.WriteLine("Querying for a blog");
                var blog = db.Blogs
                    .OrderBy(b => b.BlogId)
                    .First();

                // Update
                Console.WriteLine("Updating the blog and adding a post");
                blog.Url = "https://devblogs.microsoft.com/dotnet";
                blog.Posts.Add(
                    new Post { Title = "Hello World", Content = "An EF6 App!" });
                db.SaveChanges();

                // Delete
                Console.WriteLine("Delete the blog");
                db.Blogs.Remove(blog);
                db.SaveChanges();
            }
            Console.WriteLine("Done!");
        }
    }
}
