using System;
using EmployeeCustomProperties.Data;
using EmployeeCustomProperties.Models;
using EmployeeCustomProperties.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCustomProperties.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly PropertyService _propertyService;

        public PropertiesController(PropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        public async Task<IActionResult> Index()
        {
            var properties = await _propertyService.GetAllPropertiesWithDropdownsAsync();
            return View(properties);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Property property, List<string> dropdownOptions)
        {
            if (ModelState.IsValid)
            {
                await _propertyService.AddPropertyAsync(property, dropdownOptions);
                return RedirectToAction(nameof(Index));
            }
            return View(property);
        }
    }
}
