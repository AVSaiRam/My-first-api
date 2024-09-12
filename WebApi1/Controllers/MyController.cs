using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi1.Models;

namespace WebApi1.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class MyController : ControllerBase
    {
        NewDbContext dbcontext = new NewDbContext();
        List<CustInfo> c = new List<CustInfo>
            {
                new CustInfo
                {
                    Id = 1,
            Name="sairam",
            Description="future NO1"
                },
                new CustInfo
                {
                    Id=2,
                    Name="again me",
                    Description="you are NO 2"
                }
                };


        [HttpPost]
        [Route("[action]")]
        public ActionResult AddData([FromBody] CustInfo info)
        {

            c.Add(info);
            return Ok(c);
        }

        [HttpPut]
        public ActionResult AlterData([FromQuery]int id, [FromQuery] string name, [FromBody] string disc)
        {
           var value= c.Find(x=> x.Id == id);
            value.Name=name;
            value.Description=disc;
            return Ok(c);

        }
        [HttpGet]
        public ActionResult GetTest()
        {

            return Ok(dbcontext.Repotebs.ToList());
        }
        [HttpPost]
        [Route("[action]")]
        public ActionResult PostTest([FromQuery]Repoteb repoteb)
        {
            dbcontext.Repotebs.Add(repoteb);
            dbcontext.SaveChanges();
            return Ok(dbcontext.Repotebs.ToList());
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult GetRTest([FromQuery]int id)
        {
            var result = dbcontext.Repotebs.Where(x => x.Id == id).FirstOrDefault();
            return Ok(result);

        }

        [HttpDelete]
        public ActionResult DeleteTest([FromQuery]int id)
        {
            var result = dbcontext.Repotebs.Where(x => x.Id == id).FirstOrDefault();
            if(result != null)
            {
                dbcontext.Repotebs.Remove(result);
                dbcontext.SaveChanges();
                return Ok(dbcontext.Repotebs.ToList());
            }
            else
            {
                return BadRequest("id doesnt exists");
            }
            
        }
        [HttpPut]
        [Route("[action]")]
        public ActionResult PutTest([FromQuery] int id,[FromBody]Repoteb repoteb)
        {
            var result = dbcontext.Repotebs.Where(x => x.Id == id).FirstOrDefault();
            if(result != null)
            {
                result.Nam = repoteb.Nam;
                result.Age=repoteb.Age;
                result.Intrests = repoteb.Intrests;
                result.Discription = repoteb.Discription;
                dbcontext.SaveChanges();
                return Ok(dbcontext.Repotebs.ToList());

            }
            else
            {
                return BadRequest("id doesnt exists");
            }

        }



    }
}
