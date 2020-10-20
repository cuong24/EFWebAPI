using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EFWebAPI.Models
{
  [Table("Standard", Schema = "School")]
  public class Standard
  {
    public int StandardId { get; set; }
    public string StandardName {get; set;}
    public string Description {get; set;}


    public ICollection<Student> Students {get; set;}
    public ICollection<Teacher> Teachers {get; set;}
  }
}