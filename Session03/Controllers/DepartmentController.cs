using BLL.Interfaces;
using BLL.Repositories;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using PL.DTOs;

namespace PL.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {

            var Res = _departmentRepository.GetAll();
            return View(Res);
        }
        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateDepartmentDTO model)
        {
            if(ModelState.IsValid)
            {
                var department = new Department()
                {
                    Code = model.Code,
                    Name = model.Name,
                    CreatedDate = model.CreatedDate
                };
                var Count = _departmentRepository.Add(department);
                if(Count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        } 

    }
}
