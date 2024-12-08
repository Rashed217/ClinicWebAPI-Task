using ClinicWebApp.Models;
using ClinicWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicWebApp.Controllers
{
    // ClinicController class handles HTTP requests related to clinic operations
    // It interacts with the IClinicService to manage clinic data.
    [Route("api/clinics")]
    [ApiController] // Specifies that this class is an API controller, which automatically handles model validation and response formatting.
    public class ClinicController : ControllerBase
    {
        // IClinicService instance used to interact with the service layer for clinic operations
        private readonly IClinicService _clinicService;

        // Constructor that accepts an IClinicService and initializes the _clinicService field
        // This allows dependency injection of the clinic service into the controller
        public ClinicController(IClinicService clinicService)
        {
            _clinicService = clinicService;
        }

        // Endpoint to add a new clinic by accepting a Clinic object in the request body
        [HttpPost("add")]
        public IActionResult AddClinic(string Specialization, int NumOfSlots)
        {
            var clinic = new Clinic
            {
                Specialization = Specialization,
                NumberOfSlots = NumOfSlots
            };

            // Returns a 200 OK response when the clinic is successfully added
            return Ok();
        }

        // Endpoint to retrieve a clinic by its unique ID
        [HttpGet("{clinicId}")]
        public void GetClinic(int clinicId)
        {
            // Retrieves the clinic by ID from the clinic service
            _clinicService.GetClinicById(clinicId);

        }

        // Endpoint to retrieve all clinics
        [HttpGet]
        public void GetAllClinics()
        {
            // Retrieves all clinics from the clinic service
            _clinicService.GetAllClinics();
        }
    }
}
