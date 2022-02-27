using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL;
using DTO;
using Entities;

namespace BL
{
    public class ManagerBL : IManagerBL

    {
        IManagerDL managerDL;
        IMapper map;
        public ManagerBL(IManagerDL mangerDL, IMapper mapper)
        {
            this.managerDL = managerDL;
            map = mapper;
        }

       

        public Task<Signer> NewSigner(Signer signerDTO,int UId)
        {
            return managerDL.newSigner(signerDTO,UId);
        }
        public async Task<FormToSigner> newFTS(FormUser form, int sId,  int cls = 1, int status = 1, int order = 1)
        {
            FormToSigner fts = new FormToSigner() { SignerId = sId, FormId = form.Id, Class = cls, Status = status, Order = order };
            return await managerDL.newFTS(fts);
        }

        public async Task updateStatusOfFTS(int id, FormToSigner fts)
        {
            fts.Status = id;//update status
            managerDL.updateStatusOfFTS(id, fts);
        }

        public async Task DeleteSigner(int id)
        {
             await managerDL.DeleteSigner(id);
        }

        public async Task DeleteformsToSigner_range(int id, DateTime date)
        {
            managerDL.DeleteformsToSigner_rangeAsync(id,date);
        }

        public async Task DeleteUser(int id)
        {
            managerDL.DeleteUser(id);
        }

        public async Task DeleteformsToUser_range(int id, DateTime date)
        {
            managerDL.DeleteformsToUser_range(id,date);
        }
    }
}


