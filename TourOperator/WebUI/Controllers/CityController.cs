using System;
using System.Linq;
using System.Web.Mvc;
using Models;
using Services.Interfaces;

namespace WebUI.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Json(_cityService.GetAll().Select(c => c.Name).OrderBy(c => c), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(string city)
        {
            if (city == null)
                throw new ArgumentNullException(nameof(city));

            _cityService.Add(new City() { Name = city });
            return Json(true);
        }
    }
}