using EFWebAPI.Models;
using EFWebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Ajax.Utilities;

namespace EFWebAPI.Controllers
{
    public class StudentController : ApiController
    {
            // GET api/values
        [HttpGet]
        public ICollection<Student> LoadAllStudents()
        {
          using (WebContext ctx = new WebContext())
          {
            ICollection<Student> stu = ctx.Students.ToList();
            return stu;
           }
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            using (WebContext ctx = new WebContext())
            {
                Student stu = findStudentById(id, ctx);

                if (stu != null)
			    {
                    return Request.CreateResponse(HttpStatusCode.OK, stu);
			    }
				else
				{
                    return NotFoundRes(id);
                }
            }
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody] Student stu)
        {
            if (stu == null)
			{
                return MissInfoRes();

            }
            try 
            {
                using (WebContext ctx = new WebContext())
                {
                    ctx.Students.Add(stu);
                    ctx.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, stu);
                    message.Headers.Location = new Uri(Request.RequestUri + stu.StudentID.ToString());
                    return message;
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody] Student stu)
        {
            if (stu == null)
            {
                return MissInfoRes();
            }
            try
            {
                using (WebContext ctx = new WebContext())
                {
                    var initialStu = findStudentById(id, ctx);
                    if (initialStu == null)
					{
                        return NotFoundRes(id);
                    }
                    initialStu = stu;
                    ctx.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, stu);
                    message.Headers.Location = new Uri(Request.RequestUri + stu.StudentID.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
			try
			{
                using (WebContext ctx = new WebContext())
                {
                    var stu = findStudentById(id, ctx);
                    if (stu != null)
                    {
                        ctx.Students.Remove(stu);
                        ctx.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        return NotFoundRes(id);
                    }

                }
            }
			catch(Exception ex)
			{
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
			}
        }

        private HttpResponseMessage NotFoundRes (int id)
		{
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No student with id" + id.ToString() + " not found");
        }

        private HttpResponseMessage MissInfoRes()
		{
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Please fill all the require info");
		}

        private Student findStudentById(int id, WebContext ctx)
		{
            var stu = ctx.Students.FirstOrDefault(s => s.StudentID == id);
            return stu;
        }
    }
}
