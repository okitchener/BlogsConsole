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
  //Display all Blogs
  DisplayAllBlogs();
}
else if (choice == "2")
{
  //Add a Blog
  AddABlog();
}
else if (choice == "3")
{
  //Create Post
  CreatePost();
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


static void DisplayAllBlogs()
{
  var db = new DataContext();
  var query = db.Blogs.OrderBy(b => b.Name);

  Console.WriteLine("All blogs in the database:");
  foreach (var item in query)
  {
    Console.WriteLine(item.Name);
  }
}

static void AddABlog()
{
var db = new DataContext();
  Console.Write("Enter a name for a new Blog: ");
var name = Console.ReadLine();

var blog = new Blog { Name = name };


db.AddBlog(blog); 
}

static void CreatePost()
{
  //prompt user to select which blog to add post to
  var db = new DataContext();
  var query = db.Blogs.OrderBy(b => b.BlogId).ToList();
  
  if (!query.Any())
  {
    Console.WriteLine("No blogs available. Please create a blog first.");
    return;
  }
  
  Console.WriteLine("Select the blog you want to add a post to:");
  foreach (var item in query)
  {
    Console.WriteLine($"{item.BlogId}: {item.Name}");
  }
  
  // Validate blog selection
  int blogId;
  bool validSelection = false;
  
  do
  {
    Console.Write("Enter the blog ID: ");
    string input = Console.ReadLine()!;
    
    if (int.TryParse(input, out blogId))
    {
      // Check if the entered blog ID exists in the database
      if (query.Any(b => b.BlogId == blogId))
      {
        validSelection = true;
      }
      else
      {
        Console.WriteLine("Invalid blog ID. Please select from the available blogs.");
      }
    }
    else
    {
      Console.WriteLine("Please enter a valid number.");
    }
  } while (!validSelection);
  
  //post details can now be entered
  Console.Write("Enter the post title: ");
  string title = Console.ReadLine()!;
  Console.Write("Enter the post content: ");
  string content = Console.ReadLine()!;

  var post = new Post { Title = title, Content = content, BlogId = blogId };
  db.AddPost(post);
  Console.WriteLine("Post added successfully!");
}

logger.Info("Program ended");