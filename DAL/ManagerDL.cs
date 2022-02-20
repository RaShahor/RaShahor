using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
//using Microsoft.Data.SqlClient;

//using Microsoft.Extensions.Logging;
namespace DAL
{
    public class ManagerDL : IManagerDL
    {
        SignContext myContext;
       
        ILogger logger;


        public ManagerDL( SignContext myC)
        { 
            myContext = myC;
           
            this.logger = logger;
        }

        public async Task DeleteformsToSigner_rangeAsync(int id, DateTime date)
        {
           Task<List<FormSigner>>removings = myContext.FormSigners.Where(x => x.Date < date).ToListAsync();

            foreach (FormSigner item in removings.Result)
            {
                int formId = (int)item.FormTosigner.FormId;
                myContext.FormSigners
                    .RemoveRange(myContext.FormSigners
                    .Include(FS => FS.FormTosigner)
                    .ThenInclude(FTS => FTS.FormId == formId));
        }}

        public void DeleteformsToUser_range(int id, DateTime date)
        {
            myContext.FormToSigners.RemoveRange();
        //TODO  
        //have to think what to do with range - add date to db or stng else!
        }

        public async void DeleteSigner(int id)
        {
            Signer s = (Signer)myContext.Signers.Where(x => x.Id == id);
            myContext.Signers.Remove(s);
            myContext.SaveChangesAsync();
        }

        public void DeleteUser(int id)
        {
            User u = (User)myContext.Users.Where(x => x.Id == id);
            myContext.Users.Remove(u);
            myContext.SaveChangesAsync();
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

        void IManagerDL.DeleteformsToSigner_rangeAsync(int id, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
                                                          
