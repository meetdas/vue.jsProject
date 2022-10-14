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
        public async Task<IActionResult> Index()
        {
            var data =await _service.Search();
            return View(data);
        }

        [HttpGet]
        public  IActionResult Add() 
        { 
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(BranchDto model)
        {
            var result = string.Empty;
            if (ModelState.IsValid)
            {
                result  = await _service.Add(model);
                return RedirectToAction(nameof(Index));
            }      
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            if (id == 0)
                return NotFound();
            var model = await _service.Details(id);
            if(model == null)
                return NotFound();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult>Update(Branch model)
        {
            var msg = string.Empty;
            if (model != null)
            {
             msg=  await _service.Update(model);
             ViewBag.msg = msg;
                return RedirectToAction(nameof(Index));
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
                return View(model);
            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult>Delete(int id, Branch model)
        {
            var msg= string.Empty;
            msg= await _service.Delete(id, model);
            if(msg != string.Empty)
            {
            ViewBag.msg=msg;
            return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
       
    }
}
