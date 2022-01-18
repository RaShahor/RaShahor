using System.Threading.Tasks;
using DTO;
using Entities;
using DAL;
namespace BL

{
    public interface IManagerBL
    {
        Task <Signer>NewSigner(SignerDTO signerDTO,int UId);
        Task<FormToSigner> newFTS(FormUser form, int sId ,int cls = 1, int status = 1, int order = 1);
        Task updateStatusOfFTS(int id, FormToSigner fts);
    }
}