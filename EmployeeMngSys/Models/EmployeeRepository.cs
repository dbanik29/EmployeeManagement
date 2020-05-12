using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMngSys.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _dbContext.Employees;
        }
        public Employee GetEmployee(int Id)
        {
            return _dbContext.Employees.Find(Id);
        }
        public Employee Add(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
            return employee;
        }
        public Employee Delete(int id)
        {
            Employee emp = _dbContext.Employees.Find(id);
            if(emp != null)
            {
                _dbContext.Employees.Remove(emp);
                _dbContext.SaveChanges();
            }
            return emp;
        }
        public Employee Update(Employee employeeUpdates)
        {
            var upEmp = _dbContext.Employees.Attach(employeeUpdates);
            upEmp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
            return employeeUpdates;
        }
    }
}
