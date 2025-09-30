using BLL.Repositories;
using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using BLL.Interfaces;
using PL.DTOs;
namespace PL.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IActionResult Index()
        {
            var Emp = _employeeRepository.GetAll();
            return View(Emp);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateEmployeeDTO model)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee()
                {
                    Code = model.Code,
                    Name = model.Name,
                    Address = model.Address,
                    Salary = model.Salary
                };
                var Count = _employeeRepository.Add(employee);
                if (Count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int? Id)
        {
            if (Id is null) return BadRequest("Invaild Id");
            var employee = _employeeRepository.Get(Id.Value);
            if (employee is null) return NotFound($"Employee With Id : {Id} Is Not Found !");
            return View(employee);
        }

        [HttpGet]
        public IActionResult Update(int? Id)
        {
            if (Id is null) return BadRequest("Invaild Id");
            var employee = _employeeRepository.Get(Id.Value);
            CreateEmployeeDTO model = new CreateEmployeeDTO()
            {
                Code = employee.Code,
                Name = employee.Name,
                Address = employee.Address,
                Salary = employee.Salary
            };
            if (model is null) return NotFound($"Employee With Id : {Id} Is Not Found !");
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(int Id ,Employee model)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee()
                {
                    Id = Id,
                    Code = model.Code,
                    Name = model.Name,
                    Address = model.Address,
                    Salary = model.Salary
                };
                var Count = _employeeRepository.Update(employee);
                if (Count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        [HttpGet]

        public IActionResult Delete(int? Id)
        {
            if (Id is null) return BadRequest("Invaild Id");
            var employee = _employeeRepository.Get(Id.Value);
            CreateEmployeeDTO model = new CreateEmployeeDTO()
            {
                Code = employee.Code,
                Name = employee.Name,
                Address = employee.Address,
                Salary = employee.Salary
            };
            if (model is null) return NotFound($"Employee With Id : {Id} Is Not Found !");
            return View(model);
        }

        [HttpPost]

        public IActionResult Delete(int Id, Employee model)
        {
            var employee = new Employee()
            {
                Id = Id,
                Code = model.Code,
                Name = model.Name,
                Address = model.Address,
                Salary = model.Salary
            };
            var Count = _employeeRepository.Delete(employee);
            if (Count > 0)
            {
                return RedirectToAction("Index");
            }
            return View(model);


        }
    }
}
