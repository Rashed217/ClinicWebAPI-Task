using ClinicWebApp.Models;
using ClinicWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicWebApp.Controllers
{
    // PatientController class handles HTTP requests related to patient operations
    // It interacts with the IPatientService to manage patient data.
    [Route("api/patients")]
    [ApiController] // Specifies that this class is an API controller, which automatically handles model validation and response formatting.
    public class PatientController : ControllerBase
    {
        // IPatientService instance used to interact with the service layer for patient operations
        private readonly IPatientService _patientService;

        // Constructor that accepts an IPatientService and initializes the _patientService field
        // This allows dependency injection of the patient service into the controller
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // Endpoint to add a new patient by accepting a Patient object in the request body
        [HttpPost("add")]
        public IActionResult AddPatient(string name, int age, string gender)
        {
            var Patient = new Patient
            {
                Name = name,
                Age = age,
                Gender = gender
            };

            _patientService.AddPatient(Patient);
            // Returns a 200 OK response when the patient is successfully added
            return Created();
        }

        // Endpoint to retrieve a patient by their unique ID
        [HttpGet("{patientId}")]
        public void GetPatient(int patientId)
        {
            // Retrieves the patient by ID from the patient service
            _patientService.GetPatientById(patientId);
        }

        // Endpoint to retrieve all patients
        [HttpGet]
        public IActionResult GetAllPatients()
        {
            // Retrieves all patients from the patient service
            var patients = _patientService.GetAllPatients();

            // Returns the list of patients as a 200 OK response
            return Ok(patients);
        }
    }
}
