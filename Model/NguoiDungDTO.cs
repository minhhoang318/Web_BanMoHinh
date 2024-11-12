using Microsoft.EntityFrameworkCore;
using System;

namespace DTO
{
    public class NguoiDungDTO
    {
        public int NguoiDungID { get; set; }             // Primary Key
        public string? HoTen { get; set; }                // Full Name
        public string? Taikhoan { get; set; }             // Username
        public string? MatKhau { get; set; }              // Password
        public string? Quyen { get; set; }                 // Role
    }
}
