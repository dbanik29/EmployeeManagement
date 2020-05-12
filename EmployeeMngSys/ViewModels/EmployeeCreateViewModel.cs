using EmployeeMngSys.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeMngSys.ViewModels
{
    public class EmployeeCreateViewModel
    {
        [Required, MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        public int Phone_No { get; set; }
        [Required]
        public DeptName? Department { get; set; } //Department type in enum
        public IFormFile Photo { get; set; }
    }
}
