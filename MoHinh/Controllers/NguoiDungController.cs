﻿using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NguoiDungController : ControllerBase
    {
        private readonly INguoiDungService _nguoiDungService;

        public NguoiDungController(INguoiDungService nguoiDungService)
        {
            _nguoiDungService = nguoiDungService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNguoiDung()
        {
            var nguoiDungList = await _nguoiDungService.GetAllNguoiDungAsync();
            return Ok(nguoiDungList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNguoiDungById(int id)
        {
            var nguoiDung = await _nguoiDungService.GetNguoiDungByIdAsync(id);
            if (nguoiDung == null)
            {
                return NotFound();
            }
            return Ok(nguoiDung);
        }

        [HttpPost]
        public async Task<IActionResult> AddNguoiDung([FromBody] NguoiDungDTO nguoiDungDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _nguoiDungService.AddNguoiDungAsync(nguoiDungDto);
            return CreatedAtAction(nameof(GetNguoiDungById), new { id = nguoiDungDto.NguoiDungID }, nguoiDungDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNguoiDung(int id, [FromBody] NguoiDungDTO nguoiDungDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _nguoiDungService.UpdateNguoiDungAsync(id, nguoiDungDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNguoiDung(int id)
        {
            await _nguoiDungService.DeleteNguoiDungAsync(id);
            return NoContent();
        }
    }
}
