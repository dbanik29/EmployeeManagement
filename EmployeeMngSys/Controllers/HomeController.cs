using Microsoft.AspNetCore.Mvc;
using EmployeeMngSys.Models;
using EmployeeMngSys.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace EmployeeMngSys.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        // Inject IEmployeeRepository using Constructor Injection
        public HomeController(IEmployeeRepository employeeRepository,
            IHostingEnvironment hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployees();
            return View(model);
        }

        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(id ?? 1),
                PageTitle = "Employee Details"
            };
            return View(homeDetailsViewModel);
        }

        [HttpGet]
        [Authorize]
        public ViewResult Create()
        {
            return View();
        }

        //To handle POST request need another Create action method
        [HttpPost]
        [Authorize]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Photo != null)
                {
                    {
                        string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                        //uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.Photo.FileName);
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                    }
                }
                Employee newEmployee = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Phone_No = model.Phone_No,
                    Department = model.Department,
                    PhotoFile = uniqueFileName
                };
                _employeeRepository.Add(newEmployee);
                return RedirectToAction("details", new { id = newEmployee.Id }); //Redirect the user to the Details Action Method to view the details of new Employee which just created  
            }
            return View();
        }
    }
}
