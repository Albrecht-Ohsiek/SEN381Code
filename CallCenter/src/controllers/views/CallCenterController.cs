using System;
using Microsoft.AspNetCore.Mvc;
using CallCenter.Services;
using CallCenter.Models;
using CallCenter.Repository;
using Microsoft.Data.SqlClient;

namespace CallCenter.Controllers
{
    [ApiController]
    [Route("/CallCenter")]
    public class CallCenterController : Controller
    {
        private readonly IClientRepository _clientRepository;
        private readonly ICallRepository _callRepository;
        private readonly DatabaseServices _dbService;

        public CallCenterController(DatabaseServices dbService, ICallRepository callRepository, IClientRepository clientRepository)
        {
            _callRepository = callRepository;
            _dbService = dbService;
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public async Task<IActionResult> CallCenter()
        {
            return View();
        }
        //display technicians in dropdown menu of express work request form
        [HttpGet("GetTechnicians")]
        public IActionResult GetTechnicians()
        {
            using (var connection = _dbService.GetOpenConnection())
            {
                string query = "SELECT * FROM Technicians";
                using (var command = _dbService.CreateCommand(query, connection))
                {
                    var technicians = new List<Technician>(); // Replace Technician with your actual model
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Populate the technicians list with data from the database
                            var technician = new Technician
                            {
                                // Map database columns to the properties of your Technician model
                                // Example: technician.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            };
                            technicians.Add(technician);
                        }
                    }
                    return Ok(technicians);
                }
            }
        }


        //notifiy selected technician of new "express" work request on express work request form
        [HttpPost("NotifyTechnician")]
        public IActionResult NotifyTechnician([FromBody] NotifyTechnicianRequest request)
        {
            using (var connection = _dbService.GetOpenConnection())
            {
                // Modify the query to get contact details for the specified technician
                string query = "SELECT Email, PhoneNumber FROM Technicians WHERE TechnicianId = @TechnicianId";
                using (var command = _dbService.CreateCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@TechnicianId", request.TechnicianId));

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string email = reader.GetString(reader.GetOrdinal("Email"));
                            string phoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));

                            string message = "New Express Work Request!\n" +
                                "Client Name: " + request.ClientName + "\n" +
                                "Client Phone: " + request.ClientPhone + "\n" +
                                "Client Address: " + request.ClientAddress + "\n" +
                                "Problem Description: " + request.ProblemDescription;

                            try
                            {
                                if (request.NotifyEmail)
                                {
                                    var emailService = new EmailNotificationServices();
                                    emailService.Notify(message, email);
                                }
                                if (request.NotifySMS)
                                {
                                    var smsService = new SMSNotificationServices();
                                    smsService.Notify(message, phoneNumber);
                                }
                                if (request.NotifyWhatsapp)
                                {
                                    var whatsappService = new WhatsappNotificationServices();
                                    whatsappService.Notify(message, phoneNumber);
                                }

                                return Ok("Notifications sent successfully!");
                            }
                            catch (Exception ex)
                            {
                                return BadRequest("Error sending notification. Phone number: " + phoneNumber + ". Email: " + email + ". Error: " + ex.Message);
                            }
                        }
                        else
                        {
                            return NotFound("Technician not found");
                        }
                    }
                }
            }
        }

    }
}