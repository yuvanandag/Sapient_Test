using MedicineTrackingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineTrackingSystem.Repository
{
    public interface IMedicineRepository
    {
        Task<(bool IsSuccess, MedicineAttribute Medicine, string ErrorMessage)> CreateMedicineAsync(MedicineAttribute medicine);
        Task<(bool IsSuccess, IEnumerable<MedicineAttribute> Medicines, string ErrorMessage)> GetAllMedicinesAsync();
        Task<(bool IsSuccess, MedicineAttribute Medicine, string ErrorMessage)> GetMedicineByIdAsync(int id);
        Task<(bool IsSuccess, MedicineAttribute Medicine, string ErrorMessage)> DeleteMedicineAsync(int id);
        Task<(bool IsSuccess, MedicineAttribute Medicine, string ErrorMessage)> UpdateMedicineAsync(MedicineAttribute medicine);
    }
}
