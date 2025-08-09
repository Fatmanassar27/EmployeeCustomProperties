using EmployeeCustomProperties.Models;
using EmployeeCustomProperties.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCustomProperties.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeService _employeeService;
        private readonly PropertyService _propertyService;

        public EmployeesController(EmployeeService employeeService, PropertyService propertyService)
        {
            _employeeService = employeeService;
            _propertyService = propertyService;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.GetAllEmployeesWithPropertiesAsync();
            return View(employees);
        }

        public async Task<IActionResult> Create()
        {
            var properties = await _propertyService.GetAllPropertiesWithDropdownsAsync();
            ViewBag.Properties = properties;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee, Dictionary<int, string> propertyValues)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.AddEmployeeAsync(employee, propertyValues);
                return RedirectToAction(nameof(Index));
            }

            var properties = await _propertyService.GetAllPropertiesWithDropdownsAsync();
            ViewBag.Properties = properties;
            return View(employee);
        }

    }
}
