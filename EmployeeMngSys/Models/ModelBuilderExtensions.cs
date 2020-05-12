using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMngSys.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Dolon Banik",
                    Email = "dbt@gmail.com",
                    Phone_No = 01700000000,
                    Department = DeptName.Web_Developer
                },
                new Employee
                {
                    Id = 2,
                    Name = "Tanni Banik",
                    Email = "tanni@gmail.com",
                    Phone_No = 01700000000,
                    Department = DeptName.Project_manager
                }
                );
        }
    }
}
