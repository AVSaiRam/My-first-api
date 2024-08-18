using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32.SafeHandles;
using System.Collections.Generic;
using WebApi1.Models;

namespace WebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        [HttpGet()]
        public ActionResult GetTest()
        {
            
            return Ok(dbcontext.Repotebs.ToList());
        }

        [HttpPost]
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
    }
}
