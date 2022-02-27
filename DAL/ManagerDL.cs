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

        public async Task DeleteformsToUser_range(int id, DateTime date)
        {
            myContext.FormToSigners.RemoveRange();
        //TODO  
        //have to think what to do with range - add date to db or stng else!
        }
        
        public async Task DeleteSigner(int id)
        {
            Signer s = await myContext.Signers.FindAsync(id);
            //Error = Cannot evaluate expression because a thread is stopped at a point where garbage collection is impossible, possibly because the code is optimized.
            if(s!=null)
            myContext.Signers.Remove(s);
            myContext.SaveChanges();
        }

        public async Task DeleteUser(int id)
        {
            User u = (User)myContext.Users.Where(x => x.Id == id);
            myContext.Users.Remove(u);
            myContext.SaveChangesAsync();
        }
        //Error://(Convert(f, FormUser).UserId == __id_0)' is invalid inside an 'Include' operation, since it does not represent a property access: 
        //'t => t.MyProperty'. To target navigations declared on derived types, use casting ('t => ((Derived)t).MyProperty')
        public async Task<List<FormTemplate>> getAllFormsTemplatesByUser(int id)
        {


            var FT = await myContext.FormTemplates
                    .Where(x => x.FormUserId==id)
                    //.ThenInclude(f => ((FormUser)f).UserId == id)
                    .ToListAsync();

            return FT;

        }

        public async Task<List<FormToSigner>> getAllFormsToSignerByUserIdAndSignerId(int idu, int ids)
        {

             List < FormToSigner > UTS =await myContext.FormToSigners
                    .Where(x => (int)x.Form.UserId==idu&& (int)x.SignerId==ids)
                    
                    .ToListAsync();
            return UTS;

        }
        //Error://(f.UserId == __us_0)' is invalid inside an 'Include' operation, since it does not represent a property access:
        // 't => t.MyProperty'. To target navigations declared on derived types, use casting ('t => ((Derived)t).MyProperty')
        public async Task<List<FormToSigner>> getAllFormsToUserBySigner(int us)
        {

            List<FormToSigner> FTS =await myContext.FormToSigners
                    .Where(x => (x).Form.UserId == us)
                    .ToListAsync();
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

        public async Task<Signer> newSigner(Signer signer, int Uid = 1)
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

         async Task IManagerDL.DeleteformsToSigner_rangeAsync(int id, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
                                                          
