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
        private readonly IPropertyService _propertyService;

        public PropertiesController(IPropertyService propertyService)
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
            if (property.Type == PropertyType.Dropdown)
            {
                var validOptions = (dropdownOptions ?? new List<string>())
                    .Select(o => o?.Trim())
                    .Where(o => !string.IsNullOrEmpty(o))
                    .ToList();

                if (!validOptions.Any())
                {
                  
                    ModelState.AddModelError("DropdownOptions", "Please provide at least one dropdown option.");
                }
                else if (validOptions.Count > 10)
                {
                    ModelState.AddModelError("DropdownOptions", "You can provide a maximum of 10 dropdown options.");
                }
                else
                {
                   
                    property.DropdownOptions = validOptions
                        .Select(o => new DropdownValue { Value = o })
                        .ToList();
                }
            }
            else
            {
                property.DropdownOptions = new List<DropdownValue>();
            }
            if (ModelState.IsValid)
            {
                await _propertyService.AddPropertyAsync(property, dropdownOptions);
                return RedirectToAction(nameof(Index));
            }

            return View(property);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var property = await _propertyService.GetByIdAsync(id);
            if (property == null)
                return NotFound();
            return View(property);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Property property, List<string> dropdownOptions)
        {
            if (ModelState.IsValid)
            {
                await _propertyService.UpdatePropertyAsync(property, dropdownOptions);
                return RedirectToAction(nameof(Index));
            }
            return View(property);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _propertyService.DeletePropertyAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
