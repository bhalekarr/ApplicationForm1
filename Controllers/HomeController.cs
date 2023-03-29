using Microsoft.AspNetCore.Mvc;
using RahulApp.Models;
using System.Diagnostics;

namespace RahulApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployee _employee;

        public HomeController(ILogger<HomeController> logger, IEmployee employee)
        {
            _logger = logger;
            _employee = employee;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Create(AddEmpViewModel model)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    Employee employee = new Employee
                    {
                        Name = model.Name,
                        Age = model.Age,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        Gender = model.Gender,
                        Country = model.Country,
                        State = model.State
                        //Photo = model.Photo,
                    };
                    _employee.Add(employee);

                    return RedirectToAction("List");

                }
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            return View();
        }

        public IActionResult List()
        {
            var model =  _employee.GetAllEmployee();
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee emp = _employee.GetEmployee(id);
            EditEmployeeViewModel model = new EditEmployeeViewModel
            {
                EmployeeId = emp.Id,
                Name = emp.Name,
                Email = emp.Email,
                PhoneNumber = emp.PhoneNumber,
                Age = emp.Age,
                Gender = emp.Gender,
                State = emp.State,
                Country = emp.Country,
                Photo = emp.Photo
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee emp = _employee.GetEmployee(model.EmployeeId);
                emp.Name = model.Name;
                emp.Email = model.Email;
                emp.PhoneNumber = model.PhoneNumber;
                emp.Age = model.Age;
                emp.Gender = model.Gender;
                emp.State = model.State;
                emp.Country = model.Country;
                emp.Photo = model.Photo;
                Employee update = _employee.Update(emp);
                return RedirectToAction(nameof(List));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id) { 
        Employee employee = _employee.GetEmployee(id);
            if (employee == null)
            {
                return NotFound("Employee not found");
            }    
            return View(employee);
        }

        [HttpPost]
        public IActionResult Delete(int id, string delete)
        {
            try
            {
                Employee employee = _employee.GetEmployee(id);
                if (employee != null)
                {
                    _employee.Delete(id);
                }
                return RedirectToAction(nameof(List));
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}