using MedicineTrackingSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicineTrackingSystem.DataAccess;

namespace MedicineTrackingSystem.Repository
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly AppDBContext context;

        public MedicineRepository(AppDBContext context)
        {
            this.context = context;
        }

        public async Task<(bool IsSuccess, MedicineAttribute Medicine, string ErrorMessage)> CreateMedicineAsync(MedicineAttribute medicine)
        {
            try
            {
                var isMedicineExist = await context.MedicineAttributes.FirstOrDefaultAsync(a => a.MedicineFullName == medicine.MedicineFullName);
                if (isMedicineExist == null)
                {
                    var result = await context.MedicineAttributes.AddAsync(medicine);
                    await context.SaveChangesAsync();
                    return (true, medicine, "");
                }
                else
                    return (false, null, "Record is already exist");
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, MedicineAttribute Medicine, string ErrorMessage)> DeleteMedicineAsync(int id)
        {
            try
            {
                var deletedData = await context.MedicineAttributes.FirstOrDefaultAsync(a => a.Id == id);
                if (deletedData != null)
                {
                    context.MedicineAttributes.Remove(deletedData);
                    await context.SaveChangesAsync();
                    return (true, deletedData, "");
                }
                else
                    return (true, deletedData, "Record is not deleted");
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, MedicineAttribute Medicine, string ErrorMessage)> UpdateMedicineAsync(MedicineAttribute medicine)
        {
            try
            {
                if (medicine != null)
                {
                    context.MedicineAttributes.Update(medicine);
                    await context.SaveChangesAsync();
                    return (true, medicine, "");
                }
                else
                    return (false, null, "Record is not updated");
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<MedicineAttribute> Medicines, string ErrorMessage)> GetAllMedicinesAsync()
        {
            try
            {
                var medicineList = await context.MedicineAttributes.ToListAsync();
                if (medicineList != null && medicineList.Any())
                    return (true, medicineList, "");
                else
                    return (false, null, "Records are not available");
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, MedicineAttribute Medicine, string ErrorMessage)> GetMedicineByIdAsync(int id)
        {
            try
            {
                var medicine = await context.MedicineAttributes.FirstOrDefaultAsync(a => a.Id == id);
                if (medicine != null)
                    return (true, medicine, "");
                else
                    return (false, null, "Record is not available");
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message);
            }
        }
    }
}
