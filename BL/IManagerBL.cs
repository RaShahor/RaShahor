using System.Threading.Tasks;
using DTO;
using Entities;
namespace BL

{
    public interface IManagerBL
    {
        Task <Signer>NewSigner(SignerDTO signerDTO);
    }
}