using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface INguoiDungService
    {
        Task<IEnumerable<NguoiDungDTO>> GetAllNguoiDungAsync();
        Task<NguoiDungDTO> GetNguoiDungByIdAsync(int id);
        Task AddNguoiDungAsync(NguoiDungDTO nguoiDungDto);
        Task UpdateNguoiDungAsync(int id, NguoiDungDTO nguoiDungDto);
        Task DeleteNguoiDungAsync(int id);
    }
}
