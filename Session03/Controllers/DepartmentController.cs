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
            if (ModelState.IsValid)
            {
                var department = new Department()
                {
                    Code = model.Code,
                    Name = model.Name,
                    CreatedDate = model.CreatedDate
                };
                var Count = _departmentRepository.Add(department);
                if (Count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int? Id)
        {
            if (Id is null) return BadRequest("Invaild Id");
            var department = _departmentRepository.Get(Id.Value);
            if (department is null) return NotFound($"Department With Id : {Id} Is Not Found !");
            return View(department);
        }

        [HttpGet]
        public IActionResult Update(int? Id)
        {
            if (Id is null) return BadRequest("Invaild Id");
            var _department = _departmentRepository.Get(Id.Value);
            if (_department is null) return NotFound($"Department With Id : {Id} Is Not Found !");
            return View(_department);

        }
        [HttpPost]
        public IActionResult Update(Department department)
        {
            if (ModelState.IsValid)
            {
                int vaild = _departmentRepository.Update(department);
                if (vaild > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(department);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {

            if (id is null) return BadRequest("Invaild Id");
            var department = _departmentRepository.Get(id.Value);
            if (department is null) return NotFound($"Department With Id : {id} Is Not Found !");
            return View(department);

        }
        [HttpPost]
        public IActionResult Delete(Department department)
        {
            int vaild = _departmentRepository.Delete(department);
            if (vaild > 0)
            {
                return RedirectToAction("Index");
            }
            return View(department);
        }
    }
}