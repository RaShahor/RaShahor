using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
//using Microsoft.Data.SqlClient;
//using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ManagerDL:IManagerDL
    {
        SignContext myContext;
        IManagerDL _manager;

        

        public ManagerDL(IManagerDL manager, SignContext myC)
        {
            _manager = manager;
            myContext = myC;
        }

        public async Task<List<FormTemplate>> getAllFormsTemplatesByUser(int id)
        {
            using (var con = new SignContext())
            {
                var FT =await con.FormTemplates
                        .Include(x=>x.FormUsers)
                        .ThenInclude(f => f.UserId == id)
                        .ToListAsync();
                return FT;
            }
        }

        public async Task<List<FormToSigner>> getAllFormsToSignerByUserIdAndSignerId(int idu, int ids)
        {
            using (var con = new SignContext())
            {
                var UTS = con.FormToSigners
                        .Include(x => x.Form)
                        .ThenInclude(f => f.UserId == idu)
                        .Include(x=>x.SignerId==ids) 
                        .ToList();
                return UTS;
            }
        }

        public  async Task <List<FormToSigner>> getAllFormsToUserBySigner (int us)                 
        {
            using(var con=new SignContext()) {
                var FTS =  con.FormToSigners
                        .Include(x => x.Form)
                        .ThenInclude(f => f.UserId == us)
                        .ToList() ;
                    return  FTS;
            }
            
        }

        public async Task<List<Signer>> getAllSignersByUser(int id)
        {
            using (var con = (System.IDisposable)new SignContext())
            {
                var SIGNERS = con.Signers
                        .Where(x=>x.UserId==id)
                        .ToList();
                return SIGNERS;
            }
        }

        public Task newSigner(Signer signer)
        {
            throw new NotImplementedException();
        }
    }
}
                                                          
