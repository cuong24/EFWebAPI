using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EFWebAPI.Models
{
  [Table("StudentInfo", Schema = "School")]
  public class Student
  {
    public Student()
    {
      this.Courses = new HashSet<Course>();
    }
    public int StudentID { get; set; }
    public string StudentName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public byte[] Photo { get; set; }
    public decimal Height { get; set; }
    public float Weight { get; set; }

    public Grade Grade { get; set; }
    public StudentAddress StudentAddress { get; set; }
    public ICollection<Course> Courses { get; set; }
    public Standard Standard { get; set; }
  }
}