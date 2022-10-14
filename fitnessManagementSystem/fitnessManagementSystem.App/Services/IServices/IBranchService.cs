using fitnessManagementSystem.App.Models;
using fitnessManagementSystem.App.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessManagementSystem.Services.IServices
{
    public interface IBranchService 
    {
        public Task<string> Add(BranchDto model);
        public Task<string> Update(Branch model);
        public Task<List<Branch>> Search();
        public Task<Branch> Details(int id);
        public Task<string> Delete(int id, Branch model);
    }
}
