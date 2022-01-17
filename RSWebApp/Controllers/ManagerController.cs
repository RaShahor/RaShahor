using DAL;
using BL;
using DTO;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using AutoMapper;

namespace RSWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class ManagerController : ControllerBase
    { 
        IManagerDL MDL;
        IManagerBL MBL;
        IMapper mapper1;
        public ManagerController(IManagerDL managerDL,IManagerBL managerBL,IMapper mapper)
        {
            MDL = managerDL;
            MBL = managerBL;
            mapper1 = mapper;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}/FormToSigner")]
        public async Task<List<FormToSigner>> Get(int id)
        {

            return await MDL.getAllFormsToUserBySigner(id);
        }
        [HttpGet("{id}/FormTemplate")]
        public async Task<List<FormTemplate>> GetTmp(int id)
        {

            return await MDL.getAllFormsTemplatesByUser(id);
        }

        [HttpGet("{idu}/{ids}/FormTS")]
        public async Task<List<FormToSigner>> GetTmp(int idu, int ids)
        {

            return await MDL.getAllFormsToSignerByUserIdAndSignerId(idu, ids);
        }
        [HttpGet("{id}/Signer")]
        public async Task<List<Signer>> GetSigners(int id)
        {

            return await MDL.getAllSignersByUser(id);
        }
        [HttpPost]
        public async Task PostNewSigner([FromBody] SignerDTO signerDTO)
        {
            await MBL.NewSigner(signerDTO);
        }

        //PUT api/<SecretaryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SecretaryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
