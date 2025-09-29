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
    public class DepartmentRepository : IDepartmentRepository 
    {
        private readonly CompanyDbContext _dbContext;
        public DepartmentRepository(CompanyDbContext companyDbContext)
        {
            _dbContext =  companyDbContext;
        }
        public IEnumerable<Department> GetAll()
        {
            //using CompanyDbContext dbContext = new CompanyDbContext();
            return _dbContext.Departments.ToList();
        }
        public Department? Get(int id)
        {
            //using CompanyDbContext dbContext = new CompanyDbContext();
            return _dbContext.Departments.Find(id); // Will Find in Primary Key
        }

        public int Add(Department department)
        {
            //using CompanyDbContext dbContext = new CompanyDbContext();
            _dbContext.Departments.Add(department);
            return _dbContext.SaveChanges();

        }
        public int Update(Department department)
        {
            //using CompanyDbContext dbContext = new CompanyDbContext();
            _dbContext.Departments.Update(department);
            return _dbContext.SaveChanges();
        }

        public int Delete(Department department)
        {
            //using CompanyDbContext dbContext = new CompanyDbContext();
            
            _dbContext.Departments.Remove(department);
            return _dbContext.SaveChanges();
        }


    }
}
