using Entities;
using DAL;
using Aspose.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BL
{
   public class AIBL : IAIBL
    {
        IAIDL IaiDL;
        public AIBL(IAIDL iai)
        {
            this.IaiDL= iai;
        }

        public Sign AddForm(FormUserDTO formDto, int uId)
        {
            throw new NotImplementedException();
        }

        public Sign AddFT(FormTemplate ft, int uId)
        {
            throw new NotImplementedException();
        }

        public Sign AddSign(Sign sign, int uId)
        {
            throw new NotImplementedException();
        }

        public void deleteSign(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Sign>> GetAllSignsFromAIModel(Page myPdf)
        {
            return IaiDL.GetAllSignsFromAIModel(myPdf);
        }

        //public Task<List<Sign>> GetAllSignsFromAIModel()
        //{
        //    throw new NotImplementedException();
        //}

        public FormTemplate getFT(string name, int id)
        {
            throw new NotImplementedException();
        }

        public object getFTS(string name, int id)
        {
            throw new NotImplementedException();
        }

        public void updateSign(Sign sign, object uId, Sign newSign)
        {
            throw new NotImplementedException();
        }
    }
}
