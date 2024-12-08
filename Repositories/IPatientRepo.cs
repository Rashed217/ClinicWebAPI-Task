using ClinicWebApp.Models;

namespace ClinicWebApp.Repositories
{
    public interface IPatientRepo
    {
        void AddPatient(Patient patient);
        IEnumerable<Patient> GetAllPatients();
        void GetPatientById(int patientId);
    }
}