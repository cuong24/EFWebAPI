using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using EFWebAPI.Models;

namespace EFWebAPI.Data
{
  public class WebContext : DbContext
  {
    public WebContext() : base("name=SchoolDBConnectionString")
    {
      Database.SetInitializer<WebContext>(new CreateDatabaseIfNotExists<WebContext>());
      Database.SetInitializer<WebContext>(new DropCreateDatabaseIfModelChanges<WebContext>());
    }

    public DbSet<Student> Students { get; set; }

    public DbSet<Grade> Grades { get; set; }
  }
}