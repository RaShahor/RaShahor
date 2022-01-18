using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
//using Microsoft.Data.SqlClient;

//using Microsoft.Extensions.Logging;
namespace DAL
{
    public class ManagerDL : IManagerDL
    {
        SignContext myContext;
        IManagerDL _manager;
        //ILogger logger;


        public ManagerDL(IManagerDL manager, SignContext myC)
        {
            _manager = manager;
            myContext = myC;
            //this.logger = logger;
        }

        public async Task<List<FormTemplate>> getAllFormsTemplatesByUser(int id)
        {


            var FT = await myContext.FormTemplates
                    .Include(x => x.FormUsers)
                    .ThenInclude(f => f.UserId == id)
                    .ToListAsync();

            return FT;

        }

        public async Task<List<FormToSigner>> getAllFormsToSignerByUserIdAndSignerId(int idu, int ids)
        {

            var UTS = myContext.FormToSigners
                    .Include(x => x.Form)
                    .ThenInclude(f => f.UserId == idu)
                    .Include(x => x.SignerId == ids)
                    .ToList();
            return UTS;

        }

        public async Task<List<FormToSigner>> getAllFormsToUserBySigner(int us)
        {

            var FTS = myContext.FormToSigners
                    .Include(x => x.Form)
                    .ThenInclude(f => f.UserId == us)
                    .ToList();
            return FTS;

        }

        public async Task<List<Signer>> getAllSignersByUser(int id)
        {

            var SIGNERS = myContext.Signers
                        .Where(x => x.UserId == id)
                        .ToList();
            return SIGNERS;

        }

        public async Task<FormToSigner>  newFTS(FormToSigner fts)
        {
             
            myContext.FormToSigners.AddAsync(fts);
            FormToSigner addedSuccessfully = await myContext.FormToSigners.Where(x => x.FormId == fts.Form.UserId).LastAsync();
            return addedSuccessfully;
        }

        public async Task<Signer> newSigner(Signer signer, int Uid = 0)
        {
            //SignContext con = new SignContext();
            User u =  (User)myContext.Users.Where(u => u.Id == Uid);
           // myContext.Users.איך מוסיפים לתוך מסד הנתונים?
            u.Signers.Add(signer);//
            await myContext.Signers.AddAsync(signer);
            await myContext.SaveChangesAsync();
            return signer;
        }

        public async void updateStatusOfFTS(int id1, FormToSigner fts)
        {
            //await myContext.FormToSigners.UpdateAsync((FormToSigner)myContext.FormToSigners.Where(x=>x.Id==id2)).;
            myContext.FormToSigners.Update(fts);
            await myContext.SaveChangesAsync();
        }


    }
}
                                                          
