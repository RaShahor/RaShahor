using System.Threading.Tasks;
using DTO;
namespace BL
{
    public interface IManagerBL
    {
        Task NewSigner(SignerDTO signerDTO);
    }
}