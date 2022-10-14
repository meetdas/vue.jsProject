using fitnessManagementSystem.App.Data;
using fitnessManagementSystem.App.Models;
using fitnessManagementSystem.App.Models.Dtos;
using fitnessManagementSystem.Services.IServices;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessManagementSystem.Services.Services
{
    public class BranchService : IBranchService
    {
        private readonly ApplicationDbContext _context;
        public BranchService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Add(BranchDto model)
        {
            if (model != null)
            {
                var newModel = new Branch();
                newModel.Name = model.Name;
                newModel.TenantId = 1;
                newModel.CreatedDate= DateTime.Now;
                await _context.Branches.AddAsync(newModel);
                await _context.SaveChangesAsync();
            }
            return "Save Successfully";
        }

        public async Task<string> Delete(int id,Branch model)
        {
           if(id!=0 && model != null && id==model.Id)
            {
                var existingModel=await _context.Branches.FirstOrDefaultAsync(x => x.Id==id);
                 _context.Branches.Remove(existingModel);
                await _context.SaveChangesAsync();
                return "Delete Successfull";
            }
            return "Not Found";
        }

        public async Task<Branch> Details(int id)
        {
            var existingItem = await _context.Branches.FirstOrDefaultAsync(c => c.Id == id);
            if (existingItem != null)
                return existingItem;
            return null;
        }

        public async Task<List<Branch>> Search()
        {
            var data =await _context.Branches.ToListAsync();
            return data;
        }
   
        public async Task<String> Update(Branch model)
        {
             _context.Branches.Update(model);
           await _context.SaveChangesAsync();
            return "Update successfull";
        }

     
    }
}
