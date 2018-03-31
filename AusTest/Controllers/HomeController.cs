using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AusTest.Service.DTOs;
using AusTest.Service.RequirementsService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AusTest.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IRequirementsService _requirementsService;

        public HomeController(IRequirementsService requirementsService) => _requirementsService = requirementsService;

        [HttpGet]
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var list = _requirementsService.ListByUser(Convert.ToInt32(userId));
            return View(list);
        }

        [HttpPost]
        public IActionResult _save(RequirementDto model)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = _requirementsService.Save(model, Convert.ToInt32(userId));

                if (null == result)
                    return new StatusCodeResult(500);

                return Json(new { Success = true });
            }
            var errors = new List<string>();
            return Json(new { Success = false, Errors = errors });
        }

        [HttpPost]
        public IActionResult _delete(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            _requirementsService.Delete(id, Convert.ToInt32(userId));
            return Json(new { Success = true });
        }

        [HttpPost]
        public IActionResult _item(int id) {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var item = _requirementsService.GetById(id, Convert.ToInt32(userId));
            if (null == item)
                return Json(new { Success = false, Error = "Requirement not found" });
            return Json(new { Success = true, data = item });
        }
    }
}