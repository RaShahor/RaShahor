using System.Threading.Tasks;
using DTO;
using Entities;
//using DAL;
using System;

namespace BL

{
    public interface IManagerBL
    {
        Task <Signer>NewSigner(SignerDTO signerDTO,int UId);
        Task<FormToSigner> newFTS(FormUser form, int sId ,int cls = 1, int status = 1, int order = 1);
        Task updateStatusOfFTS(int id, FormToSigner fts);
        void DeleteSigner(int id);
        void DeleteformsToSigner_range(int id, DateTime date);
        void DeleteUser(int id);
        void DeleteformsToUser_range(int id, DateTime date);
    }
}