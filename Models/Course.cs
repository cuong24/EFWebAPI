using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity.Spatial;

namespace EFWebAPI.Models
{
  [Table("Course", Schema = "School")]
  public class Course
  {
    public int CourseId { get; set; }
    public string CourseName {get; set;}
    public DbGeography Location {get; set;}
    public ICollection<Student> Students {get; set;}
    [ForeignKey("Teacher")]
    public int TeacherId { get; set; }
    public Teacher Teacher {get; set;}
  }
}