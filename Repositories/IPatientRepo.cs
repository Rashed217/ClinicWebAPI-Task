using ClinicWebApp.Models;

namespace ClinicWebApp.Repositories
{
    public interface IPatientRepo
    {
        void AddPatient(Patient patient);
        IEnumerable<Patient> GetAllPatients();
        Patient GetPatientById(int patientId);
        void RemovePatientByName(string name);
    }
}