using ClinicWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicWebApp.Repositories
{
    // PatientRepo class implements the IPatientRepo interface
    // It is responsible for interacting with the ApplicationDbContext to perform CRUD operations on the Patient data.
    public class PatientRepo : IPatientRepo
    {
        // ApplicationDbContext instance used to interact with the database
        private readonly ApplicationDbContext _context;

        // Constructor that accepts an ApplicationDbContext and initializes the _context field
        // This allows dependency injection of the database context into the repository
        public PatientRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        // Method to add a new Patient to the database asynchronously
        public void AddPatient(Patient patient)
        {
            // Adds the given patient entity to the Patients DbSet in the context
            _context.Patients.Add(patient);

            // Saves the changes to the database asynchronously
            _context.SaveChanges();
        }

        // Method to retrieve a Patient by their unique ID asynchronously
        public void GetPatientById(int patientId)
        {
            // Finds a patient by their ID in the Patients DbSet asynchronously
            // If no patient is found, it returns null
            _context.Patients.Find(patientId);
        }

        // Method to retrieve all Patients from the database asynchronously
        public IEnumerable<Patient> GetAllPatients()
        {
            // Retrieves all patients from the Patients DbSet asynchronously
            // The ToListAsync method converts the DbSet into a list of patients
            return _context.Patients.ToList();
        }
    }

}
