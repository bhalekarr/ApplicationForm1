using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RahulApp.Data;
using RahulApp.Models;
using System.Diagnostics;

namespace RahulApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployee _employee;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, IEmployee employee, ApplicationDbContext context)
        {
            _logger = logger;
            _employee = employee;
            _context = context;
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

        #region notworking
        //not working
        //public JsonResult GetState(int CountryId)
        //{
        //    List<State> stateList = new List<State>();
        //    stateList = (from state in _context.States
        //              where state.CountryId == CountryId
        //              orderby state.Name
        //                 select state).ToList();
        //    ViewBag.StateList = stateList;

        //    stateList.Insert(0, new State { Id = 0, Name = "Select State" });

        //    return Json(new SelectList(stateList, "Id", "Name"));
        //}

        //working
        //[HttpGet]
        //public IActionResult Create( )
        //{
        //    List<Country> countryList = new List<Country>();

        //    countryList = (from country in _context.Countries
        //                   orderby country.Name
        //                  select country).ToList();
        //    ViewBag.CountryList = countryList;

        //    countryList.Insert(0, new Country { Id = 0, Name = "Select Country" });

        //    return View();
        //}


        #endregion


        #region country, state cascading
        public JsonResult GetCountry()
        {
            var countries = _context.Countries.OrderBy(x=>x.Name).ToList();
            return new JsonResult(countries);
        }

        public JsonResult GetState(int CountryId)
        {
            var states = _context.States.Where(x=>x.Country.Id == CountryId).OrderBy(y => y.Name).ToList();
            return new JsonResult(states);
        }
        #endregion

        public IActionResult Create(AddEmpViewModel model)
        {
            var country = _context.Countries.Find(model.CountryId);
            var state = _context.States.Find(model.StateId);
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
                        Country = country.Name,
                        State = state.Name,
                        Photo = model.Photo,
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
            var country = _context.Countries.Find(model.CountryId);
            var state = _context.States.Find(model.StateId);
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