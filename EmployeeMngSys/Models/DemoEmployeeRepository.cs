using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMngSys.Models
{
    public class DemoEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employee;
        public DemoEmployeeRepository()
        {
            _employee = new List<Employee>()
        {
            new Employee() { Id = 1, Name = "Dolon Banik", Department = DeptName.Web_Developer, Email = "doloncse@gamil.com", Phone_No = 01789000000 },
            new Employee() { Id = 2, Name = "abc", Department = DeptName.Systems_Analyst, Email = "abc@gamil.com", Phone_No = 0130000000 },
            new Employee() { Id = 3, Name = "def", Department = DeptName.HR, Email = "def@gamil.com", Phone_No = 0129000000 },
        };
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employee;
        }
        public Employee GetEmployee(int Id)
        {
            return this._employee.FirstOrDefault(e => e.Id == Id);
        }
        public Employee Add(Employee employee)
        {
            employee.Id = _employee.Max(e => e.Id) + 1;
            _employee.Add(employee);
            return employee;
        }
        public Employee Delete(int id)
        {
            Employee emp = _employee.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                _employee.Remove(emp);
            }
            return emp;
        }
        public Employee Update(Employee employeeUpdates)
        {
            Employee emp = _employee.FirstOrDefault(e => e.Id == employeeUpdates.Id);
            if (emp != null)
            {
                emp.Name = employeeUpdates.Name;
                emp.Email = employeeUpdates.Email;
                emp.Phone_No= employeeUpdates.Phone_No;
                emp.Department = employeeUpdates.Department;
            }
            return emp;
        }
    }
}
