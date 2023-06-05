using Customer.Data;
using Customer.Respositories.Interface;
using Customer.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly CustomerContext _customerContext;
        public CustomerController(ICustomerService customerService, CustomerContext customerContext)
        {
            _customerService = customerService;
            _customerContext= customerContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string Login(string email, string password)
        {
            string LoginRes = "";
            var CheckCustomer = _customerContext.customer_login.Where(x => x.email_id == email && x.password == password).FirstOrDefault();
            if (CheckCustomer is not null)
            {
                // Store customer data in session
                HttpContext.Session.SetString("Email", email);
                HttpContext.Session.SetString("UserId", password);

              return  LoginRes = "Login Successfully";
            }
            else
            {
                return LoginRes = "Invalid credentials";
            }

            
        }

        [HttpPost]
        public string Logout()
        {
            string LoginRes = "";
            // Remove data from session
            HttpContext.Session.Clear();
            return LoginRes = "Logout successfully";
        }

        public IActionResult CustomerDetails()
        {
            return View();
        }
        public dynamic CustomerDetailsList()
        {
            var CustomerList = _customerService.GetCustomerList();
            return CustomerList;
        }

        public dynamic SaveCustomerDetails(CustomerDetailsVM CustomerDetailsModel)
        {
            try
            {
                var CustomerResult = _customerService.SaveCustomerDetails(CustomerDetailsModel);
                return CustomerResult.Result;
            }
            catch (Exception ex)
            {
                throw;
            }


        }

    }
}
