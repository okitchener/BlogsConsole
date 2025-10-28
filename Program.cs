﻿using Azure.Core.Pipeline;
using NLog;
string path = Directory.GetCurrentDirectory() + "//nlog.config";

// create instance of Logger
var logger = LogManager.Setup().LoadConfigurationFromFile(path).GetCurrentClassLogger();

logger.Info("Program started");

//Main Menu Text
Console.WriteLine("Blogs and Posts");
Console.WriteLine("1. Display All Blogs");
Console.WriteLine("2. Add Blog");
Console.WriteLine("3. Create Post");
Console.WriteLine("4. Display Posts");

// Input Selection
string? choice = Console.ReadLine();
logger.Info("User choice: {Choice}", choice);

if (choice == "1")
{
  //Displaye all Blogs
}
else if (choice == "2")
{
  //Add a Blog
}
else if (choice == "3")
{
  //Create Post
}
else if (choice == "4")
{
  //Display Posts
}
else
{
  Console.WriteLine("Invalid choice. Please try again.");
  logger.Info("Invalid choice");
}




// Create and save a new Blog
// Console.Write("Enter a name for a new Blog: ");
// var name = Console.ReadLine();

// var blog = new Blog { Name = name };

// var db = new DataContext();
// db.AddBlog(blog);
// logger.Info("Blog added - {name}", name);

// // Display all Blogs from the database
// var query = db.Blogs.OrderBy(b => b.Name);

// Console.WriteLine("All blogs in the database:");
// foreach (var item in query)
// {
//   Console.WriteLine(item.Name);
// }

logger.Info("Program ended");