using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EFWebAPI.Models
{
  [Table("StudentAddress", Schema = "School")]
  public class StudentAddress
  {
    public int StudentAddressId { get; set; }
    public string Address1 { get; set; }
    public string Address2 {get; set;}
    public string City {get; set;}
    public string Zipcode {get; set;}
    public string State {get; set;}
    public string Country {get; set;}
    [Required]
    public Student Student {get; set;}
  }
}