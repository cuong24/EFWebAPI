using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFWebAPI.Models
{
  public class StudentAddress
  {
    public int StudentAddressId { get; set; }
    public string Address1 { get; set; }
    public string Address2 {get; set;}
    public string City {get; set;}
    public string Zipcode {get; set;}
    public string State {get; set;}
    public string Country {get; set;}
    public virtual Student Student {get; set;}
  }
}