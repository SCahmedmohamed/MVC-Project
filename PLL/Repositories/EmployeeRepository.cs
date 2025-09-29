using BLL.Interfaces;
using DAL.Data.DBContexts;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly CompanyDbContext _context;

        public EmployeeRepository(CompanyDbContext context)
        {
            _context = context;
        }

        public int Add(Employee employee)
        {
            _context.Employees.Add(employee);
            return _context.SaveChanges();
        }

        public int Delete(Employee employee)
        {
            _context.Employees.Remove(employee);
            return _context.SaveChanges();
        }

        public Employee Get(int id)
        {
            return _context.Employees.Find(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public int Update(Employee employee)
        {
            _context.Employees.Update(employee);
            return _context.SaveChanges();
        }
    }
}
