using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Models;
using Services.Interfaces;
using WebUI.Infrastructure;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerPersonalDataService _customerService;
        private readonly ICustomerPassportService _passportService;
        private readonly ICustomerContactDataService _contactService;

        public CustomerController(ICustomerPersonalDataService customerService,
            ICustomerPassportService passportService,
            ICustomerContactDataService contactService)
        {
            if (customerService == null)
                throw new ArgumentNullException(nameof(customerService));
            if (passportService == null)
                throw new ArgumentNullException(nameof(passportService));
            if(contactService == null)
                throw new ArgumentNullException(nameof(contactService));

            _customerService = customerService;
            _contactService = contactService;
            _passportService = passportService;
        }

        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(CustomerModel customer)
        {
            if (customer == null) return HttpNotFound();

            AddCustomerPersonalData(customer);
            return Json(true);
        }

        public ActionResult GetAllCustomers()
        {
            IList<CustomerModel> models = new List<CustomerModel>();
            var customers = _customerService.GetAll().ToList();
            foreach (var personalData in customers)
            {
                models.Add(personalData?.ToCustomerModel());
            }

            return View("ShowCustomers",models);
        }

        public ActionResult GetCustomer(int id)
        {
            var customer = _customerService.GetById(id);
            return View(customer?.ToCustomerModel());
        }

        [HttpGet]
        public ActionResult EditCustomer(int id)
        {
            var customer = _customerService.GetById(id);
            return View(customer?.ToCustomerModel());
        }

        [HttpPost]
        public ActionResult EditCustomer(CustomerModel model)
        {
            var customer = model.ToCustomerPersonalData();
            _contactService.Update(customer.CustomerContactData);
            _passportService.Update(customer.CustomerPassport);
            _customerService.Update(customer);
            return Json(true);
        }

        [HttpPost]
        public ActionResult Remove(int id)
        {
            _customerService.Remove(id);
            return Json(true);
        }

        private void AddCustomerPersonalData(CustomerModel customer)
        {
            _customerService.Add(customer.ToCustomerPersonalData());
        }

    }
}