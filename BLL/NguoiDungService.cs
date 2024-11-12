using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    public class NguoiDungService : INguoiDungService
    {
        private readonly INguoiDungRepository _nguoiDungRepository;

        public NguoiDungService(INguoiDungRepository nguoiDungRepository)
        {
            _nguoiDungRepository = nguoiDungRepository;
        }

        public async Task<IEnumerable<NguoiDungDTO>> GetAllNguoiDungAsync()
        {
            var nguoiDungList = await _nguoiDungRepository.GetAllAsync();
            return nguoiDungList.Select(nd => new NguoiDungDTO
            {
                NguoiDungID = nd.NguoiDungID,
                HoTen = nd.HoTen,
                Taikhoan = nd.Taikhoan,
                MatKhau = nd.MatKhau,
                Quyen = nd.Quyen
            }).ToList();
        }

        public async Task<NguoiDungDTO> GetNguoiDungByIdAsync(int id)
        {
            var nguoiDung = await _nguoiDungRepository.GetByIdAsync(id);
            if (nguoiDung == null) return null;

            return new NguoiDungDTO
            {
                NguoiDungID = nguoiDung.NguoiDungID,
                HoTen = nguoiDung.HoTen,
                Taikhoan = nguoiDung.Taikhoan,
                MatKhau = nguoiDung.MatKhau,
                Quyen = nguoiDung.Quyen
            };
        }

        public async Task AddNguoiDungAsync(NguoiDungDTO nguoiDungDto)
        {
            var nguoiDung = new NguoiDung
            {
                HoTen = nguoiDungDto.HoTen,
                Taikhoan = nguoiDungDto.Taikhoan,
                MatKhau = nguoiDungDto.MatKhau,
                Quyen = nguoiDungDto.Quyen
            };
            await _nguoiDungRepository.AddAsync(nguoiDung);
            await _nguoiDungRepository.SaveAsync();
        }

        public async Task UpdateNguoiDungAsync(int id, NguoiDungDTO nguoiDungDto)
        {
            var nguoiDung = await _nguoiDungRepository.GetByIdAsync(id);
            if (nguoiDung == null) return;

            nguoiDung.HoTen = nguoiDungDto.HoTen;
            nguoiDung.Taikhoan = nguoiDungDto.Taikhoan;
            nguoiDung.MatKhau = nguoiDungDto.MatKhau;
            nguoiDung.Quyen = nguoiDungDto.Quyen;

            _nguoiDungRepository.Update(nguoiDung);
            await _nguoiDungRepository.SaveAsync();
        }

        public async Task DeleteNguoiDungAsync(int id)
        {
            var nguoiDung = await _nguoiDungRepository.GetByIdAsync(id);
            if (nguoiDung == null) return;

            _nguoiDungRepository.Delete(nguoiDung);
            await _nguoiDungRepository.SaveAsync();
        }
    }
}
