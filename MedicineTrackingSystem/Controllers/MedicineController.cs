using MedicineTrackingSystem.Models;
using MedicineTrackingSystem.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MedicineTrackingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineRepository medicineRepository;

        public MedicineController(IMedicineRepository medicineRepository)
        {
            this.medicineRepository = medicineRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMedicinesAsync()
        {
            try
            {
                var result = await medicineRepository.GetAllMedicinesAsync();
                if (result.IsSuccess)
                    return Ok(result.Medicines);
                return NotFound(result.ErrorMessage);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicineByIdAsync(int id)
        {
            try
            {
                var result = await medicineRepository.GetMedicineByIdAsync(id);
                if (result.IsSuccess)
                    return Ok(result.Medicine);
                return NotFound(result.ErrorMessage);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateMedicineAsync(MedicineAttribute medicineAttributes)
        {
            try
            {
                var result = await medicineRepository.CreateMedicineAsync(medicineAttributes);
                if (result.IsSuccess)
                    return Ok(result.Medicine);
                return NotFound(result.ErrorMessage);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedicineAsync(int id, [FromBody] MedicineAttribute medicineAttributes)
        {
            try
            {
                var result = await medicineRepository.UpdateMedicineAsync(medicineAttributes);
                if (result.IsSuccess)
                    return Ok(result.Medicine);
                return NotFound(result.ErrorMessage);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicineAsync(int id)
        {
            try
            {
                var result = await medicineRepository.DeleteMedicineAsync(id);
                if (result.IsSuccess)
                    return Ok(result.Medicine);
                return NotFound(result.ErrorMessage);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
