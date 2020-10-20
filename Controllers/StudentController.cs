using EFWebAPI.Models;
using EFWebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EFWebAPI.Controllers
{
    public class StudentController : ApiController
    {
            // GET api/values
        [HttpGet]
        public ICollection<Student> Get()
        {
          using (WebContext ctx = new WebContext())
          {
            var student = new Student() { StudentName = "Bill" };

            ctx.Students.Add(student);
            ctx.SaveChanges();

            ICollection<Student> stu = ctx.Students.ToList();

            return stu;
           }
        }

        // GET api/values/5
        public Student Get(int id)
        {
          using (WebContext ctx = new WebContext())
          {
            Student stu = ctx.Students.FirstOrDefault(b => b.StudentID == id);
            return stu;
          }
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public string Delete(int id)
        {
          using (WebContext ctx = new WebContext())
          {
            var student = ctx.Students.FirstOrDefault(s => s.StudentID == id);

            ctx.Students.Remove(student);
            ctx.SaveChanges();

            return "Success";
          }
        }
    }
}
