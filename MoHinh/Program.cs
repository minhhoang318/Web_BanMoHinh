﻿using BLL;
using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Các dịch vụ khác như DbContext, Swagger, v.v.
builder.Services.AddDbContext<BanMoHinh>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Đăng ký các Repository và Service thông qua Extension Method
builder.Services.AddScoped<ICTDonHangService, CTDonHangService>();
builder.Services.AddScoped<ICTDonHangRepository, CTDonHangRepository>(); 

builder.Services.AddScoped<ICTDonNhapService, CTDonNhapService>();
builder.Services.AddScoped<ICTDonNhapRepository, CTDonNhapRepository>();

builder.Services.AddScoped<IDonHangService, DonHangService>();
builder.Services.AddScoped<IDonHangRepository, DonHangRepository>();

builder.Services.AddScoped<IDonNhapService, DonNhapService>();
builder.Services.AddScoped<IDonNhapRepository, DonNhapRepository>();

builder.Services.AddScoped<IKhachHangService, KhachHangService>();
builder.Services.AddScoped<IKhachHangRepository, KhachHangRepository>();

builder.Services.AddScoped<IKhoService, KhoService>();
builder.Services.AddScoped<IKhoRepository, KhoRepository>();

builder.Services.AddScoped<ILoaiService, LoaiService>();
builder.Services.AddScoped<ILoaiRepository, LoaiRepository>();

builder.Services.AddScoped<INCCService, NCCService>();
builder.Services.AddScoped<INCCRepository, NCCRepository>();

builder.Services.AddScoped<INguoiDungService, NguoiDungService>();
builder.Services.AddScoped<INguoiDungRepository, NguoiDungRepository>();

builder.Services.AddScoped<ISanPhamService, SanPhamService>();
builder.Services.AddScoped<ISanPhamRepository, SanPhamRepository>();

builder.Services.AddScoped<IThanhToanService, ThanhToanService>();
builder.Services.AddScoped<IThanhToanRepository, ThanhToanRepository>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Add services to the container
builder.Services.AddControllers();


// Swagger/OpenAPI
builder.Services.AddSwaggerGen();

// Logging configuration
builder.Logging.AddConsole();

var app = builder.Build();

// Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
