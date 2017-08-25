using CRUDapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUDapi.Controllers
{
    public class EmployeeController : ApiController
    {
        [HttpPost][Route ("ins")]
        public string insert(int ide, string ename, string eplace, int ephone)
        {
            DataBaseOneEntities1 db = new DataBaseOneEntities1();
            APITable at = new APITable();
            at.id = ide;
            at.name = ename;
            at.place = eplace;
            at.ph = ephone;
            db.APITables.Add(at);
            db.SaveChanges();
            return "yes";
        }

        [HttpGet][Route ("dis")]
        public IHttpActionResult display()
        {
            List<APITable> li = new List<APITable>();
            using (var a = new DataBaseOneEntities1())
            {
                li = a.APITables.ToList();
                
            }
            return Ok(li) ;
        }

        [HttpGet]
        [Route("ser")]
        public IHttpActionResult search(int ide)
        {
            List<APITable> li = new List<APITable>();
            using (var a = new DataBaseOneEntities1())
            {
                li = a.APITables.Where(x=>x.id == ide).ToList();

            }
            return Ok(li);
        }
        [HttpPost]
        [Route("upd")]
        public string update(int ide, string ename)
        {
            DataBaseOneEntities1 db = new DataBaseOneEntities1();
            APITable at = db.APITables.Single(x=>x.id == ide);
          
            at.name = ename;
           
            db.SaveChanges();
            return "yes";
        }

        [HttpPost]
        [Route("del")]
        public string delete(int ide)
        {
            DataBaseOneEntities1 db = new DataBaseOneEntities1();
            APITable at = db.APITables.Single(x => x.id == ide);

            db.APITables.Remove(at);

            db.SaveChanges();
            return "yes";
        }

        //try

    }

}
