using ClinicWebApp.Models;

namespace ClinicWebApp.Services
{
    public interface IPatientService
    {
        void AddPatient(Patient patient);
        IEnumerable<Patient> GetAllPatients();
        Patient GetPatientById(int patientId);
    }
}