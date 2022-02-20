using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Entities;
using Aspose.Pdf;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RSWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class SignerController : ControllerBase
    {
        //private SignerBL _signerBL;
        //public SignerController(SignerBL sbl)
        //{
        //    _signerBL = sbl;
        //}
        //// GET: api/<SignerController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<SignerController>/5
        //[HttpGet("{id}")]
        //public Page loadPDF(int FTSid)
        //{
        //    return "value";
        //}

        // POST api/<SignerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SignerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SignerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
