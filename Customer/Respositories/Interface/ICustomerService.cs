using Customer.Models;
using Customer.ViewModels;

namespace Customer.Respositories.Interface
{
    public interface ICustomerService
    {
        Task<List<customer_details>> GetCustomerList();
        Task<string> SaveCustomerDetails(CustomerDetailsVM CustomerDetailsModel);
    }
}
