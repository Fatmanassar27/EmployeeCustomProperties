using EmployeeCustomProperties.Models;
using EmployeeCustomProperties.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeCustomProperties.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IPropertyService _propertyService;

        public EmployeesController(IEmployeeService employeeService, IPropertyService propertyService)
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
            await LoadPropertiesAsync();
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

            await LoadPropertiesAsync();
            return View(employee);
        }

        private async Task LoadPropertiesAsync()
        {
            var properties = await _propertyService.GetAllPropertiesWithDropdownsAsync();
            ViewBag.Properties = properties;
        }

        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
                return NotFound();

            await LoadPropertiesAsync();
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee, Dictionary<int, string> propertyValues)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.UpdateEmployeeAsync(employee, propertyValues);
                return RedirectToAction(nameof(Index));
            }

            await LoadPropertiesAsync();
            return View(employee);
        }

    }
}
