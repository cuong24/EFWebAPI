using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EFWebAPI.Models
{
  [Table("Teacher", Schema = "School")]
  public class Teacher
  {                                                  
    public int TeacherId { get; set; }               
    public string TeacherName { get; set; }
    public int TeacherType { get; set; }
    public virtual Standard Standard { get; set; }
  }
}