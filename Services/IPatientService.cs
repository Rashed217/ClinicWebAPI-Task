using ClinicWebApp.Models;

namespace ClinicWebApp.Services
{
    public interface IPatientService
    {
        void AddPatient(Patient patient);
        IEnumerable<Patient> GetAllPatients();
        void GetPatientById(int patientId);
    }
}