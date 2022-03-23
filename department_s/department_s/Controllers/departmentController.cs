using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using department_s.Models.Database;

namespace department_s.Controllers
{
    public class departmentController : ApiController
    {
        department_student_apiEntities db = new department_student_apiEntities();
        [HttpPost]
        public void Post(department value)
        {



            db.departments.Add(value);
            db.SaveChanges();

        }


        public department Get(int id)
        {
            //  data.students.
            return db.departments.Where(x => x.dep_id == id).FirstOrDefault();

        }


        [HttpDelete]
        // DELETE: api/student/5
        public HttpResponseMessage Delete(int id)
        {
            var department = db.departments.Where(l => l.dep_id.Equals(id)).FirstOrDefault();
            db.departments.Remove(department);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, department);
        }


    }
}
