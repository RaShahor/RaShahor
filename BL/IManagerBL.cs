using System.Threading.Tasks;
using DTO;
using Entities;
//using DAL;
using System;

namespace BL

{
    public interface IManagerBL
    {
        Task <Signer>NewSigner(Signer signerDTO,int UId);
        Task<FormToSigner> newFTS(FormUser form, int sId ,int cls = 1, int status = 1, int order = 1);
        Task updateStatusOfFTS(int id, FormToSigner fts);
        Task DeleteSigner(int id);
        Task DeleteformsToSigner_range(int id, DateTime date);
        Task DeleteUser(int id);
        Task DeleteformsToUser_range(int id, DateTime date);
    }
}