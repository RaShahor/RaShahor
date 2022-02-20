using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Aspose.Pdf;

namespace DAL
{
    public class AIDL:IAIDL
    {
        public Task<List<Sign>> GetAllSignsFromAIModel(Page myPdf)
        {
            //myPdf.AddImage();
            throw new NotImplementedException();
        }
    }
}
