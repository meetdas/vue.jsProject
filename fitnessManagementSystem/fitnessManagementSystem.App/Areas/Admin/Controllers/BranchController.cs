using fitnessManagementSystem.App.Models;
using fitnessManagementSystem.App.Models.Dtos;
using fitnessManagementSystem.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace fitnessManagementSystem.App.Areas.Customer.Controllers
{
    [Area("Admin")]
    public class BranchController : Controller
    {
        private readonly IBranchService _service;
        public BranchController(IBranchService service)
        {
            _service = service;
        }

        [HttpGet]
        public  IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data =await _service.Search();
            return Json(AppConstants.Success(data));
        }

        [HttpGet]
        public  IActionResult Add() 
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BranchDto model)
        {
            var result = string.Empty;
            if (ModelState.IsValid)
            {
                result  = await _service.Add(model);
                Json(AppConstants.SaveSuccess());
            }
  
            return Json(AppConstants.Error());
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            if (id == 0)
                return NotFound();
            var model = await _service.Details(id);
            if(model == null)
                return NotFound();
            return Json(AppConstants.Success(model));
        }

        [HttpPost]
        public async Task<IActionResult>Update(Branch model)
        {
            var msg = string.Empty;
            if (model != null)
            {
             msg=  await _service.Update(model);

                return Json(AppConstants.UpdateSuccess(model, msg));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult>Details(int id)
        {
            if (id == 0)
                return NotFound();
            var model = await _service.Details(id);
            if (model == null)
                return NotFound();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return NotFound();
            var model= await _service.Details(id);
            if(model!=null)
                return Json(AppConstants.Success(model));
            return Json(AppConstants.Error(new { }, AppConstants.DataNotFoundMessage));
        }


        [HttpPost]
        public async Task<IActionResult>Delete(int id, Branch model)
        {
            var msg= string.Empty;
            msg= await _service.Delete(id, model);
            if(msg != string.Empty)
            {
                return Json(AppConstants.DeleteSuccess(model, msg));
            }
            return Json(AppConstants.Error(model, AppConstants.DataNotFoundMessage));
        }
       
    }
}
