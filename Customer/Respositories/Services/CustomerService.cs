using Customer.Data;
using Customer.Models;
using Customer.Respositories.Interface;
using Customer.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;

namespace Customer.Respositories.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerContext _customerContext;
        public CustomerService(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }
        public async Task<List<customer_details>> GetCustomerList()
        {
            try
            {
                List<customer_details> CustomerDetails = _customerContext.customer_details.ToList();
                return CustomerDetails;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> SaveCustomerDetails(CustomerDetailsVM CustomerDetailsModel)
        {
            try
            {
                customer_details CustomerDetails = new()
                {
                    customer_name = CustomerDetailsModel.customer_name,
                    customer_mobile = CustomerDetailsModel.customer_mobile,
                    customer_address = CustomerDetailsModel.customer_address,
                    customer_dob = CustomerDetailsModel.customer_dob,
                    customer_email = CustomerDetailsModel.customer_email,
                };
                _customerContext.customer_details.Add(CustomerDetails);
                _customerContext.SaveChanges();


                // Send email to the customer
                string? recipientEmail = CustomerDetailsModel.customer_email;
                string subject = "Thank you for your register";
                string body = "Dear customer, you have registered successfully";

                // Temp. comment code for sending email
               // SendEmail(recipientEmail, subject, body);


                return "Customer Saved Successfully";
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void SendEmail(string recipientEmail, string subject, string body)
        {
            try
            {
                // Set your email credentials and SMTP server details
                string senderEmail = "testemail@example.com";
                string senderPassword = "Mahesh@123";
                string smtpServer = "smtp.example.com";
                int smtpPort = 587;

                // Create a MailMessage object
                MailMessage message = new(senderEmail, recipientEmail, subject, body);
                message.IsBodyHtml = true; // Set to true if the body contains HTML

                // Create a SmtpClient object and configure it
                SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
                smtpClient.EnableSsl = true; // Set to true if the SMTP server requires SSL
                smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);

                // Send the email
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
